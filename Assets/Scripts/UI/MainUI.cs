using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class MainUI : MonoBehaviour
    {
        public Joystick MovementJoystick => _movementJoystick;
        [SerializeField] private Joystick _movementJoystick;
    }
}
