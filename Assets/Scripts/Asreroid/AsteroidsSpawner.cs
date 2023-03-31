using UnityEngine;

namespace Asteroids
{
    public class AsteroidsSpawner : MonoBehaviour
    {
        [Header("Stats:")]
        [SerializeField] private Asteroid asteroidPrefab;
        [SerializeField, Range(0, 100)] private float spawnRate = 1f;
        [SerializeField, Range(0, 100)] private float spawnAmount = 1f;
        [SerializeField, Range(0, 100)] private float spawnDistance = 4f;

        private void Start() => InvokeRepeating(nameof(SpawnAsteroids), spawnRate, spawnRate);

        private void SpawnAsteroids()
        {
            for(int i = 0; i < spawnAmount; i ++)
            {
                Vector3 spawnPoint = transform.position + GetRandomSpawPosition();
                Quaternion trajectory = GetRandomTrajectory();

                Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, trajectory);
            }
        }

        private Vector3 GetRandomSpawPosition()
        {
            return Random.insideUnitCircle.normalized * spawnDistance;
        }

        private Quaternion GetRandomTrajectory()
        {
            float varianse = Random.Range(-spawnDistance, spawnDistance);
            return Quaternion.AngleAxis(varianse, Vector3.forward);
        }    
    }
}

