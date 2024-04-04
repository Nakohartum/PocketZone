using System;
using System.Collections;
using _Root.Code.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.Input
{
    public class ShootController : MonoBehaviour, IExecutable
    {
        [SerializeField] private float _amount;
        [SerializeField] private Image _bullets;
        [SerializeField] private Player _player;

        private float _ammoIndicatorChange;
        
        private InputActions _inputActions;
        private Weapon _weapon;
        private float _lastShot;
        private int _ammoesLeft;

        public void InitializeController(InputActions inputActions, Player player)
        {
            _inputActions = inputActions;
            _player = player;
            
            UpdateManager.Instance.AddExecutable(this);
            SetNewWeapon(_player.Weapon);
            _ammoIndicatorChange = 1f / _weapon.Clip;
        }

        public void SetNewWeapon(WeaponSo weaponSo)
        {
            _weapon = Instantiate(weaponSo.WeaponPrefab, _player.WeaponPosition);
            _weapon.InitializeWeapon(weaponSo);
        }
        
        public void Execute(float deltaTime)
        {
            _lastShot -= deltaTime;
            if (_inputActions.Controllers.Shoot.IsPressed() && _lastShot <= 0 && _weapon.Clip > 0)
            {
                _weapon.Clip--;
                _lastShot = 1f / _weapon.FireRate;
                _weapon.ShootingSystem.Play();
                Debug.Log($"Shot ammoes left {_weapon.Clip}");
                var transformLocalScale = UIManager.Instance.WeaponAmmoes.transform.localScale;
                transformLocalScale.Set(1f, Mathf.Clamp(transformLocalScale.y - _ammoIndicatorChange, 0f, 1f) ,1f);
                UIManager.Instance.WeaponAmmoes.transform.localScale = transformLocalScale;
            }

            if (_weapon.Clip == 0)
            {
                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            float reloadTime = 2f;
            while (reloadTime > 0f)
            {
                reloadTime -= Time.deltaTime;
                yield return null;
            }
            var reloadCount = _weapon.Ammo - _weapon.MaxClip;
            if (reloadCount > 0)
            {
                if (_weapon.Ammo > reloadCount)
                {
                    _weapon.Ammo -= _weapon.MaxClip;
                    _weapon.Clip = reloadCount;
                    var transformLocalScale = UIManager.Instance.WeaponAmmoes.transform.localScale;
                    transformLocalScale.Set(1f, Mathf.Clamp(transformLocalScale.y + (_ammoIndicatorChange * _weapon.Clip), 0f, 1f) ,
                        1f);
                    UIManager.Instance.WeaponAmmoes.transform.localScale = transformLocalScale;
                }
                else
                {
                    _weapon.Clip = _weapon.Ammo;
                    _weapon.Ammo = 0;
                }
            }
        }

        private void OnDestroy()
        {
            UpdateManager.Instance.RemoveExecutable(this);
        }
    }
}