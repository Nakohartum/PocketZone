using System;
using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.MoveFeature
{
    public class MoveWithPlayer : MonoBehaviour, IExecutable
    {
        private Transform _playerTransform;

        private void Start()
        {
            UpdateManager.Instance.AddExecutable(this);
        }

        public void SetPlayerTransform(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public void Execute(float deltaTime)
        {
            transform.position = _playerTransform.position;
        }

        private void OnDestroy()
        {
            UpdateManager.Instance.RemoveExecutable(this);
        }
    }
}