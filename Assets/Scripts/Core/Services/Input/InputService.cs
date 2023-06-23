using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class InputService : IService
    {
        public virtual Vector3 MousePosition => Input.mousePosition;

        public InputService()
        {

        }
    }
}
