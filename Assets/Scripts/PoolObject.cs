using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace CoolNamespace
{
    public class PoolObject : MonoBehaviour
    {
        public virtual void ToPool()
        {
            gameObject.SetActive(false);
            
        }

        public virtual void FromPool(Vector3 position)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = position;
        }
    }
}
