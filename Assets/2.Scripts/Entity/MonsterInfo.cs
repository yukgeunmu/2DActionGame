using System;
using UnityEngine;

[Serializable]
public class MonsterInfo
{
    public int id;
    public string name;
    public int health;
    public int mana;
    public int attack;
    public int defence;
    public int agility;
    public int speed;

    public MonsterInfo(int id, string name, int health, int mana, int attack, int defence, int agility, int speed)
    {
        this.id = id;
        this.name = name;
        this.health = health;
        this.mana = mana;
        this.attack = attack;
        this.defence = defence;
        this.agility = agility;
        this.speed = speed;
    }
}
