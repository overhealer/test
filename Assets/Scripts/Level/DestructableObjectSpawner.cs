using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class DestructableObjectSpawner
    {
        private Vector3 _offscreenPosition;
        private float _rightBorder;
        private float _spawnTimer;

        private ObjectPool<DestructableObject> _objectPool;

        public DestructableObjectSpawner(Camera playerCamera, GameConfig config, AssetProvider assetProvider, Transform objectContainer)
        {
            _offscreenPosition = playerCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, config.CameraHeight));
            _offscreenPosition.z -= 100f;
            _rightBorder = playerCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, config.CameraHeight)).x;

            _objectPool = new ObjectPool<DestructableObject>(assetProvider.DestructableObjects, objectContainer, 30);
            for (int i = 0; i < _objectPool.PooledObjects.Count; i++)
            {
                (_objectPool.PooledObjects[i] as DestructableObject).OnObjectDestroyed +=
                    (desObj) => _objectPool.ReturnToPool(desObj);
            }

            _spawnTimer = 2f;
        }

        public void SpawnRandomObject()
        {
            //Debug.Log(_offscreenPosition + " | " + _rightBorder);
            _objectPool.TakeFromPool(new Vector3(Random.Range(_offscreenPosition.x, _rightBorder), 0, _offscreenPosition.z));
        }

        public void UpdateSpawner()
        {
            for (int i = 0; i < _objectPool.ActiveObjects.Count; i++)
            {
                _objectPool.ActiveObjects[i].UpdateMove();
            }

            _spawnTimer -= Time.deltaTime;
            if(_spawnTimer <= 0)
            {
                _spawnTimer = Random.Range(0.25f, 2.5f);
                SpawnRandomObject();
            }
        }
    }
}
