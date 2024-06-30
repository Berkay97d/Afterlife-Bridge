using System;
using UnityEngine;

namespace _Scripts
{
    public class PlayerLookDirectionController : MonoBehaviour
    {
        [SerializeField] private Transform _visualTransform;


        private void Update()
        {
            if (Player.GetPlayerTeleporter().GetIsTeleporting())
            {
                return;
            }
            
            var direction = Player.GetPlayerMovement().GetDirection();
           
            if (direction < -0.5f && Math.Abs(_visualTransform.rotation.y - 180) > 10)
            {
                _visualTransform.rotation = Quaternion.Euler(new Vector3(0,180,0));
                return;
            }
            
            if (direction > 0.5f && _visualTransform.rotation.y != 0)
            {
                _visualTransform.rotation = Quaternion.Euler(new Vector3(0,0,0));
                return;
            }
        }
    }
}