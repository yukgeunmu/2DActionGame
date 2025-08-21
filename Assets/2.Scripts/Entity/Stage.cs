using System;
using UnityEngine;

[Serializable]
public class Stage
{
    public int id;
    public int stageLevel;

    public Stage() { }

    public Stage(int id, int stageLevel)
    {
        this.id = id;
        this.stageLevel = stageLevel;
    }
}
