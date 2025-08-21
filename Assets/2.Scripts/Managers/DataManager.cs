using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public GameAsset gameAsset;

    public void SetGameData(string jsonData)
    {
        gameAsset = JsonUtility.FromJson<GameAsset>(jsonData);
        Debug.Log("DataManager has parsed the data.");
    }

}
