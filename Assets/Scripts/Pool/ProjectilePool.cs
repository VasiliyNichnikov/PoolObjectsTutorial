using UnityEngine;
using Utils;

namespace Pool
{
    public class ProjectilePool : PoolBase<Projectile.Projectile>
    {
        private readonly Transform _holderProjectiles;

        public ProjectilePool(Transform holderProjectiles)
        {
            _holderProjectiles = holderProjectiles;
        }
        
        public override Projectile.Projectile GetOrCreateObject()
        {
            while (UnusedObjects.Count > 0)
            {
                var selectedProjectile = UnusedObjects.Dequeue();
                UsedObjects.Enqueue(selectedProjectile);
                selectedProjectile.Show();
                return selectedProjectile;
            }
            var createdProjectile = Object.Instantiate(ProjectileCollection.Instance.ProjectilePrefab, _holderProjectiles, false);
            createdProjectile.Show();
            UsedObjects.Enqueue(createdProjectile);
            return createdProjectile;
        }
    }
}