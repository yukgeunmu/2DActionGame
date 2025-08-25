using Unity.XR.OpenVR;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.PlayerCondition.AnimationData.JumpParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerCondition.AnimationData.JumpParameterHash);
    }

    public override void Update()
    {
        if (stateMachine.PlayerCondition.rb.linearVelocityY <= 0.01f)
        {
            stateMachine.ChangeState(stateMachine.FallState);
        }

        base.Update();
    }
}
