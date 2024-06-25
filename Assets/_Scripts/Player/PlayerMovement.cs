using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _groundMoveSpeed;
        [SerializeField] private float _airMoveSpeed;
        [SerializeField] private Rigidbody2D _rb;

        private float m_currentMoveSpeed;
        private float m_movementDirection;
        private CustomInput m_customInput;


        private void Awake()
        {
            m_customInput = new CustomInput();
        }

        private void OnEnable()
        {
            m_customInput.Enable();
            m_customInput.Player.Movement.performed += OnMovementPerformed;
            m_customInput.Player.Movement.canceled += OnMovementCanceled;
        }
        
        private void OnDisable()
        {
            m_customInput.Disable();
            m_customInput.Player.Movement.performed -= OnMovementPerformed;
            m_customInput.Player.Movement.canceled -= OnMovementCanceled;
        }

        private void FixedUpdate()
        {
            if (!Player.GetPlayerGroundCheck().CheckIsGrounded())
            {
                m_currentMoveSpeed = _airMoveSpeed;
                _rb.velocity = new Vector2( m_currentMoveSpeed * m_movementDirection, _rb.velocity.y);
                return;
            }
            
            m_currentMoveSpeed = _groundMoveSpeed;
            _rb.velocity = new Vector2( m_currentMoveSpeed * m_movementDirection, _rb.velocity.y);
        }
        
        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            m_movementDirection = context.ReadValue<Vector2>().x;
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            m_movementDirection = 0f;
        }

        public float GetDirection()
        {
            return m_movementDirection;
        }
    }
}