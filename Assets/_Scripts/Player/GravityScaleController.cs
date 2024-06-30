using System;
using UnityEngine;

namespace _Scripts
{
    public class GravityScaleController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _defaultGravityScale;

        private float _targetGravityScale;
        private int _priority;

        private void Awake()
        {
            _targetGravityScale = _defaultGravityScale;
            _priority = 0;
        }

        private void FixedUpdate()
        {
            _rb.gravityScale = _targetGravityScale;
            
            if (Player.GetPlayerGroundCheck().CheckIsNotGrounded() && !Player.GetPlayerTeleportStarter().GetIsTeleporting() && _rb.velocity.y < -0.05 && Math.Abs(_rb.gravityScale - _defaultGravityScale) > 0.01f && !Player.GetDownDasher().GetIsDownDashing())
            {
              SetGravityScale(_defaultGravityScale, 1);   
            }
        }

        public void SetGravityScale(float gravityScale, int priority)
        {
            if (priority >= _priority)
            {
                _targetGravityScale = gravityScale;
                _priority = priority;
            }
        }

        public void ResetGravityScale(int priority)
        {
            if (priority >= _priority)
            {
                _targetGravityScale = _defaultGravityScale;
                _priority = 0;
            }
        }

        public void SetVelocity(Vector2 vel)
        {
            _rb.velocity = vel;
        }
    }
}