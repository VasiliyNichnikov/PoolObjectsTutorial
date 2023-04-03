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
            var projectile = _pool.GetOrCreateObject(ProjectileType.Default);
            projectile.transform.position = startPosition;
            projectile.Init(direction, () => HideProjectile(projectile));
        }

        private void HideProjectile(Projectile projectile)
        {
            _pool.HideProjectile(projectile);
        }
    }
}