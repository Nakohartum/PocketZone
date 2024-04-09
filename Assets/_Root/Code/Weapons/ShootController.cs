using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Code.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace _Root.Code.Input
{
    public class ShootController : IExecutable
    {
        private Player _player;
        private RangeDrawer _rangeDrawer;
        private PlayerModel _playerModel;

        private float _ammoIndicatorChange;
        
        private InputActions _inputActions;
        private Weapon _weapon;
        private float _lastShot;
        private int _ammoLeft;
        
        private Collider2D[] _collisions = new Collider2D[10];
        private List<Enemy.Enemy> _enemies = new List<Enemy.Enemy>();

        public ShootController(Player player, RangeDrawer rangeDrawer, PlayerModel playerModel, InputActions inputActions)
        {
            _player = player;
            _rangeDrawer = rangeDrawer;
            _playerModel = playerModel;
            _inputActions = inputActions;
            SetNewWeapon(_playerModel.Weapon);
            _ammoIndicatorChange = 1f / _weapon.Clip;
            UpdateManager.Instance.AddExecutable(this);
            UpdateUI(true);
            _rangeDrawer.DrawCircle(_weapon.Radius);
        }

        public void SetNewWeapon(WeaponSo weaponSo)
        {
            _weapon = Object.Instantiate(weaponSo.WeaponPrefab, _player.WeaponPosition);
            _weapon.InitializeWeapon(weaponSo);
        }
        
        public void Execute(float deltaTime)
        {
            _lastShot -= deltaTime;
            if (CheckShootingInRadius())
            {
                CalculateClosestEnemy(out var enemy);
                Shoot(enemy.transform.position);
            }

            if (_weapon.Clip == 0)
            {
                _player.StartCoroutine(Reload());
            }
        }

        public bool CalculateClosestEnemy(out Enemy.Enemy enemy)
        {
            enemy = _enemies[0];
            float minDistance = Vector3.Distance(enemy.transform.position, _player.transform.position);

            for (int i = 1; i < _enemies.Count; i++)
            {
                var distance = Vector3.Distance(_enemies[i].transform.position, _player.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    enemy = _enemies[i];
                }
            }
            

            return enemy != null;
        }

        private void Shoot(Vector3 position)
        {
            if (_inputActions.Controllers.Shoot.IsPressed() && _lastShot <= 0 && _weapon.Clip > 0)
            {
                position = position - _player.transform.position;
                _weapon.Clip--;
                _lastShot = 1f / _weapon.FireRate;
                PlayEffects();
                UpdateUI(false);
                var bullet = _weapon.Pool.GetFromPool(position);
                bullet.InitializeBullet(_weapon.Pool.transform);
                _weapon.Pool.MoveToPool(bullet, 4f);
            }
        }

        private void PlayEffects()
        {
            _weapon.ShootingSystem.Play();
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
                    UpdateUI(true);
                }
                else
                {
                    _weapon.Clip = _weapon.Ammo;
                    _weapon.Ammo = 0;
                }
            }
        }

        private void UpdateUI(bool isReloading)
        {
            var transformLocalScale = UIManager.Instance.CurrentAmmoBar.transform.localScale;
            if (isReloading)
            {
                transformLocalScale.Set(1f, Mathf.Clamp(transformLocalScale.y + (_ammoIndicatorChange * _weapon.Clip), 0f, 1f) ,
                    1f);
            }
            else
            {
                transformLocalScale.Set(1f, Mathf.Clamp(transformLocalScale.y - _ammoIndicatorChange, 0f, 1f) ,1f);
            }
            UIManager.Instance.CurrentAmmoBar.transform.localScale = transformLocalScale;
            UIManager.Instance.AmmoText.SetText($"{_weapon.Ammo}/{_weapon.MaxAmmo}");
        }

        public bool CheckShootingInRadius()
        {
            _enemies.Clear();

            for (int i = 0; i < _collisions.Length; i++)
            {
                _collisions[i] = null;
            }
            
            Physics2D.OverlapCircleNonAlloc(_player.transform.position, _weapon.Radius, _collisions);
            
            
                foreach (var col in _collisions)
                {
                    if (col != null)
                    {
                        if (col.TryGetComponent<Enemy.Enemy>(out var enemy))
                        {
                            _enemies.Add(enemy);
                        }
                    }
                }

            if (_enemies.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}