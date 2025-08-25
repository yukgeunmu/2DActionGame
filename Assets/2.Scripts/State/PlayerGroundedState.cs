using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }


    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.PlayerCondition.AnimationData.GroundParameterHash);
    }


    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerCondition.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!isGround())
        {
            stateMachine.ChangeState(stateMachine.FallState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void OnMoveCanceled(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.IdleState);

        base.OnMoveCanceled(context);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        if (isGround())
        {
            Jump();
            stateMachine.ChangeState(stateMachine.JumpState);
        }
       
        base.OnJumpStarted(context);
    }

    protected override void OnAttackStared(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.ComboAttackState);
        base.OnAttackStared(context);
    }

}
