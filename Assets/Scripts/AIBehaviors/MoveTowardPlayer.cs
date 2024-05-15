using BehaviorDesigner.Runtime.Tasks;
using LNE.Characters;
using LNE.Movements;
using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.AI.Behaviors
{
  public class MoveTowardPlayer : Action
  {
    [SerializeField]
    private float _stopDistance = 1f;

    private Character _playerCharacter;
    private AICharacterMovementPresenter _movementPresenter;

    public override void OnAwake()
    {
      _playerCharacter = GameObject
        .FindGameObjectWithTag(TagName.Player)
        ?.GetComponent<Character>();

      _movementPresenter = GetComponent<AICharacterMovementPresenter>();
    }

    public override TaskStatus OnUpdate()
    {
      if (_playerCharacter == null)
      {
        return TaskStatus.Failure;
      }

      if (
        Vector2.Distance(
          transform.position,
          _playerCharacter.transform.position
        ) < _stopDistance
      )
      {
        _movementPresenter.Stop();
        return TaskStatus.Success;
      }

      Vector2 destination =
        _playerCharacter.transform.position
        + (transform.position - _playerCharacter.transform.position).normalized
          * _stopDistance;

      _movementPresenter.MoveToPosition(destination);

      return TaskStatus.Success;
    }
  }
}
