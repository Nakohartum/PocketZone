using System;
using UnityEngine;

namespace _Root.Code.Input
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Transform _root;

        public void InitializeBullet(Transform root)
        {
            _root = root;
        }

        public void GetFromPool()
        {
            transform.SetParent(null);
            gameObject.SetActive(true);
        }
        
        public void AddForce(Vector2 direction, float force)
        {
            _rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
            
        }

        public void GetToPool(Transform root)
        {
            gameObject.SetActive(false);
            transform.SetParent(root);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var enemy = other.gameObject.GetComponent<Enemy.Enemy>();
            if (enemy != null)
            {
                enemy.EnemyModel.Health.GetDamage(50);
            }

            GetToPool(_root);
        }
    }
}