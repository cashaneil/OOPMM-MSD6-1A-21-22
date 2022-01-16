using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    public void SaveData()
    {
        SerializedData mySerializedData = new SerializedData();

        mySerializedData.ser_score = GameData.Score;
        mySerializedData.ser_highScore = GameData.HighScore;
        mySerializedData.ser_kills = GameData.Kills;
        mySerializedData.ser_currentLevel = GameData.CurrentLevel;

        string jsontosave = JsonUtility.ToJson(mySerializedData);
        PlayerPrefs.SetString("GhostShooterData", jsontosave);
    }

    public void LoadData()
    {
        SerializedData myLoadedData = new SerializedData();
        string loadedjson;

        if (PlayerPrefs.HasKey("GhostShooterData"))
        {
            loadedjson = PlayerPrefs.GetString("GhostShooterData");
            myLoadedData = JsonUtility.FromJson<SerializedData>(loadedjson);

            if (myLoadedData != null)
            {
                GameData.Score = myLoadedData.ser_score;
                GameData.HighScore = myLoadedData.ser_highScore;
                GameData.Kills = myLoadedData.ser_kills;
                GameData.CurrentLevel = myLoadedData.ser_currentLevel;
            }
        }
    }
}
