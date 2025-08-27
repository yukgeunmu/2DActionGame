using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.PlayerCondition.AnimationData.FallParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerCondition.AnimationData.FallParameterHash);
    }

    public override void Update()
    {
        if(isGround() || isMonster()) stateMachine.ChangeState(stateMachine.IdleState);
        base.Update();
    }


}
