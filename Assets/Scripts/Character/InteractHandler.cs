using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    public class InteractHandler
    {
        [SerializeField] private LayerMask _raycastLayerMask = 1;
        [SerializeField] private Transform _raycastOrigin = null;
        [SerializeField] private float _raycastDistance = 2;

        public bool Interact(MoveDirection raycastDirection)
        {
            var origin = _raycastOrigin.position;
            var direction = raycastDirection.AsVector2();
            
            var hits = Physics2D.RaycastAll(_raycastOrigin.position, direction, _raycastDistance, _raycastLayerMask);

            Debug.DrawRay(origin, direction * _raycastDistance, Color.green, 1);

            foreach (var hit in hits)
            {
                var interactable = hit.collider.gameObject.GetComponent<Interactable>();

                if (interactable == null)
                    continue;
            
                interactable.InteractAction.Do();
                return true;
            }
            
            return false;
        }
    }
}