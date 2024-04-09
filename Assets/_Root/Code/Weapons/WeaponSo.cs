using UnityEngine;

namespace _Root.Code.Input
{
    [CreateAssetMenu(fileName = nameof(WeaponSo), menuName = "Weapons/"+nameof(WeaponSo), order = 0)]
    public class WeaponSo : ScriptableObject
    {
        public float Damage;
        public float FireRate;
        public int Ammo;
        public bool InfiniteAmmo;
        public float Clip;
        public float Range;

        public Weapon WeaponPrefab;
    }
}