using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Player
{
    public int id;
    public int characterInfoId;
    public int levelInfoId;
    public string nickName;
    public int exp;
    public int score;

    public Player() { }

    public Player(int id, int characterInfoId, int levelInfoId, string nickName, int exp, int score)
    {
        this.id = id;
        this.characterInfoId = characterInfoId;
        this.levelInfoId = levelInfoId;
        this.nickName = nickName;
        this.exp = exp;
        this.score = score;
    }

}

[Serializable]
public class PlayerListWrapper
{
    public List<Player> players;

    public PlayerListWrapper() { }
}
