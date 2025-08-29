using UnityEngine;

public class MonsterHurtState : MonsterBaseState
{
    public MonsterHurtState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MonsterCondition.Controller.AttackRange.gameObject.SetActive(false);
        StartAnimation(stateMachine.MonsterCondition.AnimationData.HurtParameterHash);
    }

    public override void Exit()
    {

        base.Exit();
        StopAnimation(stateMachine.MonsterCondition.AnimationData.HurtParameterHash);
    }
}
