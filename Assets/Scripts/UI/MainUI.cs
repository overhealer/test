using SimpleInputNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

namespace CoolNamespace
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private Canvas m_InputCanvas;
        private Dictionary<Type, UIPanel> m_Panels = new Dictionary<Type, UIPanel>();

        public void InitPanels(GameStateMachine stateMachine)
        {
            UIPanel[] panels = GetComponentsInChildren<UIPanel>(true);
            for (int i = 0; i < panels.Length; i++)
            {
                m_Panels.Add(panels[i].GetType(), panels[i]);
                panels[i].InitPanel(stateMachine);
            }
        }

        public TPanel GetPanel<TPanel>() where TPanel : class, IPanel
        {
            return m_Panels[typeof(TPanel)] as TPanel;
        }

        public void EnablePanel<TPanel>()
        {
            DisableAllPanels();
            m_Panels[typeof(TPanel)].EnablePanel();
        }

        public void DisablePanel<TPanel>()
        {
            m_Panels[typeof(TPanel)].DisablePanel();
        }

        public void DisableAllPanels()
        {
            foreach (var panel in m_Panels)
            {
                panel.Value.DisablePanel();
            }
        }
    }


}
