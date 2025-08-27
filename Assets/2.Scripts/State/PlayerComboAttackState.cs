using UnityEngine;

public class PlayerComboAttackState : PlayerAttackState
{
    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }


    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.PlayerCondition.AnimationData.NormalAttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerCondition.AnimationData.NormalAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        AnimatorStateInfo stateInfo = stateMachine.PlayerCondition.Animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f && stateInfo.IsName("PlayerAttack"))
        {
            // isGround()�� PlayerBaseState�� �ִ� �޼����Դϴ�.
            if (isGround() ||  isMonster())
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.FallState);
            }
        }
    }

}

