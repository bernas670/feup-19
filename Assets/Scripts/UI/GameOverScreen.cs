using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text scoreText;

    private void Awake() {
        gameObject.SetActive(false);
    }

    public void Setup(int score) {
        gameObject.SetActive(true);
        scoreText.text = string.Format("Score: {0}", score);
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
