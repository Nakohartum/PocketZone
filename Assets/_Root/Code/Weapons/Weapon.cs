using UnityEngine;

namespace _Root.Code.Input
{
    public class Weapon : MonoBehaviour
    {
        public float Damage;
        public float FireRate;
        public float MaxAmmo;
        public float Ammo;
        public bool InfiniteAmmo;
        public float MaxClip;
        public float Clip;
        public float Radius;
        public ParticleSystem ShootingSystem;
        public TrailPool Pool;

        public void InitializeWeapon(WeaponSo weaponSo)
        {
            Damage = weaponSo.Damage;
            FireRate = weaponSo.FireRate;
            MaxAmmo = weaponSo.Ammo;
            InfiniteAmmo = weaponSo.InfiniteAmmo;
            MaxClip = weaponSo.Clip;
            Ammo = MaxAmmo;
            Clip = MaxClip;
            Radius = weaponSo.Range;
        }
        
    }
}