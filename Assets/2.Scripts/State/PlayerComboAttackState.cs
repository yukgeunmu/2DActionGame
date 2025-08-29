using UnityEngine;

public class PlayerComboAttackState : PlayerGroundedState
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

        // 공격 애니메이션 종료 전까지 Idle 전환을 막음
        if (stateInfo.IsName("PlayerAttack"))
        {
            // 연타 입력 처리
            if (stateMachine.PlayerCondition.Input.playerActions.Attack.WasPressedThisFrame())
            {
                // 다음 공격으로 연결
                stateMachine.ChangeState(stateMachine.ComboAttackState);
                return;
            }

            // 애니메이션 끝났을 때만 상태 전환
            if (stateInfo.normalizedTime >= 1f)
            {
                if (isGround() || isMonster())
                    stateMachine.ChangeState(stateMachine.IdleState);
                else
                    stateMachine.ChangeState(stateMachine.FallState);
            }
        }
    }

}

