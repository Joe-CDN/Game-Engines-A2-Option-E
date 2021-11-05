using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public List<Transform> m_shapes = new List<Transform>();
    public List<string> m_shapeNames = new List<string>();

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(LevelData a_saveData);
    void LoadFromSaveData(LevelData a_saveData);
}
