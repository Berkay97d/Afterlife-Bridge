using System;
using UnityEngine;

namespace _Scripts
{
    public class PlayerGroundCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Vector2 _boxSize;
        [SerializeField] private Transform _feetTransform;
        [SerializeField] private float _distance;

        
        
        public bool CheckIsGrounded()
        {
            var hit = Physics2D.BoxCast(_feetTransform.position, _boxSize, 0f, Vector2.down, _distance, _groundLayer);

            return hit.collider != null;
        }

        // WRITTEN FOR JUST USE in COROUTINE's WAIT UNTIL
        public bool CheckIsNotGrounded()
        {
            return !CheckIsGrounded();
        }

        private void OnDrawGizmos()
        {
            if (CheckIsGrounded())
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            
            Gizmos.DrawWireCube(_feetTransform.position - Vector3.down*_distance, _boxSize);
        }
    }
}