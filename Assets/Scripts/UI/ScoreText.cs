using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public Text scoreText;

    void Awake() {
        scoreText.text = "Score: 0";
    }

    public void UpdateScoreText(int score) {
        scoreText.text = string.Format("Score: {0}", score);
    }
}
