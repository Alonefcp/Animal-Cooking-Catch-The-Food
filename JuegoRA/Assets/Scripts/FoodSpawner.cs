using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Food[] foodPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform imageTarget;
    [SerializeField] private float minSpawnTime = 0.5f;
    [SerializeField] private float maxSpawnTime = 1.0f;



    void Start()
    {
        InvokeRepeating("SpawnFruit", 0.2f,Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnFruit()
    {   
        if(GameManager.instance.isTracked())
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Food food = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            Instantiate<Food>(food, spawnPoint.position, spawnPoint.rotation, imageTarget);
        }                           
    }
}
