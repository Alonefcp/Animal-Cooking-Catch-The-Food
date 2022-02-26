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

    void Start()
    {
        StartSpawningFood();
    }

    IEnumerator SpawnFruit()
    {         
        while(true)
        {
            if(GameManager.instance.isTracked())
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Food food = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
                Instantiate<Food>(food, spawnPoint.position, spawnPoint.rotation, foodParent);
            }
            
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));           
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
