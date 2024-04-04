using UnityEngine;

namespace _Root.Code.Input
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Transform WeaponPosition { get; private set; }
        [field: SerializeField] public WeaponSo Weapon { get; private set; }

        public void SetWeapon(WeaponSo weaponSo)
        {
            Weapon = weaponSo;
        }
        
    }
}