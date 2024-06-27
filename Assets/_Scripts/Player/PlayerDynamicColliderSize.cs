using System;
using UnityEngine;

namespace _Scripts
{
    public class PlayerDynamicColliderSize : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider2D _collider;
        
        private const float m_defaultOffsetY = 0.07450989f;
        private const float m_defaultSizeY = 0.1497634f;
        private const float m_jumpingOffsetY = 0.08518216f;
        private const float m_jumpingSizeY = 0.1284189f;

        private void Start()
        {
            Player.GetPlayerStateMachine().OnPlayerStateChanged += OnPlayerStateChanged;
        }

        private void OnDestroy()
        {
            Player.GetPlayerStateMachine().OnPlayerStateChanged -= OnPlayerStateChanged;
        }

        private void OnPlayerStateChanged(PlayerState state)
        {
            if (state == PlayerState.Jump)
            {
                _collider.size = new Vector2(_collider.size.x,m_jumpingSizeY);
                _collider.offset = new Vector2(_collider.offset.x, m_jumpingOffsetY);
                return;
            }

            if (state == PlayerState.Idle || state == PlayerState.Walk)
            {
                _collider.size = new Vector2(_collider.size.x,m_defaultSizeY);
                _collider.offset = new Vector2(_collider.offset.x, m_defaultOffsetY);
            }
        }
    }
}