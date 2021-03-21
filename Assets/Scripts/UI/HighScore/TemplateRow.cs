using System;
using UnityEngine;
using UnityEngine.UI;

public class TemplateRow : MonoBehaviour
{

    public Text rank, username, time, score;

    public void setValues(int rank, string username, float time, int score)
    {
        this.rank.text = rank.ToString();
        this.username.text = username;
        this.time.text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss\.f");
        this.score.text = score.ToString();
    }
}
