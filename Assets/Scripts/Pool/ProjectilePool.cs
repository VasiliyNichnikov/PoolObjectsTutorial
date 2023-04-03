using UnityEngine;
using Utils;

namespace Pool
{
    public class ProjectilePool : PoolBase<Projectile.Projectile, ProjectileType>
    {
        private readonly Transform _holderProjectiles;

        public ProjectilePool(Transform holderProjectiles)
        {
            _holderProjectiles = holderProjectiles;
        }
        
        public override Projectile.Projectile GetOrCreateObject(ProjectileType typeObj)
        {
            while (UnusedObjects.Count > 0)
            {
                var selectedProjectile = UnusedObjects.Dequeue();
                if (selectedProjectile.Type == typeObj)
                {
                    UsedObjects.Enqueue(selectedProjectile);
                    selectedProjectile.Show();
                    return selectedProjectile;
                }
            }
            var createdProjectile = Object.Instantiate(ProjectileCollection.Instance.ProjectilePrefab, _holderProjectiles, false);
            createdProjectile.Show();
            UsedObjects.Enqueue(createdProjectile);
            return createdProjectile;
        }

        public void HideProjectile(Projectile.Projectile projectile)
        {
            var tempLength = UsedObjects.Count;
            while (UsedObjects.Count > 0 && tempLength > 0)
            {
                tempLength--;
                var selectedProjectile = UsedObjects.Dequeue();
                if (selectedProjectile == projectile)
                {
                    selectedProjectile.Hide();
                    UnusedObjects.Enqueue(selectedProjectile);
                    break;
                }

                UsedObjects.Enqueue(selectedProjectile);
            }
        }
    }
}