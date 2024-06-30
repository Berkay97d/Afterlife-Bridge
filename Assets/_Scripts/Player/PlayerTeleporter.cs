using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class PlayerTeleporter : MonoBehaviour
    {
        [SerializeField] private PlayerTeleportVisual _teleportVisual;
        [SerializeField] private float _teleportCoolDown;
        [SerializeField] private Transform _teleportPosition;
        
        private const int GravityManipulationPriority = 3;
        private CustomInput m_customInput;


        private void Awake()
        {
            m_customInput = new CustomInput();
        }

        private void OnEnable()
        {
            m_customInput.Enable();
            m_customInput.Player.Teleport.started += OnTeleportStarted;
        }

        private void OnDisable()
        {
            m_customInput.Disable();
            m_customInput.Player.Teleport.started -= OnTeleportStarted;
        }

        private void OnTeleportStarted(InputAction.CallbackContext obj)
        {
            _teleportVisual.SpawnFromZero(transform.position);
        }
    }
}