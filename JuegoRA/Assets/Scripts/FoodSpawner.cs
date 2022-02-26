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
    int index = 0;

    void Start()
    {

        StartSpawningFood();
    }

    IEnumerator SpawnFruit()
    {         
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));    
            
            if(GameManager.instance.isTracked())
            {
                Transform spawnPoint = /*spawnPoints[Random.Range(0, spawnPoints.Length)];*/spawnPoints[(index++) % spawnPoints.Length];

                Food food = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
                Instantiate<Food>(food, spawnPoint.position, spawnPoint.rotation, foodParent);
            }          
        }                                
    }

    public void StartSpawningFood()
    {
        StartCoroutine(SpawnFruit());
    }

    public void StopSpawningFood()
    {
        StopCoroutine(SpawnFruit());
    }

    public void clearFoodParent()
    {
        foreach(Transform food in foodParent)
        {
            GameObject.Destroy(food.gameObject);
        }
    }
}
