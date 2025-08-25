using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.MoveSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.PlayerCondition.AnimationData.MoveParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerCondition.AnimationData.MoveParameterHash);
    }

}
