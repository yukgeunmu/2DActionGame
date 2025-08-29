using UnityEngine;

public class MonsterStateMachine : StateMachine
{

    public MonsterCondition MonsterCondition { get; }
    public float MovementSpeed {  get; private set; }
    public float MovementSpeedModifier{ get; set; }

    public GameObject Target {  get; private set; }
    public MonsterIdleState IdleState { get; }
    public MonsterChasingState ChasingState { get; }
    public MonsterAttackState AttackState { get; }

    public MonsterHurtState HurtState { get; }


    public MonsterStateMachine(MonsterCondition monsterCondition)
    {
        MonsterCondition = monsterCondition;
        Target = GameObject.FindGameObjectWithTag("Player");

        IdleState = new MonsterIdleState(this);
        ChasingState = new MonsterChasingState(this);
        AttackState = new MonsterAttackState(this);
        HurtState = new MonsterHurtState(this);

        MovementSpeed = MonsterCondition.Data.BaseSpeed + MonsterCondition.Data.MonsterData.speed;
        MovementSpeedModifier = MonsterCondition.Data.MoveSpeedModifier;
    }

    public IState CurrentState()
    {
        return currentState;
    }
}
