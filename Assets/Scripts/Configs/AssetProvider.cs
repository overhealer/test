using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    [CreateAssetMenu(menuName = "Configs/Asset Provider")]
    public class AssetProvider : ScriptableObject
    {
        public LevelDatabase LevelDatabase;

        public Player PlayerPrefab;

        public DestructableObject[] DestructableObjects;
    }
}
