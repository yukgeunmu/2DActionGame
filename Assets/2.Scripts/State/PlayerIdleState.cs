using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }


    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.PlayerCondition.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerCondition.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        if(stateMachine.MovementInput != 0)
        {
            stateMachine.ChangeState(stateMachine.MoveState);
        }
        base.Update();
    }


}
