public class PlayerHurtState : PlayerBaseState
{
    public PlayerHurtState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.PlayerCondition.AnimationData.HurtParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerCondition.AnimationData.HurtParameterHash);
    }
}
