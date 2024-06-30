using System;
using System.Collections;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class PlayerTeleportStarter : MonoBehaviour
    {
        [SerializeField] private PlayerTeleportVisual _teleportVisual;
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private float _teleportCoolDown;
        [SerializeField] private Transform _teleportPosition;
        [SerializeField] private float _shakeStrength;
        [SerializeField] private int _vibrato;
        [SerializeField] private float _randomness;
        
        
        
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
            Player.GetGravityScaleController().SetVelocity(Vector2.zero);
            _rotateTransform.DOShakePosition(1f, _shakeStrength, _vibrato, _randomness);
            m_teleportCenter = _teleportVisual.SpawnFromZero(transform.position, () =>
            {
                StartCoroutine(GoTeleportCenter());
            });
        }
        
        private IEnumerator GoTeleportCenter()
        {
            var rotateTween = _rotateTransform.DORotate(new Vector3(0, 0, 359), 1000f).SetLoops(-1, LoopType.Incremental).SetSpeedBased();
            yield return new WaitForSeconds(0.5f);
            transform.DOMove(m_teleportCenter, .3f).SetEase(Ease.OutQuint).OnComplete(() =>
            {
                rotateTween.Kill();
                StartCoroutine(_teleportVisual.ReturnZero(OnTeleportCompleted));
            });
            transform.DOScale(Vector3.zero, .3f);
        }

        private void OnTeleportCompleted()
        {
            _rotateTransform.rotation = Quaternion.Euler(Vector3.zero);
            transform.position = _teleportPosition.position;
            transform.localScale = Vector3.one;

            m_isPlayerTeleporting = false;
            Player.GetGravityScaleController().ResetGravityScale(GravityManipulationPriority);
        }

        public bool GetIsTeleporting()
        {
            return m_isPlayerTeleporting;
        }
    }
}