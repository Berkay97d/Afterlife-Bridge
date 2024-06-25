using System;
using UnityEngine;

namespace _Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private SpriteRenderer _playerRenderer;
        [SerializeField] private Sprite _jumpSprite;
        
        
        private void Start()
        {
            Player.GetPlayerStateMachine().OnPlayerStateChanged += OnPlayerStateChanged;
        }

        private void OnDestroy()
        {
            Player.GetPlayerStateMachine().OnPlayerStateChanged -= OnPlayerStateChanged;
        }

        private void OnPlayerStateChanged(PlayerState playerState)
        {
            ChangePlayerAnimation(playerState);
        }

        private void ChangePlayerAnimation(PlayerState playerState)
        {
            switch (playerState)
            {
                case PlayerState.Idle:
                    _playerAnimator.enabled = true;
                    _playerAnimator.SetBool("isIdle", true);
                    _playerAnimator.SetBool("isWalk", false);
                    _playerAnimator.SetBool("isJump", false);
                    break;
                case PlayerState.Walk:
                    _playerAnimator.enabled = true;
                    _playerAnimator.SetBool("isIdle", false);
                    _playerAnimator.SetBool("isWalk", true);
                    _playerAnimator.SetBool("isJump", false);
                    break;
                case PlayerState.Jump:
                    _playerAnimator.SetBool("isIdle", false);
                    _playerAnimator.SetBool("isWalk", false);
                    _playerAnimator.SetBool("isJump", true);
                    _playerAnimator.enabled = false;
                    _playerRenderer.sprite = _jumpSprite;
                    break;
            }
        }
        
    }
}