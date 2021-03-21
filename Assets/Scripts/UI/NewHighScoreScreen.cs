using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class NewHighScoreScreen : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public Text inputText;
    public int inputDelay = 1;

    private bool inputEnabled = false;
    private int score;
    private float time;
    private HighScoreManager highScoreManager;

    public void Setup(int score, float time)
    {
        gameObject.SetActive(true);
        this.score = score;
        this.time = time;
        highScoreManager = HighScoreManager.instance;
        scoreText.text = string.Format("Score: {0}", score);
        timerText.text = "Time: " + TimeSpan.FromSeconds(time).ToString(@"mm\:ss\.f");

        StartCoroutine(EnableInput());
    }

    private IEnumerator EnableInput()
    {
        yield return new WaitForSecondsRealtime(inputDelay);
        inputEnabled = true;
    }

    public void DiscardButton()
    {
        if (inputEnabled)
            LoadGameOver();
    }

    public void SaveButton()
    {
        if (inputEnabled && inputText.text.CompareTo("") != 0)
        {
            SaveScore(inputText.text);
            LoadGameOver();
        }
    }

    private void LoadGameOver()
    {
        FindObjectOfType<GameManager>().LoadGameOverScreen();
        gameObject.SetActive(false);
    }

    private void SaveScore(string name)
    {
        highScoreManager.AddHighScore(name, score, time);
        highScoreManager.SaveHighScores();
    }
}
