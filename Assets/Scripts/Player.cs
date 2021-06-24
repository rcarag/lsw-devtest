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
            HandleMoveInput();
            HandlePlayerActions();
        }

        private void HandlePlayerActions()
        {
            if (HandleOpenInventoryAction())
                return;

            if (HandleInteractAction())
                return;
        }

        private bool HandleInteractAction()
        {
            if (!_controls.Player.Interact.triggered)
                return false;
            
            Debug.Log("interact");
            return true;
        }

        private bool HandleOpenInventoryAction()
        {
            if (!_controls.Player.OpenInventory.triggered)
                return false;

            Debug.Log("open inventory");
            return true;
        }

        private void HandleMoveInput()
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