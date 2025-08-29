using System;
using UnityEngine;



[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public Item data;
}
