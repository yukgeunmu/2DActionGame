using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    public MonsterIdleState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
    }


    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 0;
        stateMachine.MonsterCondition.Controller.AttackRange.gameObject.SetActive(false);
        StartAnimation(stateMachine.MonsterCondition.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.MonsterCondition.AnimationData.IdleParameterHash);
    }

    public override void Exit() { 

        base.Exit();
        StopAnimation(stateMachine.MonsterCondition.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.MonsterCondition.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
      base.Update();
        if(IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }
   
}
