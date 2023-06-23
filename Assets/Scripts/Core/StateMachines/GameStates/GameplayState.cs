using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class GameplayState : State, IUpdateState
    {
        private AssetProvider _assetProvider;
        private GameConfig _gameConfig;

        private Level _currentLevel;
        private Player _player;

        public GameplayState(AssetProvider assetProvider, GameConfig gameConfig)
        {
            _assetProvider = assetProvider;
            _gameConfig = gameConfig;
        }

        public void Enter()
        {
            InitLevel();
            InitPlayer();
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
            _player.Init(ServiceContainer.Instance.Get<InputService>(), Camera.main, _gameConfig);
        }
    }
}
