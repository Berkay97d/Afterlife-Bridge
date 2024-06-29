using System;
using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class LongJumpEffect : MonoBehaviour
    {
        [SerializeField] private float _longJumpGravityScale;
        
        private const int GravityManipulationPriority = 1;

        private void Start()
        {
            Player.GetPlayerJumper().OnJumpStartPerform += OnJumpStartPerform;
            Player.GetPlayerJumper().OnJumpStopPerform += OnJumpStopPerform;
        }

        private void OnDestroy()
        {
            Player.GetPlayerJumper().OnJumpStartPerform -= OnJumpStartPerform;
            Player.GetPlayerJumper().OnJumpStopPerform -= OnJumpStopPerform;
        }

        private void OnJumpStartPerform()
        {
            StartCoroutine(LongJumpEnumerator());
            
            IEnumerator LongJumpEnumerator()
            {
                yield return new WaitUntil(Player.GetPlayerGroundCheck().CheckIsNotGrounded);
                
                if (Player.GetDownDasher().GetIsDownDashing()) yield break;
                
                Player.GetGravityScaleController().SetGravityScale(_longJumpGravityScale, GravityManipulationPriority);
            }
        }
        
        private void OnJumpStopPerform()
        {
            Player.GetGravityScaleController().ResetGravityScale(GravityManipulationPriority);
        }
    }
}