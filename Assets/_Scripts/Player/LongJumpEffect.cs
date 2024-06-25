using System;
using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class LongJumpEffect : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _defaultGravityScale;
        [SerializeField] private float _longJumpGravityScale;
        
        
        private void Start()
        {
            Player.GetPlayerJumper().OnJumpStartPerform += OnJumpStartPerform;
            Player.GetPlayerJumper().OnJumpStopPerform += OnJumpStopPerform;
        }
        
        private void OnDestroy()
        {
            Player.GetPlayerJumper().OnJumpStartPerform -= OnJumpStartPerform;
            Player.GetPlayerJumper().OnJumpStopPerform -= OnJumpStopPerform;
        }

        private void FixedUpdate()
        {
            if (Player.GetPlayerGroundCheck().CheckIsGrounded() && Math.Abs(_rb.gravityScale - _defaultGravityScale) > 0.1f)
            {
                _rb.gravityScale = _defaultGravityScale;
            }
        }

        private void OnJumpStartPerform()
        {
            StartCoroutine(LongJumpEnumerator());
            
            IEnumerator LongJumpEnumerator()
            {
                yield return new WaitUntil(Player.GetPlayerGroundCheck().CheckIsNotGrounded);
                _rb.gravityScale = _longJumpGravityScale;
                yield break;
            }
        }
        
        private void OnJumpStopPerform()
        {
            _rb.gravityScale = _defaultGravityScale;
        }
    }
}