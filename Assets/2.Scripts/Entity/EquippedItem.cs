using System;
using UnityEngine;

[Serializable]
public class EquippedItem
{
    public int playerId;
    public int itemId;
    

    public EquippedItem() { }

    public EquippedItem(int playerId, int itemId)
    {
        this.playerId = playerId;
        this.itemId = itemId;
    }
}
