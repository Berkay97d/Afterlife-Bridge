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
        

        

        private void Update()
        {
            Debug.Log(CheckIsGrounded());
        }

        private bool CheckIsGrounded()
        {
            var hit = Physics2D.BoxCast(_feetTransform.position, _boxSize, 0f, Vector2.down, _distance, _groundLayer);

            return hit.collider != null;
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