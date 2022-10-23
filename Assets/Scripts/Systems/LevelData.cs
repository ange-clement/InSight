using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelData
{
    [System.Serializable]
    public class SaveData
    {
        public int MaxLevel;
    }

    public static int MaxLevel = 0;
    public static int Level = 0;

    public static readonly string Path = Application.persistentDataPath + "/InSight.json";

    public static void SaveLevelData()
    {
        SaveData saveData = new SaveData();
        saveData.MaxLevel = MaxLevel;

        string json = JsonUtility.ToJson(saveData);

        System.IO.File.WriteAllText(Path, json);

        Debug.Log("Saved level at \"" + Path + "\"");
    }

    public static void ReadLevelData()
    {
        string json = System.IO.File.ReadAllText(Path);

        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        MaxLevel = saveData.MaxLevel;
    }

    public static void LoadNextLevel()
    {
        Level = (Level + 1) % SceneManager.sceneCountInBuildSettings;
        LoadLevel();
    }

    public static void LoadLevel()
    {
        SceneManager.LoadScene(Level);
        if (Level > MaxLevel)
        {
            MaxLevel = Level;
            SaveLevelData();
        }
    }
}
