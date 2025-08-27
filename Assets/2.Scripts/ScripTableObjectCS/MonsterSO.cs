using JetBrains.Annotations;
using System;
using UnityEngine;



[Serializable]

public class MonsterData
{
    [field: SerializeField] public int health = 10;
    [field: SerializeField] public int mana = 10;
    [field: SerializeField] public int attack = 1;
    [field: SerializeField] public int defence = 1;
    [field: SerializeField] public int agility = 1;
    [field: SerializeField] public int speed = 1;
    [field: SerializeField] public int level = 1;
    [field: SerializeField] public int exp = 0;
}


[CreateAssetMenu(fileName = "Monster", menuName = "Characters/Monster")]
public class MonsterSO : ScriptableObject
{
    [field: SerializeField] public float PlayerChasingRange { get; private set; } = 10f;
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(0f, 2f)] public float MoveSpeedModifier { get; private set; } = 1f;
    [field: SerializeField] public float AttackRange { get; private set; } = 1.5f;

    [field: SerializeField] public MonsterData MonsterData;

    [field: SerializeField] public Enums.MonsterNumber monsterNumber;

}
