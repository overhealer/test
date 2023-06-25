using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    [CreateAssetMenu(menuName = "Configs/Game Config")]
    public class GameConfig : ScriptableObject
    {
        public float PlayerMoveSpeed;
        public float PlayerAttackSpeed;
        public float CameraHeight = 150f;
    }
}
