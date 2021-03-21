using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Path.Combine(Application.persistentDataPath, "highscores.data");

    public static void SaveHighScores(HighScoreRowData[] rows)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, rows);
        stream.Close();
    }

    public static HighScoreRowData[] LoadHighScores()
    {
        if(!File.Exists(path)) {
            Debug.LogWarning("No highscores data found.");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        HighScoreRowData[] data = (HighScoreRowData[]) formatter.Deserialize(stream);
        stream.Close();

        return data;
    }
}
