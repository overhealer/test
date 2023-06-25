using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class Blaster : MonoBehaviour
    {
        public Action OnTargetDestroy;
        [SerializeField] private Transform _muzzle;
        private ObjectPool<Projectile> _projectilePool;

        public void Init(AssetProvider assetProvider)
        {
            _projectilePool = new ObjectPool<Projectile>(assetProvider.PlayerProjectile, 30);
            for (int i = 0; i < _projectilePool.PooledObjects.Count; i++)
            {
                _projectilePool.PooledObjects[i].OnHit += OnProjectileHit;
            }
        }

        public void Shoot()
        {
            _projectilePool.TakeFromPool(_muzzle.position);
        }

        public void UpdateActiveProjectiles()
        {
            for (int i = 0; i < _projectilePool.ActiveObjects.Count; i++)
            {
                _projectilePool.ActiveObjects[i].Move(transform.forward);
            }
        }

        private void OnProjectileHit(Projectile projectile, bool isTargetAlive)
        {
            _projectilePool.ReturnToPool(projectile);
            if(!isTargetAlive)
                OnTargetDestroy?.Invoke();
        }
    }
}
