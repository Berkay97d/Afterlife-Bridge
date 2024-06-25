using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _rb;
        
        private Vector2 m_movementVector;
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
            _rb.velocity = m_movementVector * _moveSpeed;
        }
        
        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            m_movementVector = context.ReadValue<Vector2>();
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            m_movementVector = Vector2.zero;
        }
    }
}