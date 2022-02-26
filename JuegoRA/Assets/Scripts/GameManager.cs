using UnityEngine;
using UnityEngine.UI;

public enum FoodType { Meat, Fish, Bread, Ribs, Watermelon, Cake, Cheese}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreTextEndMenu;
    [SerializeField] private Text highScoreTextMainMenu;

    [SerializeField] private PlayerController player;
    [SerializeField] private FoodSpawner foodSpawner;
    [SerializeField] private GameObject orderManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject endMenu;

    [SerializeField] private int nTries;

    private int score = 0;
    private int highScore = 0;
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
        if (nTries <= 0) { nTries = 0; GameOver(); }
    }
//========================================== Scenes ========================================
    public void StartPlaying()
    {
        mainMenu.SetActive(false);
        inGameMenu.SetActive(true);
        player.gameObject.SetActive(true);
        orderManager.SetActive(true);
        foodSpawner.gameObject.SetActive(true);
        foodSpawner.StartSpawningFood();
    }

    public void MainMenu()
    {
        player.gameObject.SetActive(false);
        orderManager.SetActive(false);
        foodSpawner.clearFoodParent();
        foodSpawner.StopSpawningFood();
        foodSpawner.gameObject.SetActive(false);

        inGameMenu.SetActive(false);
        endMenu.SetActive(false);
        mainMenu.SetActive(true);

        highScoreTextMainMenu.text = "High Score: " + highScore.ToString();
    }

    private void GameOver()
    {
        nTries = 3;
        player.ResetPlayer();
        player.gameObject.SetActive(false);
        orderManager.SetActive(false);
        foodSpawner.clearFoodParent();
        foodSpawner.StopSpawningFood();
        foodSpawner.gameObject.SetActive(false);
        
        inGameMenu.SetActive(false);
        endMenu.SetActive(true);
        if(score > highScore)
        {
            highScore = score;
            highScoreTextEndMenu.text = "¡New High Score: " + score.ToString() + "!";
        }
        else
        {
            highScoreTextEndMenu.text = "High Score: " + score.ToString();
        }
        
        score = 0;
             
    }
}
