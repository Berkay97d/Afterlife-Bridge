using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts
{
    public class PlayerTeleportVisual : MonoBehaviour
    {
        [SerializeField] private GameObject _visual;
        [SerializeField] private float _scaleUpTime;
        

        private void Awake()
        {
            transform.localScale = Vector3.zero;
        }

        public void SpawnFromZero(Vector3 pos)
        {
            transform.position = pos;
            
            transform.localScale = Vector3.zero;
            
            AdjustVisiablity(true);

            transform.DOScale(Vector3.one, _scaleUpTime).SetEase(Ease.OutBack);
        }

        private void AdjustVisiablity(bool isV)
        {
            _visual.SetActive(isV);
        }
    }
}