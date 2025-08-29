using System;
using System.Collections.Generic;

[Serializable]
public class GameAsset
{
    public List<CharacterInfo> characterInfo;
    public List<MonsterInfo> monsterInfo;
    public List<Item> item;
    public List<Stage> stage;
    public List<LevelInfo> levelInfo;

    public GameAsset() { }

}
