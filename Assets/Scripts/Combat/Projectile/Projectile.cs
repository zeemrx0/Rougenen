using System;
using System.Collections;
using LNE.Characters;
using LNE.Core;
using LNE.GameStats;
using LNE.Utilities.Constants;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat
{
  public class Projectile : MonoBehaviour
  {
    public Character Owner { get; set; }
    public Stats Stats { get; set; }
    public IObjectPool<Projectile> BelongingPool { get; set; }
    public VFX OnHitVFX { get; set; }
    public SoundData OnHitSound { get; set; }
    public bool IsOrbit { get; set; } = false;

    private Rigidbody2D _rigidbody;
    private SoundPlayer _soundPlayer;
    private bool _isDestroyedOnCollision = false;
    private Vector3 _lastOwnerPosition;
    private float _lastAngle = 0f;

    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
      _soundPlayer = GetComponent<SoundPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (
        ((int)Stats.Get(StatName.IgnoreLayers) & (1 << other.gameObject.layer))
        > 0
      )
      {
        return;
      }

      other.TryGetComponent<Character>(out Character otherCharacter);
      if (otherCharacter == null)
      {
        return;
      }

      if (_isDestroyedOnCollision || otherCharacter == Owner)
      {
        return;
      }

      switch (other.tag)
      {
        case TagName.Projectile:
          break;

        default:
          SpawnVFX(OnHitVFX);
          _soundPlayer.PlayOneShot(OnHitSound);

          other.TryGetComponent<CharacterHealthPresenter>(
            out CharacterHealthPresenter health
          );
          health?.TakeDamage(Stats.Get(StatName.Damage));

          if (Stats.Get(StatName.DestroyProjectileOnCollision) == 1)
          {
            _isDestroyedOnCollision = true;

            Deactivate(
              Mathf.Max(
                OnHitVFX != null ? OnHitVFX.Duration : 0,
                OnHitSound != null ? OnHitSound.AudioClip.length : 0
              )
            );
          }

          break;
      }
    }

    private void Update()
    {
      if (Owner != null)
      {
        _lastOwnerPosition = Owner.transform.position;
      }

      transform.right = _rigidbody.velocity.normalized;

      if (
        Vector2.Distance(transform.position, _lastOwnerPosition)
        > Stats.Get(StatName.ProjectileAliveRange)
      )
      {
        Deactivate(0);
      }

      if (IsOrbit)
      {
        Vector2 targetPosition =
          (
            Quaternion.Euler(0, 0, -_lastAngle)
            * (Vector2.up * Stats.Get(StatName.Range))
          ) + _lastOwnerPosition;

        transform.position = targetPosition;

        _lastAngle +=
          Stats.Get(StatName.ProjectileSpeed)
          / (2 * (float)Math.PI * Stats.Get(StatName.Range))
          * 360
          * Time.deltaTime;

        transform.up =
          ((Vector2)_lastOwnerPosition - (Vector2)transform.position) * -1;
      }
    }

    public void StartOrbit(float angle)
    {
      _lastAngle = angle;
      IsOrbit = true;
    }

    private void SpawnVFX(VFX vfx)
    {
      if (vfx != null)
      {
        Instantiate(vfx, transform.position, Quaternion.identity);
      }
    }

    private void Deactivate(float time)
    {
      StartCoroutine(DeactivateAfterTime(time));
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
      yield return new WaitForSeconds(0.01f);

      GameObject child = transform.GetChild(0).gameObject;
      child?.SetActive(false);

      yield return new WaitForSeconds(time);

      _rigidbody.velocity = Vector2.zero;
      _rigidbody.angularVelocity = 0f;
      _isDestroyedOnCollision = false;

      child?.SetActive(true);

      if (BelongingPool != null)
      {
        BelongingPool.Release(this);
      }
      else
      {
        Destroy(gameObject);
      }
    }

    public void SetVelocity(Vector2 velocity)
    {
      _rigidbody.velocity = velocity;
    }

    public void SetAngularVelocity(float angularVelocity)
    {
      _rigidbody.angularVelocity = angularVelocity;
    }

    public void SetGravityScale(float gravityScale)
    {
      _rigidbody.gravityScale = gravityScale;
    }
  }
}
