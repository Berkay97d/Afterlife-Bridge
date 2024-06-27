using System;
using UnityEngine;

namespace _Scripts
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        
        
        private void Update()
        {
            transform.Translate(Vector3.left * (_moveSpeed * Time.deltaTime));
        }
    }
}