using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class GameStateMachine : UpdateStateMachine
    {
        public GameStateMachine(AssetProvider assetProvider, MainUI ui, GameConfig gameConfig)
        {
            _states = new Dictionary<System.Type, IExitableState>()
            {
                [typeof(GameBootstrapState)] = new GameBootstrapState(assetProvider, ui, this, gameConfig),
                [typeof(LoadLevelState)] = new LoadLevelState(this),
                [typeof(MenuState)] = new MenuState(this),
                [typeof(GameplayState)] = new GameplayState(assetProvider, gameConfig),
            };
        }
    }
}