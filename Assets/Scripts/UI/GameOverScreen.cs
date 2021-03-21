using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public int inputDelay = 1;
    private bool inputEnabled = false;

    public void Setup(int score, float time)
    {
        gameObject.SetActive(true);
        scoreText.text = string.Format("Score: {0}", score);
        timerText.text = "Time: " + TimeSpan.FromSeconds(time).ToString(@"mm\:ss\.f");
        
        StartCoroutine(EnableInput());
    }

    private IEnumerator EnableInput()
    {
        yield return new WaitForSecondsRealtime(inputDelay);
        inputEnabled = true;
    }

    public void RestartButton()
    {
        if (inputEnabled)
            SceneManager.LoadScene("Game");
    }

    public void ReturnToMenuButton()
    {
        if (inputEnabled)
            SceneManager.LoadScene("MainMenu");
    }
}
