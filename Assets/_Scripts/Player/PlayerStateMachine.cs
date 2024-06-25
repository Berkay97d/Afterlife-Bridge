using System;
using UnityEngine;

namespace _Scripts
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerState m_playerState;

        private void Awake()
        {
            SetPlayerState(PlayerState.Idle);
        }

        private void Update()
        {
            if (!Player.GetPlayerGroundCheck().CheckIsGrounded() && m_playerState != PlayerState.Jump)
            {
                SetPlayerState(PlayerState.Jump);
                return;
            }

            if (Mathf.Abs(Player.GetPlayerMovement().GetDirection()) > 0.5 && m_playerState != PlayerState.Walk)
            {
                SetPlayerState(PlayerState.Walk);
                return;
            }

            if (m_playerState != PlayerState.Idle)
            {
                SetPlayerState(PlayerState.Idle);
                return;
            }
        }

        private void SetPlayerState(PlayerState playerState)
        {
            m_playerState = playerState;
        }

        public PlayerState GetPlayerState()
        {
            return m_playerState;
        }
    }
}