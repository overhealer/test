using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class Level : MonoBehaviour
    {
        private DestructableObjectSpawner _objectSpawner;

        public void InitLevel(GameConfig config, AssetProvider assetProvider)
        {
            _objectSpawner = new DestructableObjectSpawner(Camera.main, config, assetProvider, transform);

        }

        public void UpdateLevel()
        {
            _objectSpawner.UpdateSpawner();
        }
    }
}
