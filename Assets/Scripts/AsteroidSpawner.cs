using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnInterval = 2f;        // Time between spawns
    [SerializeField] private float spawnIntervalVariance = 1f; // Random variance
    
    [Header("Spawn Area")]
    [SerializeField] private float minX = -8f;  // Left boundary
    [SerializeField] private float maxX = 8f;   // Right boundary
    [SerializeField] private float spawnY = 6f; // Height to spawn at
    
    [Header("Difficulty")]
    [SerializeField] private float minSpawnInterval = 0.5f;   // Fastest spawn rate
    [SerializeField] private float difficultyIncreaseRate = 0.1f; // How much faster per spawn

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid();
            ScheduleNextSpawn();
        }
    }

    void SpawnAsteroid()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        
        // Gradually increase difficulty
        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval -= difficultyIncreaseRate;
            spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval);
        }
    }

    void ScheduleNextSpawn()
    {
        float variance = Random.Range(-spawnIntervalVariance, spawnIntervalVariance);
        nextSpawnTime = Time.time + spawnInterval + variance;
    }
}
