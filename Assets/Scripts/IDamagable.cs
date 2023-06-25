using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public interface IDamagable
    {
        public bool IsAlive { get; }

        public void Damage(float damageAmount);
    }
}
