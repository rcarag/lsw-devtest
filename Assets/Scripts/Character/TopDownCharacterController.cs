using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TopDownCharacterController : MonoBehaviour
    {
        public float MoveSpeed = 1;
        public MoveDirection MoveDirection = MoveDirection.None;
        
        // Set in Awake()
        private Rigidbody2D _rigidbody = null;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var _moveDirection = MoveDirection.AsVector2();
            
            if (_moveDirection == Vector2.zero)
                return;
            
            var moveDelta = MoveSpeed * Time.fixedDeltaTime * _moveDirection;
            
            _rigidbody.MovePosition(_rigidbody.position + moveDelta);
        }
        
        private MoveDirection _previousMoveDirection;
    }
}