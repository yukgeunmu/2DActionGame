using System;
using UnityEngine;


[Serializable]
public class Player
{
    public int id;
    public int characterInfoId;
    public int levelInfoId;
    public string nickName;

    public Player() { }

    public Player(int id, int characterInfoId, int levelInfoId, string nickName)
    {
        this.id = id;
        this.characterInfoId = characterInfoId;
        this.levelInfoId = levelInfoId;
        this.nickName = nickName;
    }

}
