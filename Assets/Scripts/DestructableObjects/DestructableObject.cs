using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class DestructableObject : PoolObject, IDamagable
    {
        public Action<DestructableObject> OnObjectDestroyed;

        private float _health;

        public void UpdateMove()
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.back, 0.15f);

            if(transform.position.z >= 100f)
            {
                DestroyObject();
            }
        }

        public void DestroyObject()
        {
            OnObjectDestroyed.Invoke(this);
        }

        public void Damage(float damageAmount)
        {
            if (_health <= 0)
                return;

            _health -= damageAmount;
            if(_health <= 0)
                DestroyObject();
        }

        public override void ToPool()
        {
            base.ToPool();
        }

        public override void FromPool(Vector3 position)
        {
            base.FromPool(position);
        }
    }
}
