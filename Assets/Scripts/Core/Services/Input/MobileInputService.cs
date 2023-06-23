using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class MobileInputService : InputService
    {
        public override Vector3 MousePosition => Input.mousePosition;

        private Joystick _movementJoystick;

        public MobileInputService(MainUI ui)
        {
            _movementJoystick = ui.MovementJoystick;
        }
    }
}
