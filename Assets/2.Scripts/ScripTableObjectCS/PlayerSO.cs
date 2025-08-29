using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerGroundData
{
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;

    [field: Header("IdleData")]

    [field: Header("MoveData")]
    [field: SerializeField][field: Range(0f, 2f)] public float MoveSpeedModifier { get; private set; } = 1f;

}

[Serializable]
public class PlayerAirData
{
    [field: Header("JumpData")]
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; private set; } = 5f;

}

[Serializable]
public class PlayerData
{
    [field: SerializeField] public int health = 10;
    [field: SerializeField] public int mana = 10;
    [field: SerializeField] public int attack = 1;
    [field: SerializeField] public int defence = 1;
    [field: SerializeField] public int agility = 1;
    [field: SerializeField] public int speed = 1;
    [field: SerializeField] public int level = 1;
    [field: SerializeField] public int statPoints = 0;
    [field: SerializeField] public int maxExp = 10;
    [field: SerializeField] public int exp = 0;
}


[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]

public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }

    [field: SerializeField] public PlayerData PlayerData { get; set; }

    [field: SerializeField] public List<Sprite> characterSprite;
}
