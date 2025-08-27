using NUnit.Framework.Interfaces;
using UnityEngine;

public class MonsterChasingState : MonsterBaseState
{
    public MonsterChasingState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 1;
        StartAnimation(stateMachine.MonsterCondition.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.MonsterCondition.AnimationData.MoveParameterHash);
    }

    public override void Exit()
    {

        base.Exit();
        StopAnimation(stateMachine.MonsterCondition.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.MonsterCondition.AnimationData.MoveParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
        else if (IsinAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }


}
