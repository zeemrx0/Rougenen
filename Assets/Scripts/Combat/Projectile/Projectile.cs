using System;
using System.Collections;
using LNE.Characters;
using LNE.Combat.Abilities;
using LNE.Core;
using LNE.Utilities.Constants;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat
{
  public class Projectile : MonoBehaviour
  {
    public Character Owner { get; set; }
    public AbilityStatsData AbilityStatsData { get; set; }
    public IObjectPool<Projectile> BelongingPool { get; set; }
    public LayerMask IgnoreLayers { get; set; }
    public VFX OnHitVFX { get; set; }
    public SoundData OnHitSound { get; set; }
    public bool IsOrbit { get; set; } = false;

    private Rigidbody2D _rigidbody;
    private SoundPlayer _soundPlayer;
    private bool _isDestroyedOnCollision = false;
    private Vector2 _lastOwnerPosition;
    private float _lastAngle = 0f;

    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
      _soundPlayer = GetComponent<SoundPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if ((IgnoreLayers & (1 << other.gameObject.layer)) > 0)
      {
        return;
      }

      other.TryGetComponent<Character>(out Character otherCharacter);
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
          _soundPlayer.Play(OnHitSound);

          other.TryGetComponent<CharacterHealthPresenter>(
            out CharacterHealthPresenter health
          );
          health?.TakeDamage(AbilityStatsData.Damage);

          if (AbilityStatsData.IsDestroyProjectileOnCollision)
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

      if (
        Vector2.Distance(transform.position, _lastOwnerPosition) > 1000000000f
      )
      {
        Deactivate(0);
      }

      if (IsOrbit)
      {
        Vector2 targetPosition =
          (
            Quaternion.Euler(0, 0, -_lastAngle)
            * (Vector2.up * AbilityStatsData.Range)
          ) + Owner.transform.position;

        transform.position = targetPosition;

        _lastAngle +=
          AbilityStatsData.ProjectileSpeed
          / (2 * (float)Math.PI * AbilityStatsData.Range)
          * 360
          * Time.deltaTime;

        transform.up = (_lastOwnerPosition - (Vector2)transform.position) * -1;
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
