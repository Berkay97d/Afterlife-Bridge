using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class DownDasher : MonoBehaviour
    {
        [SerializeField] private float _dashGravityScale;
        
        private CustomInput m_customInput;
        private bool m_isDownDashing;
        private const int GravityManipulationPriority = 2;

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
        
        private void OnDownStarted(InputAction.CallbackContext obj)
        {
            if (Player.GetPlayerGroundCheck().CheckIsGrounded()) return;

            m_isDownDashing = true;
            Player.GetGravityScaleController().SetGravityScale(_dashGravityScale, GravityManipulationPriority);
        }
        
        private void OnDownCanceled(InputAction.CallbackContext obj)
        {
            m_isDownDashing = false;
            Player.GetGravityScaleController().ResetGravityScale(GravityManipulationPriority);
        }

        public bool GetIsDownDashing()
        {
            return m_isDownDashing;
        }
    }
}