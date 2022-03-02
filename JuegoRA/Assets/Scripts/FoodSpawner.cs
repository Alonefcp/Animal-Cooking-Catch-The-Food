using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Food[] foodPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minSpawnTime = 0.5f;
    [SerializeField] private float maxSpawnTime = 1.0f;
    [SerializeField] private Transform foodParent;
    Transform previousSpawnPoint;

    void Start()
    {      
        previousSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //Here we start spawning food
        InvokeRepeating("SpawnFruit",0.2f, Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnFruit()
    {   

        //Here we instantiate a food prefab and we check that the spawn point is different every time
        if(GameManager.instance.isTracked() && !GameManager.instance.IsGameOver())
        {
            Transform spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];
            while(previousSpawnPoint==spawnPoint)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];                   
            }
            previousSpawnPoint = spawnPoint;

            Food food = foodPrefabs[Random.Range(0, foodPrefabs.Length)];               
            Instantiate<Food>(food, spawnPoint.position, spawnPoint.rotation, foodParent);
        }                                         
    }


    public void ClearFoodParent()
    {
        foreach(Transform food in foodParent)
        {
            GameObject.Destroy(food.gameObject);
        }
    }
}
