using UnityEngine;
using System;

[System.Serializable]
public class HighScoreRowData
{
    private string name;
    private int score;
    private float time;

    public HighScoreRowData(string name, int score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }

    public string getName()
    {
        return name;
    }

    public int getScore()
    {
        return score;
    }

    public float getTime()
    {
        return time;
    }

    public override string ToString()
    {
        return String.Format("(Name: {0}, Score: {1}, Time: {2:F1})", name, score, time);
    }
}
