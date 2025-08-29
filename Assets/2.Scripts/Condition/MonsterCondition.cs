using UnityEngine;

public class MonsterCondition : MonoBehaviour
{
    [field: SerializeField] public MonsterSO Data {  get; private set; }

    [field: SerializeField] public MonsterAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public MonsterController Controller { get; private set; }

    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public GameObject groundCheck;

    public MonsterStateMachine stateMachine;

    public IPoolable poolObject;

    public int health;

    private void Awake()
    {
        AnimationData.Initialize();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<MonsterController>();
        poolObject = GetComponentInChildren<IPoolable>();

        int p = Random.Range(-5,5);

        this.transform.position = new Vector2(p, 8);

        stateMachine = new MonsterStateMachine(this);
    }

    private void OnEnable()
    {
        SetMonsterData();
        health = Data.MonsterData.health;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Start()
    {
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


    public void SetMonsterData()
    {
        MonsterInfo monsterInfo = null ;
        Data.MonsterData.level = Managers.Game.MonsterLevel;
        Data.MonsterData.exp += Managers.Game.MonsterExp;

        for(int i = 0; i < Managers.Data.monsterInfoList.Count; i++)
        {
            if((int)Data.monsterNumber == Managers.Data.monsterInfoList[i].id)
            {
                monsterInfo = Managers.Data.monsterInfoList[i];
                break;
            }
        }

        // monsterInfo가 null이 아닌지 확인
        if (monsterInfo != null)
        {
            Data.MonsterData.health = monsterInfo.health + Data.MonsterData.level;
            Data.MonsterData.mana = monsterInfo.mana + Data.MonsterData.level;
            Data.MonsterData.attack = monsterInfo.attack + Data.MonsterData.level;
            Data.MonsterData.defence = monsterInfo.defence + Data.MonsterData.level;
            Data.MonsterData.agility = monsterInfo.agility + Data.MonsterData.level;
            Data.MonsterData.speed = monsterInfo.speed + Data.MonsterData.level;
        }
        else
        {
            Debug.LogWarning("몬스터 데이터를 찾을 수 없습니다: " + Data.monsterNumber);
        }

    }


}
