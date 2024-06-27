using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _obstacleSpawnTransform;
        [SerializeField] private Obstacle[] _obstaclePrefabs;


        private void Start()
        {
            StartCoroutine(SpawnObstacles());
        }

        private IEnumerator SpawnObstacles()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
                var randomObstacle = GetRandomPrefab();
                Instantiate(randomObstacle, _obstacleSpawnTransform.position, Quaternion.identity);    
            }
        }

        private Obstacle GetRandomPrefab()
        {
            int randomIndex = Random.Range(0, _obstaclePrefabs.Length);
            return _obstaclePrefabs[randomIndex];
        }
    }
}