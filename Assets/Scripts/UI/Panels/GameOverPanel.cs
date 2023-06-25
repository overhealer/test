using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoolNamespace
{
    public class GameOverPanel : UIPanel
    {
        [SerializeField] private Button _restartButton;

        public override void InitPanel(GameStateMachine stateMachine)
        {
            base.InitPanel(stateMachine);
            LoadLevelPayload payload = new LoadLevelPayload("Game", () => stateMachine.Enter<GameplayState>());
            _restartButton.onClick.AddListener(() => stateMachine.Enter<LoadLevelState, LoadLevelPayload>(payload));
        }
    }
}
