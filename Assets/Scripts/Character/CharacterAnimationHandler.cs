using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class CharacterAnimationHandler
    {
        [SerializeField] private Animator _animator = null;
        
        public MoveDirection FacingDirection { get; private set; }

        public CharacterAnimationHandler()
        {
            FacingDirection = MoveDirection.Down;
        }

        public void Move(MoveDirection direction)
        {
            if (direction == _lastMoveDirection)
                return;

            _lastMoveDirection = direction;
            
            switch (direction)
            {
            case MoveDirection.None:
                _animator.SetTrigger("Stop");
                break;
            case MoveDirection.Up:
                _animator.SetTrigger("Up");
                FacingDirection = MoveDirection.Up;
                break;
            case MoveDirection.Down:
                _animator.SetTrigger("Down");
                FacingDirection = MoveDirection.Down;
                break;
            case MoveDirection.Left:
                _animator.SetTrigger("Left");
                FacingDirection = MoveDirection.Left;
                break;
            case MoveDirection.Right:
                _animator.SetTrigger("Right");
                FacingDirection = MoveDirection.Right;
                break;
            }
        }
        
        private MoveDirection _lastMoveDirection = MoveDirection.None;
    }
}