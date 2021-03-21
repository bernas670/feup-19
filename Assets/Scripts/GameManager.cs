using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public MouseCursor customCursor;
    public GameObject gameUI;
    public Text timerText;
    public GameObject pauseMenuUI;
    public GameOverScreen gameOverScreen;
    public static bool isPaused = false;
    public static bool gameOver = false;

    private HighScoreManager highScoreManager;
    private float timer;

    private void Awake()
    {
        timer = 0f;
        timerText.text = TimeSpan.FromSeconds(timer).ToString(@"mm\:ss\.f");

        highScoreManager = HighScoreManager.instance;

        Time.timeScale = 1f;
        isPaused = false;
        gameOver = false;
        customCursor.Enable();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = TimeSpan.FromSeconds(timer).ToString(@"mm\:ss\.f");

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        customCursor.Enable();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void Pause()
    {
        customCursor.Disable();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        isPaused = false;
        gameOver = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void GameOver()
    {
        if (gameOver) return;

        PlayerScore player = FindObjectOfType<PlayerScore>();

        if (highScoreManager.isHighScore(player.GetScore(), timer))
        {
            //Show menu
            highScoreManager.AddHighScore("CAJO", player.GetScore(), timer);
            highScoreManager.SaveHighScores();
            Debug.Log(highScoreManager);
        }

        gameOver = true;
        Time.timeScale = 0f;
        customCursor.Disable();
        gameUI.SetActive(false);
        gameOverScreen.Setup(player.GetScore(), timer);
    }
}
