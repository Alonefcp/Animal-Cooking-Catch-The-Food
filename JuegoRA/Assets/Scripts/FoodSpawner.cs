using System.Collections;
using System.Collections.Generic;
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
        InvokeRepeating("SpawnFruit", 2.0f,Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnFruit()
    {                
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Food spawnedFood = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
        Instantiate<Food>(spawnedFood, spawnPoint.position,spawnPoint.rotation,imageTarget);                       
    }
}
