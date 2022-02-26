using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    [SerializeField] Text orderText;
    [SerializeField] float orderTime = 1.0f;
    private FoodType currentFood;

    void Start()
    {
        //currentFood = (FoodType)Random.Range(0, System.Enum.GetValues(typeof(FoodType)).Length);
        //orderText.text = "Take " + ((FoodType)currentFood).ToString();
        InvokeRepeating("NextOrder", 0.2f, orderTime);
    }

    void NextOrder()
    {
        if (GameManager.instance.isTracked())
        {           
            currentFood = (FoodType)Random.Range(0, System.Enum.GetValues(typeof(FoodType)).Length);
            orderText.text = "Take " + ((FoodType)currentFood).ToString();
        }

    }

    public FoodType CurrentFoodOrder()
    {
        return currentFood;
    }
}
