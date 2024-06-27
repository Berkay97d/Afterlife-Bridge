using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class DownDasher : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _defaultGravityScale;
        [SerializeField] private float _dashGravityScale;
        
        
        private CustomInput m_customInput;
        private bool isDownDashing;
        

        private void Awake()
        {
            m_customInput = new CustomInput();
        }
        
        private void OnEnable()
        {
            m_customInput.Enable();
            m_customInput.Player.Down.started += OnDownStarted;
            m_customInput.Player.Down.canceled += OnDownCanceled;
        }

        private void OnDisable()
        {
            m_customInput.Disable();
            m_customInput.Player.Down.started -= OnDownStarted;
            m_customInput.Player.Down.canceled -= OnDownCanceled;
        }
        
        private void FixedUpdate()
        {
            if (Player.GetPlayerGroundCheck().CheckIsGrounded() && Math.Abs(_rb.mass - _defaultGravityScale) > 0.1f)
            {
                _rb.gravityScale = _defaultGravityScale;
            }
        }
        
        private void OnDownStarted(InputAction.CallbackContext obj)
        {
            Debug.Log("SELAM");
            if (Player.GetPlayerGroundCheck().CheckIsGrounded()) return;

            isDownDashing = true;
            _rb.gravityScale = _dashGravityScale;
        }
        
        private void OnDownCanceled(InputAction.CallbackContext obj)
        {
            isDownDashing = false;
            _rb.gravityScale = _defaultGravityScale;
        }

        public bool GetIsDownDashing()
        {
            return isDownDashing;
        }
    }
}