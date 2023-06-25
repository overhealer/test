using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class GameplayState : State, IUpdateState
    {
        private AssetProvider _assetProvider;
        private GameConfig _gameConfig;
        private MainUI _mainUI;

        private Level _currentLevel;
        private PlayerShip _player;

        public GameplayState(AssetProvider assetProvider, GameConfig gameConfig, MainUI ui)
        {
            _assetProvider = assetProvider;
            _gameConfig = gameConfig;
            _mainUI = ui;
        }

        public void Enter()
        {
            InitLevel();
            InitPlayer();
            _mainUI.DisableAllPanels();
            _mainUI.EnablePanel<HUDPanel>();
        }

        public void Exit()
        {
            
        }

        void IUpdateState.Update()
        {
            _player.UpdatePlayer();
            _currentLevel.UpdateLevel();
        }

        private void InitLevel()
        {
            _currentLevel = GameObject.Instantiate(_assetProvider.LevelDatabase.Levels[0]);
            _currentLevel.InitLevel(_gameConfig, _assetProvider);
        }

        private void InitPlayer()
        {
            _player = GameObject.Instantiate(_assetProvider.PlayerPrefab);
            _player.Init(ServiceContainer.Instance.Get<InputService>(), Camera.main, _gameConfig, _assetProvider, _mainUI);
        }
    }
}
