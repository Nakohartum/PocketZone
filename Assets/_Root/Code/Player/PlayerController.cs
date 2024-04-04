using System;
using _Root.Code.Interfaces;
using _Root.Code.MoveFeature;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace _Root.Code.Input
{
    public class PlayerController : MonoBehaviour, IExecutable
    {
        [SerializeField] private Player _player;
        private MoveBehaviour _moveBehaviour;
        [SerializeField] private ShootController _shootController;
        private InputActions _inputActions;

        private int _moveStringHash;

        private void Start()
        {
            _moveBehaviour = new MoveBehaviour(_player.Rigidbody);
            _inputActions = new InputActions();
            _inputActions.Enable();
            _shootController.InitializeController(_inputActions, _player);
            _moveStringHash = Animator.StringToHash("Walk");
            UpdateManager.Instance.AddExecutable(this);
        }

        public void Execute(float deltaTime)
        {
            var moveVector = _inputActions.Controllers.Move.ReadValue<Vector2>();
            _moveBehaviour.Move(moveVector, 3);
            if (moveVector.sqrMagnitude > 0)
            {
                _player.Animator.SetBool(_moveStringHash, true);
            }
            else
            {
                _player.Animator.SetBool(_moveStringHash, false);
            }
        }

        private void OnDestroy()
        {
            UpdateManager.Instance.RemoveExecutable(this);
        }
    }
}