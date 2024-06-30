using System;
using System.Collections;
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

        public Vector3 SpawnFromZero(Vector3 pos, Action OnSpawnComplete) 
        {
            var spawnPos = new Vector3(pos.x, pos.y + 0.22f, pos.z);
            transform.position = spawnPos;
            
            transform.localScale = Vector3.zero;
            
            AdjustVisiablity(true);

            transform.DOScale(Vector3.one, _scaleUpTime).SetEase(Ease.OutBack).OnComplete(() =>
            {
                OnSpawnComplete?.Invoke();
            });

            return spawnPos;
        }

        public IEnumerator ReturnZero()
        {
            yield return new WaitForSeconds(0.25f);
            transform.DOScale(Vector3.zero, _scaleUpTime).SetEase(Ease.OutQuint);
        }

        private void AdjustVisiablity(bool isV)
        {
            _visual.SetActive(isV);
        }
    }
}