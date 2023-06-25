using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class Projectile : PoolObject
    {
        public Action<Projectile, bool> OnHit; 
        [SerializeField] private float _damageAmount;
        [SerializeField] private float _flightSpeed;

        public void Move(Vector3 direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - direction, _flightSpeed);

            if (transform.position.z <= -250f)
            {
                OnHit?.Invoke(this, true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IDamagable damagable))
            {
                damagable.Damage(_damageAmount);
                OnHit?.Invoke(this, damagable.IsAlive);
            }
        }
    }
}
