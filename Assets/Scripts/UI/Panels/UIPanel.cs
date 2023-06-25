using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class UIPanel : MonoBehaviour, IPanel
    {
        protected GameStateMachine _stateMachine;

        public virtual void InitPanel(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void EnablePanel()
        {
            gameObject.SetActive(true);
        }

        public virtual void DisablePanel()
        {
            gameObject.SetActive(false);
        }
    }
}