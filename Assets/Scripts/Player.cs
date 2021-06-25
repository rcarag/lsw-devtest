using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    [RequireComponent(typeof(TopDownCharacterController))]
    public class Player : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private BoolEvent _inputEnabledChangedEvent = null;
        [SerializeField] VoidEvent _inventoryScreenOpenedEvent = null;

        [Header("Handlers")]
        [SerializeField] private InteractHandler _interactHandler = new InteractHandler();
        [SerializeField] private CharacterAnimationHandler _animationHandler;
        
        // Set in Awake()
        private GameControls _controls;
        private TopDownCharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<TopDownCharacterController>();
            _controls = new GameControls();
            
            _inputEnabledChangedEvent.Register(OnInputEnabledChanged);
        }

        private void OnDestroy()
        {
            _inputEnabledChangedEvent.Unregister(OnInputEnabledChanged);
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
            _controller.MoveDirection = MoveDirection.None;
        }

        private void Update()
        {
            HandleMoveInput();
            
            _animationHandler.Move(_controller.MoveDirection);

            if (HandlePlayerActions())
                _animationHandler.Move(MoveDirection.None);
        }

        private bool HandlePlayerActions()
        {
            if (HandleOpenInventoryAction())
                return true;

            if (HandleInteractAction())
                return true;

            return false;
        }

        private bool HandleInteractAction()
        {
            if (!_controls.Player.Interact.triggered)
                return false;
            
            Debug.Log("interact");

            return _interactHandler.Interact(_animationHandler.FacingDirection);
        }

        private bool HandleOpenInventoryAction()
        {
            if (!_controls.Player.OpenInventory.triggered)
                return false;

            Debug.Log("open inventory");
            _inventoryScreenOpenedEvent.Raise();
            
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

        private void OnInputEnabledChanged(bool enable)
        {
            enabled = enable;
        }
    }
}