using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[System.Serializable]

public static class SaveSystem
{
    public static void SaveGame(ScoreManager scoreManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/score.vik";
        
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(scoreManager);               

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static ScoreData LoadGame()
    {

        string path = Application.persistentDataPath + "/score.vik";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;

            return data;
        }

        else
        {
            Debug.Log("No Save Data Found");

            return null;
        }
        
    }
}
