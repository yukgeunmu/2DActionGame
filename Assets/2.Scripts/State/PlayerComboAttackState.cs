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

        // ���� �ִϸ��̼� ���� ������ Idle ��ȯ�� ����
        if (stateInfo.IsName("PlayerAttack"))
        {
            // ��Ÿ �Է� ó��
            if (stateMachine.PlayerCondition.Input.playerActions.Attack.WasPressedThisFrame())
            {
                // ���� �������� ����
                stateMachine.ChangeState(stateMachine.ComboAttackState);
                return;
            }

            // �ִϸ��̼� ������ ���� ���� ��ȯ
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

