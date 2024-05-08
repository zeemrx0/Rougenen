using System;
using System.Collections;
using LNE.Characters;
using LNE.Combat.Abilities;
using LNE.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat
{
  public class Projectile : MonoBehaviour
  {
    public Character Owner { get; set; }
    public IObjectPool<Projectile> BelongingPool { get; set; }
    public float AliveRange { get; set; } = 1000000000f;

    public AbilityStatsData AbilityStatsData { get; set; }

    [field: SerializeField]
    private LayerMask _ignoreLayers;

    [SerializeField]
    private VFX _onHitObjectVFXPrefab;

    [SerializeField]
    private SoundData _onHitObjectSound;

    private Rigidbody2D _rigidbody;
    private SoundPlayer _soundPlayer;
    private bool _isDestroyedOnCollision = false;
    private Vector2 _lastOwnerPosition;
    private bool _rotateAroundOwner = false;
    private float _lastAngle = 0f;

    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
      _soundPlayer = GetComponent<SoundPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if ((_ignoreLayers & (1 << other.gameObject.layer)) > 0)
      {
        return;
      }

      other.gameObject.TryGetComponent<Character>(out Character owner);
      if (_isDestroyedOnCollision || owner == Owner)
      {
        return;
      }

      switch (other.tag)
      {
        default:
          if (_onHitObjectVFXPrefab != null)
          {
            SpawnVFX(_onHitObjectVFXPrefab);
            _soundPlayer.Play(_onHitObjectSound);

            other.TryGetComponent<CharacterHealthPresenter>(
              out CharacterHealthPresenter health
            );
            health?.TakeDamage(AbilityStatsData.Damage);

            _isDestroyedOnCollision = true;
            Deactivate(
              Mathf.Max(
                _onHitObjectVFXPrefab.Duration,
                _onHitObjectSound.AudioClip.length
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

      if (Vector2.Distance(transform.position, _lastOwnerPosition) > AliveRange)
      {
        Deactivate(0);
      }

      if (_rotateAroundOwner)
      {
        Vector2 targetPosition =
          (
            Quaternion.Euler(0, 0, -_lastAngle)
            * (Vector2.up * AbilityStatsData.Range)
          ) + Owner.transform.position;

        Debug.Log(targetPosition);

        transform.position = targetPosition;

        _lastAngle +=
          AbilityStatsData.ProjectileSpeed
          / (2 * (float)Math.PI * AbilityStatsData.Range)
          * 360
          * Time.deltaTime;

        transform.up = (_lastOwnerPosition - (Vector2)transform.position) * -1;
      }
    }

    private void SpawnVFX(VFX vfx)
    {
      if (vfx != null)
      {
        VFX particleEffect = Instantiate(
          vfx,
          transform.position,
          Quaternion.identity
        );

        Destroy(particleEffect, vfx.Duration);
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

      BelongingPool.Release(this);
    }

    public void RotateAroundOwner(float speed)
    {
      _rotateAroundOwner = true;
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
