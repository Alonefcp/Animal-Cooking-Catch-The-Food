using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform fruitPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform imageTarget;
    [SerializeField] private float minSpawnTime = 0.5f;
    [SerializeField] private float maxSpawnTime = 1.0f;

    void Start()
    {
        InvokeRepeating("SpawnFruit", 3.0f,Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnFruit()
    {                
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate<Transform>(fruitPrefab, spawnPoint.position,spawnPoint.rotation,imageTarget);                       
    }
}
