using UnityEngine;
using UnityEngine.UI;

public enum FoodType { Meat, Fish, Bread, Ribs, Watermelon, Cake, Cheese}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Text scoreText;
    private int score=0;

    [SerializeField] Text orderText;
    [SerializeField] float orderTime = 1.0f;
    private FoodType currentFood;

    private bool tracked = false;

    private int nTries;

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
        currentFood = (FoodType)Random.Range(0, System.Enum.GetValues(typeof(FoodType)).Length);
        orderText.text = "Take " + ((FoodType)currentFood).ToString();
        InvokeRepeating("NextOrder", 0.2f, orderTime);
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
    public void AddScore()
    {
        if(scoreText!=null)
        {
            score += 3;
            if (score <= 0) score = 0;
            scoreText.text = "Score: " + score.ToString();
        }       
    }

    //========================================== Lives =====================================

    public void SubstractTries()
    {
        nTries--;
        if (nTries <= 0) { Debug.Log("GAME OVER"); nTries = 0; }
    }
}
