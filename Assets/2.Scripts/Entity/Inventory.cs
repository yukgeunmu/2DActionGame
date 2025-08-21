using System;
using UnityEngine;

[Serializable]
public class Inventory
{
    public int id;
    public int playerId;
    public int itemId;

    public Inventory() { }

    public Inventory(int id, int palyerId, int itemId) {

        this.id = id;
        this.playerId = palyerId;
        this.itemId = itemId;
    }

}
