using System.Drawing.Text;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;


    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        this.stateMachine = playerStateMachine;
        groundData = stateMachine.PlayerCondition.Data.GroundData;
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerController input = stateMachine.PlayerCondition.Input;
        input.playerActions.Move.canceled += OnMoveCanceled;
        input.playerActions.Jump.started += OnJumpStarted;
        input.playerActions.Jump.canceled += OnJumpCanceled;
        input.playerActions.Attack.started += OnAttackStared;
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerController input = stateMachine.PlayerCondition.Input;
        input.playerActions.Move.canceled -= OnMoveCanceled;
        input.playerActions.Jump.started -= OnJumpStarted;
        input.playerActions.Jump.canceled -= OnJumpCanceled;
        input.playerActions.Attack.started -= OnAttackStared;
    }

    protected virtual void OnMoveCanceled(InputAction.CallbackContext context)
    {

    }


    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnJumpCanceled(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnAttackStared(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnAttackCanceled(InputAction.CallbackContext context)
    {

    }



    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
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
        stateMachine.PlayerCondition.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHach)
    {
        stateMachine.PlayerCondition.Animator.SetBool(animationHach, false);
    }

    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.PlayerCondition.Input.playerActions.Move.ReadValue<float>();
    }

    private void Move()
    {
        stateMachine.PlayerCondition.rb.linearVelocityX = stateMachine.MovementInput * stateMachine.MovementSpeed;
    }


    protected void Jump()
    {
        Rigidbody2D rb = stateMachine.PlayerCondition.rb;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, stateMachine.JumpForce);
    }

    private void Rotate()
    {
        float input = stateMachine.MovementInput;

        if (input < 0)
        {
            stateMachine.PlayerCondition.spriteRenderer.flipX = true;
            stateMachine.PlayerCondition.Input.AttackRange.transform.localPosition = new Vector3(-1f,-0.7f);
        }
        else if (input > 0)
        {
            stateMachine.PlayerCondition.spriteRenderer.flipX = false;
            stateMachine.PlayerCondition.Input.AttackRange.transform.localPosition = new Vector3(1f, -0.7f);
        }
    }

    protected bool isGround()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        return Physics2D.Raycast(stateMachine.PlayerCondition.groundCheck.transform.position, Vector2.down, 0.1f, groundLayer);
    }

    protected bool isMonster()
    {
        LayerMask monsterLayer = LayerMask.GetMask("Monster");

        return Physics2D.Raycast(stateMachine.PlayerCondition.groundCheck.transform.position, Vector2.down, 0.1f, monsterLayer);
    }
}
