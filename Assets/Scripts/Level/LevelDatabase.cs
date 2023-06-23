using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    [CreateAssetMenu(menuName = "Configs/Level Database")]
    public class LevelDatabase : ScriptableObject
    {
        public Level[] Levels;
    }
}
