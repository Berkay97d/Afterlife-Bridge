using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class DownDasher : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _defaultMass;
        [SerializeField] private float _dashMass;
        
        
        private CustomInput m_customInput;
        

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
            if (Player.GetPlayerGroundCheck().CheckIsGrounded() && Math.Abs(_rb.mass - _defaultMass) > 0.1f)
            {
                _rb.mass = _defaultMass;
            }
        }
        
        private void OnDownStarted(InputAction.CallbackContext obj)
        {
            Debug.Log("SELAM");
            if (Player.GetPlayerGroundCheck().CheckIsGrounded()) return;

            _rb.mass = _dashMass;
        }
        
        private void OnDownCanceled(InputAction.CallbackContext obj)
        {
            _rb.mass = _defaultMass;
        }
    }
}