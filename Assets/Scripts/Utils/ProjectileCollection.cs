using System;
using Pool;
using UnityEngine;

namespace Utils
{
    public class ProjectileCollection : MonoBehaviour
    {
        public static ProjectileCollection Instance => _instance;

        public Projectile.Projectile ProjectilePrefab => _projectilePrefab;
        private static ProjectileCollection _instance;

        [SerializeField] private Projectile.Projectile _projectilePrefab;
        
        private void Awake()
        {
            _instance = this;
        }
    }
}