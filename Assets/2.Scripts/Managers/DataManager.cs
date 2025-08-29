using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public GameAsset gameAsset;
    public Player Player;
    public List<CharacterInfo> characterList;
    public List<MonsterInfo> monsterInfoList;
    public List<Item> itemList;
    public List<Stage> stageList;
    public List<LevelInfo> levelInfoList;

    public List<Player> playerList;


    public void Init()
    {
        SetGameData(Managers.Socket.LoadDataJson);
    }

    public void SetGameData(string jsonData)
    {
        gameAsset = JsonUtility.FromJson<GameAsset>(jsonData);
        Debug.Log("DataManager has parsed the data.");

        characterList = gameAsset.characterInfo;
        monsterInfoList = gameAsset.monsterInfo;
        itemList = gameAsset.item;
        stageList = gameAsset.stage;
        levelInfoList = gameAsset.levelInfo;
    }

    public void SetPlayerData(string jsonData)
    {
        Player = JsonUtility.FromJson<Player>(jsonData);
        Managers.Game.player = Player;
        Debug.Log("Player 넣기 성공");
    }
    

}
