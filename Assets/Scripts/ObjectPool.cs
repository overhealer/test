using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class ObjectPool<TPoolObject>
    {
        public List<TPoolObject> PooledObjects, ActiveObjects;

        public ObjectPool(TPoolObject[] poolObject, Transform container, int poolLength)
        {
            PooledObjects = new List<TPoolObject>(poolLength);
            ActiveObjects = new List<TPoolObject>();

            for (int i = 0; i < 30; i++)
            {
                PoolObject o = GameObject.Instantiate(poolObject[Random.Range(0, poolObject.Length)] as PoolObject, container);

                o.gameObject.SetActive(false);
                PooledObjects.Add((TPoolObject)(object)o);
            }
        }

        public TPoolObject TakeFromPool(Vector3 pos)
        {
            TPoolObject poolObject = PooledObjects[0];
            PooledObjects.Remove(poolObject);
            ActiveObjects.Add(poolObject);
            (poolObject as PoolObject).FromPool(pos);
            return poolObject;
        }

        public void ReturnToPool(TPoolObject poolObject)
        {
            ActiveObjects.Remove(poolObject);
            PooledObjects.Add(poolObject);
            (poolObject as PoolObject).ToPool();
        }
    }
}
