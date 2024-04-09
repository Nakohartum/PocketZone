using System;
using UnityEngine;

namespace _Root.Code.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public EnemyModel EnemyModel { get; private set; }

        private void Start()
        {
            InitializeView(new EnemyModel(new Health.Health(100, 100, gameObject)));
        }

        public void InitializeView(EnemyModel enemyModel)
        {
            EnemyModel = enemyModel;
        }
    }
}