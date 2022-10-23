using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLastLevelOnLoad : MonoBehaviour
{
    void Start()
    {
        LevelData.ReadLevelData();
        LevelData.Level = LevelData.MaxLevel;
        LevelData.LoadLevel();
    }
}
