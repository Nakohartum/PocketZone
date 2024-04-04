using System;
using UnityEngine;

namespace _Root.Code.MoveFeature
{
    public class MoveWithPlayer : MonoBehaviour
    {
        private Transform _playerTransform;

        public void SetPlayerTransform(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        private void Update()
        {
            transform.position = _playerTransform.position;
        }
    }
}