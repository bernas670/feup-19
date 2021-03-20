using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    public void Setup(int score, float time) {
        gameObject.SetActive(true);
        scoreText.text = string.Format("Score: {0}", score);
        timerText.text = "Time: " + TimeSpan.FromSeconds(time).ToString(@"mm\:ss\.f");
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
