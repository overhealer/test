using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class Asteroid : DestructableObject
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent(out PlayerShip ship))
            {
                ship.OnImpact();
            }
        }
    }
}
