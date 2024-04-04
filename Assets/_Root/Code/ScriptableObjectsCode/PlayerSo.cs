using _Root.Code.Input;
using UnityEngine;

namespace _Root.Code.ScriptableObjectsCode
{
    [CreateAssetMenu(fileName = nameof(PlayerSo), menuName = "Player/"+nameof(PlayerSo), order = 0)]
    public class PlayerSo : ScriptableObject
    {
        public Player PlayerPrefab;
        public WeaponSo InitialWeapon;
    }
}