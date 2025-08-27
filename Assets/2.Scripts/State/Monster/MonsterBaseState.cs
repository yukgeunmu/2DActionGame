using UnityEngine;

public class MonsterBaseState : IState
{

    protected MonsterStateMachine stateMachine;

    protected MonsterSO monsterData;

    public MonsterBaseState(MonsterStateMachine monsterStateMachine)
    {
        stateMachine = monsterStateMachine;
        monsterData = stateMachine.MonsterCondition.Data;
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {
 
    }

    public virtual void HandleInput()
    {
   
    }

    public virtual void PhysicsUpdate()
    {
    
    }

    public virtual void Update()
    {
        Move();
        Rotate();

    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.MonsterCondition.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.MonsterCondition.Animator.SetBool(animationHash, false);
    }

    private void Move()
    {
        Vector2 dir = (stateMachine.Target.transform.position - stateMachine.MonsterCondition.transform.position).normalized;

        stateMachine.MonsterCondition.rb.linearVelocity = new Vector2(stateMachine.MovementSpeed*stateMachine.MovementSpeedModifier*dir.x, stateMachine.MonsterCondition.rb.linearVelocityY);

    }

    private void Rotate()
    {
        Vector2 dir = (stateMachine.Target.transform.position - stateMachine.MonsterCondition.transform.position).normalized;

        if (dir.x < 0)
        {
            stateMachine.MonsterCondition.spriteRenderer.flipX = true;
            stateMachine.MonsterCondition.Controller.AttackRange.transform.localPosition = new Vector2(-1f, -0.7f);
        }
        else if (dir.x > 0)
        {
            stateMachine.MonsterCondition.spriteRenderer.flipX = false;
            stateMachine.MonsterCondition.Controller.AttackRange.transform.localPosition = new Vector2(1f, -0.7f);
        }
    }


    protected bool IsInChaseRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.MonsterCondition.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.MonsterCondition.Data.PlayerChasingRange * stateMachine.MonsterCondition.Data.PlayerChasingRange;
    }

    protected bool IsinAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.MonsterCondition.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.MonsterCondition.Data.AttackRange * stateMachine.MonsterCondition.Data.AttackRange;
    }

    protected bool isGround()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        return Physics2D.Raycast(stateMachine.MonsterCondition.groundCheck.transform.position, Vector2.down, 0.1f, groundLayer);
    }
}
