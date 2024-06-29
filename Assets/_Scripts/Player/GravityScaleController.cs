using UnityEngine;

namespace _Scripts
{
    public class GravityScaleController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _defaultGravityScale;

        private float _targetGravityScale;
        private int _priority;

        private void Awake()
        {
            _targetGravityScale = _defaultGravityScale;
            _priority = 0;
        }

        private void FixedUpdate()
        {
            _rb.gravityScale = _targetGravityScale;
        }

        public void SetGravityScale(float gravityScale, int priority)
        {
            if (priority >= _priority)
            {
                _targetGravityScale = gravityScale;
                _priority = priority;
            }
        }

        public void ResetGravityScale(int priority)
        {
            if (priority >= _priority)
            {
                _targetGravityScale = _defaultGravityScale;
                _priority = 0;
            }
        }
    }
}