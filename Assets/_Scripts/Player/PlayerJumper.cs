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
        private bool m_isJumpingButtonPressed;

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
            if(!Player.GetPlayerGroundCheck().CheckIsGrounded()) return;
            
            m_isJumpingButtonPressed = true;
            Jump();
        }
        
        private void OnJumpCanceled(InputAction.CallbackContext context)
        {
            m_isJumpingButtonPressed = false;
        }
        
        private void Jump()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }
    }
}