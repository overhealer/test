using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class GameBootstrapState : State, IState
    {
        private StateMachine _gameStateMachine;
        private AssetProvider _assetProvider;
        private MainUI _mainUI;
        private GameConfig _gameConfig;

        public GameBootstrapState(AssetProvider assetProvider, MainUI ui, GameStateMachine i_GameStateMachine, GameConfig i_gameConfig)
        {
            _gameStateMachine = i_GameStateMachine;
            _assetProvider = assetProvider;
            _mainUI = ui;
            _gameConfig = i_gameConfig;
        }

        public void Enter()
        {
            SetupServices();
            LoadLevelPayload payload = new LoadLevelPayload("Menu", () => _gameStateMachine.Enter<MenuState>());
            _gameStateMachine.Enter<LoadLevelState, LoadLevelPayload>(payload);
        }

        public void Exit()
        {

        }

        public void SetupServices()
        {
            InputService inputService = new MobileInputService(_mainUI);

            ServiceContainer.Instance.Set(inputService);
        }
    }
}