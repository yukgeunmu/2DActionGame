using System;
using UnityEngine;

[Serializable]
public class Stage
{
    public int id;
    public int stageLevel;
    public int stageExp;
    public int spawn;
    public int monsterLevel;

    public Stage() { }

    public Stage(int id, int stageLevel, int stageExp, int spawn, int monsterLevel)
    {
        this.id = id;
        this.stageLevel = stageLevel;
        this.stageExp = stageExp;
        this.spawn = spawn;
        this.monsterLevel = monsterLevel;
    }
}
