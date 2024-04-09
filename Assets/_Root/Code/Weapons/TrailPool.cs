using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Root.Code.Input
{
    public class TrailPool : MonoBehaviour
    {
        [SerializeField] private List<Bullet> _trails;
        [SerializeField] private Bullet _bulletPrefab;

        public Bullet GetFromPool(Vector2 direction)
        {
            var trail = _trails.First(x => x.gameObject.activeSelf == false);
            if (trail == null)
            {
                trail = Instantiate(_bulletPrefab);
                _trails.Add(trail);
            }
            trail.GetFromPool();
            trail.AddForce(direction, 5);
            return trail;
        }

        public void MoveToPool(Bullet bullet, float time)
        {
            StartCoroutine(MoveToPoolRoutine(bullet, time));
        }

        private IEnumerator MoveToPoolRoutine(Bullet bullet, float time)
        {
            yield return new WaitForSeconds(time);
            bullet.GetToPool(transform);
        }
    }
}