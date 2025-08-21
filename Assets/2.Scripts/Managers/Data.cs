using System;
using System.Collections.Generic;

[Serializable]
public class CharacterData
{
    public int id;
    public string name;
    // Add other character fields here as needed
}

[Serializable]
public class MonsterData
{
    public int id;
    public string name;
    // Add other monster fields here as needed
}

[Serializable]
public class GameData
{
    // This field name matches the key in your JSON.
    // If "charcter" is a typo for "character", you should change it here and in the JSON.
    public List<CharacterData> charcter;
    public List<MonsterData> monster;
}
