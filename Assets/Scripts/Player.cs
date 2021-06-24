using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        public float MoveSpeed = 2;
        
        // Set in Awake()
        private Rigidbody2D _rigidbody;
        private GameControls _controls;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
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

        private void FixedUpdate()
        {
            var _moveInput = _controls.Player.Movement.ReadValue<Vector2>();
            
            if (_moveInput == Vector2.zero)
                return;
            
            var moveDelta = MoveSpeed * Time.fixedDeltaTime * _moveInput;
            
            _rigidbody.MovePosition(_rigidbody.position + moveDelta);
        }
    }
}