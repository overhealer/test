using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    [CreateAssetMenu(menuName = "Configs/Asset Provider")]
    public class AssetProvider : ScriptableObject
    {
        public LevelDatabase LevelDatabase;

        public PlayerShip PlayerPrefab;
        public Projectile PlayerProjectile;

        public DestructableObject[] DestructableObjects;
    }
}
