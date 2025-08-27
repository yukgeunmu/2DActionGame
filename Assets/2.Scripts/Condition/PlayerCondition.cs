using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerCondition : MonoBehaviour, IDamageable, IPoolable
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public PlayerController Input {  get; private set; }

    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public GameObject groundCheck;

    [field: SerializeField] public PlayerSO Data { get; private set; }

    private int health;


    private PlayerStateMachine stateMachine;


    private void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SetPlayerData();

        health = Data.PlayerData.health;

        Managers.Resource.LoadAnimatorController(Managers.Game.player.characterInfoId.ToString(), (controller) =>
        {
            Animator.runtimeAnimatorController = controller;
        });
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);

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

    public void SetPlayerData()
    {
        Data.PlayerData.health = Managers.Game.characterInfo.health;
        Data.PlayerData.mana = Managers.Game.characterInfo.mana;
        Data.PlayerData.attack = Managers.Game.characterInfo.attack;
        Data.PlayerData.defence = Managers.Game.characterInfo.defence;
        Data.PlayerData.agility = Managers.Game.characterInfo.agility;
        Data.PlayerData.speed = Managers.Game.characterInfo.speed;
        Data.PlayerData.level = Managers.Game.levelInfo.level;
        Data.PlayerData.statPoints = Managers.Game.levelInfo.statPoints;
        Data.PlayerData.maxExp = Managers.Game.levelInfo.requiredExp;
        Data.PlayerData.exp = Managers.Game.player.exp;
    }

    public void TakeDamage(int damage)
    {

        stateMachine.ChangeState(stateMachine.HurtState);

        int resultDamage = Mathf.Max(damage - Data.PlayerData.defence,1);
        health = Mathf.Max(health - resultDamage, 0);

        float percentage = (float)health / Data.PlayerData.health;
        Managers.UI.gameUI.UpdateHpSlider(percentage);

        if(health <= 0)
        {
            Managers.Game.GameEnd(this);
            return;
        }

        Invoke(nameof(ChangeState), 0.3f);
        
    }

    public void ChangeState()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    public void Release()
    {

    }
}
