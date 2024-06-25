using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class PlayerJumper : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _jumpPower;
        
        private CustomInput m_customInput;
        private bool m_isJumping;

        private void Awake()
        {
            m_customInput = new CustomInput();
        }
        
        private void OnEnable()
        {
            m_customInput.Enable();
            m_customInput.Player.Jump.started += OnJumpStarted;
            m_customInput.Player.Jump.canceled += OnJumpCanceled;
        }
        
        private void OnDisable()
        {
            m_customInput.Disable();
            m_customInput.Player.Jump.started -= OnJumpStarted;
            m_customInput.Player.Jump.canceled -= OnJumpCanceled;
        }
        
        private void OnJumpStarted(InputAction.CallbackContext context)
        {
            m_isJumping = true;
            Jump();
        }
        
        private void OnJumpCanceled(InputAction.CallbackContext context)
        {
            m_isJumping = false;
        }

        private void Update()
        {
            if (m_isJumping)
            {
                
            }
        }

        private void Jump()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }
    }
}