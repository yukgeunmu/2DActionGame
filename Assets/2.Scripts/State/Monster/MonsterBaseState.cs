using UnityEngine;

public class MonsterBaseState : IState
{

    protected MonsterStateMachine stateMachine;


    public MonsterBaseState(MonsterStateMachine monsterStateMachine)
    {
        stateMachine = monsterStateMachine;
    }
    public void Enter()
    {

    }

    public void Exit()
    {
 
    }

    public void HandleInput()
    {
   
    }

    public void PhysicsUpdate()
    {
    
    }

    public void Update()
    {
      
    }
}
