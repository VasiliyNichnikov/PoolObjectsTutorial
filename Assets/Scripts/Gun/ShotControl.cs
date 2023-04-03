using System;
using Projectile;
using UnityEngine;

namespace Gun
{
    public class ShotControl : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _parentProjectiles;

        private ProjectileManager _projectileManager;

        private void Start()
        {
            _projectileManager = new ProjectileManager(_parentProjectiles);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var direction = transform.TransformDirection(Vector3.up);
                _projectileManager.LaunchProjectile(_startPoint.position, direction);
            }
        }
    }
}