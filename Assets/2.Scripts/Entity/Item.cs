using System;
using UnityEngine;

[Serializable]
public class Item
{
    public int id;
    public string name;
    public string itemType;
    public string equipSlot;
    public int health;
    public int mana;
    public int attack;
    public int defence;
    public int agility;
    public int speed;

    public Item() { }
    public Item(int id, string name, string itemType, string equipSlot, int health, int mana, int attack, int defence, int agility, int speed )
    { 
        this.id = id;
        this.name = name;
        this.itemType = itemType;
        this.equipSlot = equipSlot;
        this.health = health;
        this.mana = mana;
        this.attack = attack;
        this.defence = defence;
        this.agility = agility;
        this.speed = speed;
    }
}
