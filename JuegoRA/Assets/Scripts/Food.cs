using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float fallSpeed = 0.2f;
    [SerializeField] int scorePoints = 5;
    [SerializeField] private FoodType type;

    private void Update()
    {        
        transform.Translate(-Vector3.forward * Time.deltaTime * fallSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.ChangeScore(scorePoints);
            GameObject.Destroy(gameObject);
        }
    }

    public FoodType GetFoodType()
    {
        return type;
    }
}
