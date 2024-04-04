using _Root.Code.MoveFeature;
using _Root.Code.ScriptableObjectsCode;
using Cinemachine;
using UnityEngine;

namespace _Root.Code.Factories
{
    public class PlayerFactory
    {
        private PlayerSo _playerSo;

        public PlayerFactory(PlayerSo playerSo)
        {
            _playerSo = playerSo;
        }

        public void CreatePlayer()
        {
            var player = Object.Instantiate(_playerSo.PlayerPrefab);
            player.SetWeapon(_playerSo.InitialWeapon);
            Object.FindObjectOfType<MoveWithPlayer>().SetPlayerTransform(player.transform);
            Object.FindObjectOfType<CinemachineTargetGroup>().AddMember(player.transform, 1, 5f);
        }
    }
}