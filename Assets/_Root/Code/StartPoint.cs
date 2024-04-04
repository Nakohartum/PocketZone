using System;
using _Root.Code.Factories;
using _Root.Code.ScriptableObjectsCode;
using UnityEngine;

namespace _Root.Code
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private PlayerSo _playerSo;

        private void Start()
        {
            new PlayerFactory(_playerSo).CreatePlayer();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            UpdateManager.Instance.Execute(deltaTime);
        }
    }
}