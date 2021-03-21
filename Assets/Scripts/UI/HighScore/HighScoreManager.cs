using System;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;
    public int numberHighScores = 10;
    private SortedSet<HighScoreRowData> rows;

    private void Awake()
    {
        if (instance != null)
        {
            // When a new HighScoreManager is instantiated, if another
            // one already exists then we destroy the new one.
            Destroy(gameObject);
            return;
        }

        instance = this;
        HighScoreRowData[] data = SaveSystem.LoadHighScores();

        if (data == null)
        {
            rows = new SortedSet<HighScoreRowData>(new HighScoreComparator());
            rows.Add(new HighScoreRowData("AAA", 1, 10));
            rows.Add(new HighScoreRowData("BBB", 1, 15));
            rows.Add(new HighScoreRowData("CCC", 2, 15));
            rows.Add(new HighScoreRowData("DDD", 3, 15));
            rows.Add(new HighScoreRowData("EEE", 4, 10));
            rows.Add(new HighScoreRowData("FFF", 4, 15));
            rows.Add(new HighScoreRowData("GGG", 4, 20));
            rows.Add(new HighScoreRowData("HHH", 1, 15));
            rows.Add(new HighScoreRowData("III", 1, 15));
            rows.Add(new HighScoreRowData("JJJ", 5, 2));
        }
        else
        {
            rows = new SortedSet<HighScoreRowData>(data, new HighScoreComparator());
        }

        DontDestroyOnLoad(gameObject);
    }

    public bool isHighScore(int score, float time)
    {
        if (rows.Count < numberHighScores)
        {
            return true;
        }

        //When considering a new high score we do not take into account the name of the player
        HighScoreRowData row = new HighScoreRowData("ZZZZZ", score, time);

        // TODO: delete these lines
        // Debug.Log("Max is: " + rows.Max.getScore());
        // Debug.Log("Min is: " + rows.Min.getScore());
        // Debug.Log("Candidate is: " + score);

        // Since the list is sorted in ascending order,
        // but we want the highest score first, then
        // the last row is the Max value from the set
        HighScoreRowData lastRow = rows.Max;

        if (new HighScoreComparator().Compare(row, lastRow) < 0)
        {
            // TODO: delete Log
            Debug.Log("Candidate is Highscore");
            return true;
        }

        return false;
    }

    public void AddHighScore(string name, int score, float time)
    {
        rows.Remove(rows.Max);

        HighScoreRowData row = new HighScoreRowData(name, score, time);
        Debug.Log("New Score: " + row);
        rows.Add(row);
    }

    public void SaveHighScores()
    {
        HighScoreRowData[] arr = new HighScoreRowData[numberHighScores];
        rows.CopyTo(arr);
        SaveSystem.SaveHighScores(arr);
    }

    public override string ToString()
    {
        string str = "SortedSet contents:\n";
        foreach (HighScoreRowData item in rows)
        {
            str += item;
            str += "\n";
        }

        return str;
    }

    private class HighScoreComparator : IComparer<HighScoreRowData>
    {
        public int Compare(HighScoreRowData d1, HighScoreRowData d2)
        {
            if (d1.getScore() == d2.getScore() && d1.getTime() == d2.getTime())
            {
                return d1.getName().CompareTo(d2.getName());
            }

            if (d1.getScore() == d2.getScore())
            {
                return (int)Math.Round(d1.getTime() - d2.getTime());
            }

            return d2.getScore() - d1.getScore();
        }
    }
}
