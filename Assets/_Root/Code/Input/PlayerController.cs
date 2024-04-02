using System;
using _Root.Code.MoveFeature;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Code.Input
{
    public class PlayerController : MonoBehaviour
    {
        private MoveBehaviour _moveBehaviour;
        private ShootController _shootController;
        private InputActions _inputActions;

        private void Start()
        {
            _moveBehaviour = new MoveBehaviour(transform);
            _shootController = new ShootController();
            _inputActions = new InputActions();
            _inputActions.Controllers.Shoot.performed += ShootOnperformed;
            _inputActions.Enable();
        }

        private void ShootOnperformed(InputAction.CallbackContext obj)
        {
            _shootController.Shoot();
        }

        private void Update()
        {
            var moveVector = _inputActions.Controllers.Move.ReadValue<Vector2>();
            _moveBehaviour.Move(moveVector, 2, Time.deltaTime);
        }
    }
}