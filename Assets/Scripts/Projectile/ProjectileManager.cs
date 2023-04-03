using Pool;
using UnityEngine;

namespace Projectile
{
    public class ProjectileManager
    {
        private readonly ProjectilePool _pool;

        public ProjectileManager(Transform projectilesHolder)
        {
            _pool = new ProjectilePool(projectilesHolder);
        }

        public void LaunchProjectile(Vector3 startPosition, Vector3 direction)
        {
            var projectile = _pool.GetOrCreateObject();
            projectile.transform.position = startPosition;
            projectile.Init(direction, () => _pool.HideObject(projectile));
        }
    }
}