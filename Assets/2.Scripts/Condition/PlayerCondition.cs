using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerCondition : MonoBehaviour
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public PlayerController Input { get; private set; }

    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public GameObject groundCheck;

    [field: SerializeField] public PlayerSO Data { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerController>();
        stateMachine = new PlayerStateMachine(this);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
        
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }


}
