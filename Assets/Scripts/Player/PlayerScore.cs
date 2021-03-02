using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    public ScoreText scoreText;
    private int score = 0;

    public void UpdateScore(int value) {
        score += value;
        scoreText.UpdateScoreText(score);
    }

    private int scoreIncrement = 1;
    private float scoreRate = 10f;
    private float timeAcc = 0;

    void FixedUpdate() {
        if (timeAcc >= 1 / scoreRate) {
            UpdateScore(scoreIncrement);
            timeAcc = 0;
        }

        timeAcc += Time.deltaTime;
    }
}
