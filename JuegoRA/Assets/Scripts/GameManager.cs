using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreTextEndMenu;
    [SerializeField] private Text highScoreTextMainMenu;
    [SerializeField] private Text livesText;

    [SerializeField] private PlayerController player;
    [SerializeField] private FoodSpawner foodSpawner;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject endMenu;

    [SerializeField] private int nTries;

    private int score = 0;
    private int highScore = 0;
    private bool tracked = false;
    private bool gameOver = false;

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
            score += 1;
            if (score <= 0) score = 0;
            scoreText.text = "Score: " + score.ToString();
        }       
    }

//========================================== Lives =====================================

    public void SubstractTries()
    {
        nTries--;
        livesText.text = "Lives: " + nTries.ToString();
        if (nTries <= 0) { nTries = 0; GameOver(); }
    }


    public bool IsGameOver() { return gameOver; }
//========================================== Scenes ========================================
    public void StartPlaying()
    {
        gameOver = false;
        mainMenu.SetActive(false);
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + nTries.ToString();


        inGameMenu.SetActive(true);

        player.gameObject.SetActive(true);

        foodSpawner.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        nTries = 4;
        gameOver = true;

        player.ResetPlayer();
        player.gameObject.SetActive(false);

        foodSpawner.ClearFoodParent();
        foodSpawner.gameObject.SetActive(false);

        inGameMenu.SetActive(false);
        endMenu.SetActive(false);
        mainMenu.SetActive(true);

        if (score > highScore)
        {
            highScore = score;
            highScoreTextMainMenu.text = "¡New High Score: " + highScore.ToString() + "!";
        }
        else
        {
            highScoreTextMainMenu.text = "High Score: " + highScore.ToString();
        }

        score = 0;
    } 

    private void GameOver()
    {
        gameOver = true;
        nTries = 4;
       
        inGameMenu.SetActive(false);
        endMenu.SetActive(true);

        if(score > highScore)
        {
            highScore = score;
            highScoreTextEndMenu.text = "¡New High Score: " + highScore.ToString() + "!";
        }
        else
        {
            highScoreTextEndMenu.text = "High Score: " + highScore.ToString();
        }
        
        score = 0;           
    }
}
