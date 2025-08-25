using System;
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


[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]

public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
}
