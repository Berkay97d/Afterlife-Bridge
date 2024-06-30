using System;
using System.Collections;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class PlayerTeleporter : MonoBehaviour
    {
        [SerializeField] private PlayerTeleportVisual _teleportVisual;
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private float _teleportCoolDown;
        [SerializeField] private Transform _teleportPosition;
        
        private const int GravityManipulationPriority = 3;
        private CustomInput m_customInput;
        private Vector3 m_teleportCenter;
        private bool m_isPlayerTeleporting;


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
            m_isPlayerTeleporting = true;
            Player.GetGravityScaleController().SetGravityScale(0, GravityManipulationPriority);
            m_teleportCenter = _teleportVisual.SpawnFromZero(transform.position, () =>
            {
                StartCoroutine(GoTeleportCenter());
                Player.GetGravityScaleController().SetVelocity(Vector2.zero);
            });
        }

        private IEnumerator GoTeleportCenter()
        {
            _rotateTransform.DORotate(new Vector3(0, 0, 359), 1000f).SetLoops(-1, LoopType.Incremental).SetSpeedBased();
            yield return new WaitForSeconds(0.5f);
            transform.DOMove(m_teleportCenter, .3f).SetEase(Ease.OutQuint).OnComplete(() =>
            {
                StartCoroutine(_teleportVisual.ReturnZero());
            });
            transform.DOScale(Vector3.zero, .3f);
        }

        public bool GetIsTeleporting()
        {
            return m_isPlayerTeleporting;
        }
    }
}