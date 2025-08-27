using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        StartAnimation(stateMachine.MonsterCondition.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.MonsterCondition.AnimationData.NormalAttackParameterHash);
    }

    public override void Exit()
    {

        base.Exit();
        stateMachine.MonsterCondition.Controller.AttackRange.gameObject.SetActive(false);
        StopAnimation(stateMachine.MonsterCondition.AnimationData.AttackParameterHash);
        StopAnimation(stateMachine.MonsterCondition.AnimationData.NormalAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsinAttackRange())
        {
            if (IsInChaseRange()) 
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }

    }
}
