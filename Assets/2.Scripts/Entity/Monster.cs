using System;

[Serializable]
public class Monster
{
    public int id;
    public int level;
    public int monsterInfoId;

    public Monster() { }

    public Monster(int id, int level, int monsterInfoId)
    {
        this.id = id;
        this.level = level;
        this.monsterInfoId = monsterInfoId;
    }

}
