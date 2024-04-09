using System;
using _Root.Code.Interfaces;
using _Root.Code.MoveFeature;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace _Root.Code.Input
{
    public class PlayerController : IExecutable, IDisposable
    {
        private Player _player;
        private MoveBehaviour _moveBehaviour;
        private RotationBehaviour _rotationBehaviour;
        private ShootController _shootController;
        private InputActions _inputActions;

        private int _moveStringHash;
        private SpriteRenderer[] _spriteRenderers;

        public PlayerController(Player player)
        {
            _player = player;
            _moveBehaviour = new MoveBehaviour(_player.Rigidbody);
            _inputActions = new InputActions();
            _inputActions.Enable();
            _moveStringHash = Animator.StringToHash("Walk");
            _shootController = new ShootController(_player, _player.RangeDrawer, _player.PlayerModel, _inputActions);
            _rotationBehaviour = new RotationBehaviour(_player.WeaponRotation, _player.transform);
            _spriteRenderers = _player.GetComponentsInChildren<SpriteRenderer>();
            UpdateManager.Instance.AddExecutable(this);
        }

        public void Execute(float deltaTime)
        {
            Enemy.Enemy enemy = null;
            var moveVector = _inputActions.Controllers.Move.ReadValue<Vector2>();
            _moveBehaviour.Move(moveVector, 3);
            if (_shootController.CheckShootingInRadius())
            {
                if (_shootController.CalculateClosestEnemy(out enemy))
                {
                    _rotationBehaviour.RotateTowardsEnemy(enemy.transform.position);
                }
            }

            if (enemy == null && moveVector.sqrMagnitude > 0)
            {
                _rotationBehaviour.Rotate(moveVector);
            }
            _player.Animator.SetBool(_moveStringHash, moveVector.sqrMagnitude > 0);
        }

        public void Dispose()
        {
            _inputActions?.Dispose();
            UpdateManager.Instance.RemoveExecutable(this);
        }
    }

    public class RotationBehaviour
    {
        private Transform _transform;
        private Transform _mainTransform;

        public RotationBehaviour(Transform transform, Transform mainTransform)
        {
            _transform = transform;
            _mainTransform = mainTransform;
        }

        public void Rotate(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += 90f;
            _transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
            _mainTransform.localScale = new Vector3(direction.x < 0 ? -1 : 1, 1, 1);
        }

        public void RotateTowardsEnemy(Vector3 direction)
        {
            Vector3 vectorToCalculate = direction - _mainTransform.position;
            float angle = Mathf.Atan2(vectorToCalculate.y, vectorToCalculate.x) * Mathf.Rad2Deg;
            angle += 90f;
            _transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
            _mainTransform.localScale = new Vector3(vectorToCalculate.x < 0 ? -1 : 1, 1, 1);
        }
    }
}