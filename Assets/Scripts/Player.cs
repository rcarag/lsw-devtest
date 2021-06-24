using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TopDownCharacterController))]
    public class Player : MonoBehaviour
    {
        // Set in Awake()
        private GameControls _controls;
        private TopDownCharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<TopDownCharacterController>();
            _controls = new GameControls();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            var _moveInput = _controls.Player.Movement.ReadValue<Vector2>();

            if (_moveInput == Vector2.zero)
                _controller.MoveDirection = MoveDirection.None;
            else if (_moveInput.y < 0)
                _controller.MoveDirection = MoveDirection.Down;
            else if (_moveInput.y > 0)
                _controller.MoveDirection = MoveDirection.Up;
            else if (_moveInput.x < 0)
                _controller.MoveDirection = MoveDirection.Left;
            else if (_moveInput.x > 0)
                _controller.MoveDirection = MoveDirection.Right;
        }
    }
}