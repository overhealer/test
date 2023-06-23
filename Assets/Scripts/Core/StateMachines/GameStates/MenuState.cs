using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoolNamespace
{
    public class MenuState : State, IState
    {
        private GameStateMachine _gameStateMachine;
        public MenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            LoadLevelPayload payload = new LoadLevelPayload("Game", () => _gameStateMachine.Enter<GameplayState>());
            _gameStateMachine.Enter<LoadLevelState, LoadLevelPayload>(payload);
        }

        public void Exit()
        {
            
        }
    }
}
