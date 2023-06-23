using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class Game
    {
        private GameStateMachine _gameStateMachine;

        public Game(AssetProvider assetProvider, MainUI ui, GameConfig gameConfig)
        {
            _gameStateMachine = new GameStateMachine(assetProvider, ui, gameConfig);
            _gameStateMachine.Enter<GameBootstrapState>();
        }

        public void OnUpdate()
        {
            _gameStateMachine.UpdateState();
        }
    }
}
