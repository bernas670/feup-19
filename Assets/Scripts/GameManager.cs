using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameUI;
    public GameObject pauseMenuUI;
    public GameOverScreen gameOverScreen;
    public static bool isPaused = false;
    public static bool gameOver = false;

    private void Awake() {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            Debug.Log("Pressed Esc");
            if(isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu() {
        isPaused = false;
        gameOver = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void GameOver() {
        if (!gameOver) {
            gameOver = true;
            Time.timeScale = 0f;
            gameUI.SetActive(false);
            gameOverScreen.Setup(FindObjectOfType<PlayerScore>().GetScore());
        }
    }
}
