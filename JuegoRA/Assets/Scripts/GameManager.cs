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
    [SerializeField] private AudioSource buttonAudioSource;

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

    /// <summary>
    /// Enables or disables when the camera is tracking the image target
    /// </summary>
    /// <param name="b"></param>
    public void EnableTracking(bool b)
    {
        tracked = b;
    }

    /// <summary>
    /// Returns if we are tracking the image target
    /// </summary>
    /// <returns></returns>
    public bool isTracked()
    {
        return tracked;
    }
  

//========================================== Score ======================================
    /// <summary>
    /// Adds one score point
    /// </summary>
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

    /// <summary>
    /// Substract one live/tries
    /// </summary>
    public void SubstractTries()
    {
        nTries--;
        livesText.text = "Lives: " + nTries.ToString();
        if (nTries <= 0) { nTries = 0; GameOver(); }
    }


    /// <summary>
    /// Returns if the game is over
    /// </summary>
    /// <returns></returns>
    public bool IsGameOver() { return gameOver; }
//========================================== Scenes ========================================

    /// <summary>
    /// Activates the UI in game
    /// </summary>
    public void StartPlaying()
    {

        buttonAudioSource.Play();
        gameOver = false;
        mainMenu.SetActive(false);
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + nTries.ToString();


        inGameMenu.SetActive(true);

        player.gameObject.SetActive(true);

        foodSpawner.gameObject.SetActive(true);
    }

    /// <summary>
    /// Activates the main menu UI
    /// </summary>
    public void MainMenu()
    {
        buttonAudioSource.Play();
        
        nTries = 4;
        gameOver = true;

        player.ResetPlayer();
        player.gameObject.SetActive(false);

        foodSpawner.ClearFoodParent();
        foodSpawner.gameObject.SetActive(false);

        inGameMenu.SetActive(false);
        endMenu.SetActive(false);
        mainMenu.SetActive(true);

        UpdateScore(highScoreTextMainMenu);
    } 

    /// <summary>
    /// Activates the game over UI
    /// </summary>
    private void GameOver()
    {
        gameOver = true;
        nTries = 4;
       
        inGameMenu.SetActive(false);
        player.ResetPlayer();
        endMenu.SetActive(true);

        UpdateScore(highScoreTextEndMenu);           
    }


    /// <summary>
    /// Updates the score and its text
    /// </summary>
    /// <param name="uiText">text to be updated</param>
    private void UpdateScore(Text uiText)
    {
        if (score > highScore)
        {
            highScore = score;
            uiText.text = "¡New High Score: " + highScore.ToString() + "!";
        }
        else
        {
            uiText.text = "High Score: " + highScore.ToString();
        }

        score = 0;
    }
}
