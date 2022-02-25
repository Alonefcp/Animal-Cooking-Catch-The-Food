using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int scorePoints = 5;
    [SerializeField] int losingPoints = -1;
    [SerializeField] private FoodType type;
    [SerializeField]float fallSpeed = 0.1f;


    private void Update()
    {        
        transform.Translate(-Vector3.forward * Time.deltaTime * fallSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if (GameManager.instance.CurrentFoodOrder() == type) GameManager.instance.ChangeScore(scorePoints);
            else GameManager.instance.ChangeScore(losingPoints);

            GameObject.Destroy(gameObject);
        }
    }


    public FoodType GetFoodType()
    {
        return type;
    }

    public void setFallSpeed(float speed)
    {
        fallSpeed = speed;
    }
}
