using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private AssetProvider _assetProvider;
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private MainUI _mainUI;

        private Game _gameInstance;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            MainUI ui = Instantiate(_mainUI, transform);
            _gameInstance = new Game(_assetProvider, ui, _gameConfig);
        }

        private void Update()
        {
            _gameInstance.OnUpdate();
        }
    }
}
