using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField] private Blaster[] _shipBlasters;
        private float _attackSpeedTimer;
        private float _attackSpeed;

        private Camera _playerCamera;
        private MainUI _mainUI;
        private HUDPanel _hudPanel;

        private InputService _inputService;
        private Vector3 _prevMoveInput;
        private Vector3 _clampedInput;
        private Vector3 _worldMovePosition;
        private float _moveSpeed;
        private float _halfScreenHeight;

        private bool _isAlive = true;

        private int _asteroidsDestroyed;

        public void Init(InputService input, Camera playerCamera, GameConfig config, AssetProvider assetProvider, MainUI ui)
        {
            _inputService = input;
            _mainUI = ui;
            _hudPanel = _mainUI.GetPanel<HUDPanel>();
            _playerCamera = playerCamera;
            _moveSpeed = config.PlayerMoveSpeed;
            _halfScreenHeight = Screen.height / 2;
            _attackSpeed = config.PlayerAttackSpeed;

            for (int i = 0; i < _shipBlasters.Length; i++)
            {
                _shipBlasters[i].Init(assetProvider);
                _shipBlasters[i].OnTargetDestroy += IterateAsteroidsDestroyed;
            }

            _hudPanel.UpdatePointsText(_asteroidsDestroyed);
        }

        public void UpdatePlayer()
        {
            if (!_isAlive)
                return;

            Movement();
            Shooting();
        }

        public void Movement()
        {
            //clamp on bottom half of screen
            _clampedInput = new Vector3(
                _inputService.MousePosition.x,
                Mathf.Clamp(_inputService.MousePosition.y, 0, _halfScreenHeight),
                150);

            
            _worldMovePosition = _playerCamera.ScreenToWorldPoint(_clampedInput);
            _worldMovePosition.y = transform.position.y;


            transform.position = Vector3.Lerp(transform.position, 
                _worldMovePosition, _moveSpeed * Time.deltaTime);
        }

        public void Shooting()
        {
            _attackSpeedTimer += Time.deltaTime;
            if(_attackSpeedTimer >= _attackSpeed)
            {
                _attackSpeedTimer = 0;

                for (int i = 0; i < _shipBlasters.Length; i++)
                {
                    _shipBlasters[i].Shoot();
                }
            }

            for (int i = 0; i < _shipBlasters.Length; i++)
            {
                _shipBlasters[i].UpdateActiveProjectiles();
            }
        }

        public void OnImpact()
        {
            if(!_isAlive)
            {
                return;
            }

            _isAlive = false;

            _mainUI.EnablePanel<GameOverPanel>();
        }

        private void IterateAsteroidsDestroyed()
        {
            _asteroidsDestroyed++;
            _hudPanel.UpdatePointsText(_asteroidsDestroyed);
        }
    }
}
