using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float SpawnRate = 2f;
    [SerializeField] private float SpawnIncreaseOverTime;
    [SerializeField] private GameObject[] EnemyPrefab;
    [SerializeField] private Transform[] SpawnPoints;

    private float LastSpawnTime;

   
   
    void Update()
    {
        if (LastSpawnTime + SpawnRate < Time.time)
        {
            var randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length - 1)];
            Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Length)],randomSpawnPoint.position,Quaternion.identity);
            LastSpawnTime = Time.time;
            SpawnRate *= SpawnIncreaseOverTime;
        }
    }
}
