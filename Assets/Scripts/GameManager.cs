using UnityEngine;

// TODO: extract the game score to this class

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
            // TODO: change this value
            Time.timeScale = 0f;
            gameUI.SetActive(false);
            gameOverScreen.Setup(1000000);
        }
    }
}
