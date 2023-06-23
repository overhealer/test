using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoolNamespace
{
    public class Player : MonoBehaviour
    {
        private Camera _playerCamera;
        private InputService _inputService;
        private Vector3 _prevMoveInput;
        private Vector3 _clampedInput;
        private Vector3 _worldMovePosition;

        private float _moveSpeed;
        private float _halfScreenHeight;

        public void Init(InputService input, Camera playerCamera, GameConfig config)
        {
            _inputService = input;
            _playerCamera = playerCamera;
            _moveSpeed = config.PlayerMoveSpeed;
            _halfScreenHeight = Screen.height / 2;
        }

        public void UpdatePlayer()
        {
            Movement();
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
    }
}
