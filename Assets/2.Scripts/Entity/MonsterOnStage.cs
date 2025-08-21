using System;
using UnityEngine;

[Serializable]
public class MonsterOnStage
{
    public int monsterId;
    public int stageId;

    public MonsterOnStage() { }
    public MonsterOnStage(int monsterId, int stageId)
    {
        this.monsterId = monsterId;
        this.stageId = stageId;
    }
}
