using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FoodType { Meat, Fish, Bread}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Text scoreText;
    private int score=0;

    [SerializeField] Text orderText;
    [SerializeField] float orderTime = 1.0f;
    private FoodType currentFood;

    private bool tracked = false;

    void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            GameObject.Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    public void EnableTracking(bool b)
    {
        tracked = b;
    }

    public bool isTracked()
    {
        return tracked;
    }

//========================================= Orders =======================================
    void Start()
    {
        if(orderText!=null)InvokeRepeating("NextOrder", 0.0f, orderTime);
    }

    void NextOrder()
    {
        if(tracked)
        {
            currentFood = (FoodType)Random.Range(0, System.Enum.GetValues(typeof(FoodType)).Length);
            orderText.text = "Take " + ((FoodType)currentFood).ToString();
        }
        
    }

    public FoodType CurrentFoodOrder()
    {
        return currentFood;
    }

//========================================== Score ======================================
    public void ChangeScore(int amount)
    {
        if(scoreText!=null)
        {
            score += amount;
            if (score <= 0) score = 0;
            scoreText.text = "Score: " + score.ToString();
        }       
    }    
}
