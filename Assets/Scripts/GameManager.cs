using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameUI;
    public GameOverScreen gameOverScreen;
    private bool gameOver = false;

    private void Awake() {
        Time.timeScale = 1f;
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
