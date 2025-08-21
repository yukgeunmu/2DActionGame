using System;
using UnityEngine;

[Serializable]
public class LevelInfo
{
    public int id;
    public int level;
    public int statPoints;
    public int requiredExp;


    public LevelInfo() { }
    public LevelInfo(int id, int level, int statPoints, int requiredExp)
    {
        this.id = id;
        this.level = level;
        this.statPoints = statPoints;
        this.requiredExp = requiredExp;
    }

}
