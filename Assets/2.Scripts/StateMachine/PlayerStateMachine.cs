using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerCondition PlayerCondition { get; }

    public PlayerIdleState IdleState { get; }
    public PlayerMoveState MoveState { get; }

    public PlayerJumpState JumpState { get; }

    public PlayerFallState FallState { get; }

    public PlayerHurtState HurtState { get; }

    public PlayerComboAttackState ComboAttackState { get; }

    public float MovementInput { get; set; }
    public float MovementSpeed { get; private set; }

    public float MovementSpeedModifier { get; set; } = 1.0f;

    public float JumpForce { get; private set; }

    public Transform MainCameraTransform { get; set; }

    public PlayerStateMachine(PlayerCondition player)
    {
        this.PlayerCondition = player;

        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
        JumpState = new PlayerJumpState(this);
        FallState = new PlayerFallState(this);
        HurtState = new PlayerHurtState(this);
        ComboAttackState = new PlayerComboAttackState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = PlayerCondition.Data.GroundData.BaseSpeed;
        JumpForce = PlayerCondition.Data.AirData.JumpForce;
    }


}
