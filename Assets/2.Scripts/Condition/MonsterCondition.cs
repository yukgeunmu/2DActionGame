using UnityEngine;

public class MonsterCondition : MonoBehaviour, IDamageable
{
    [field: SerializeField] public MonsterSO Data {  get; private set; }

    [field: SerializeField] public MonsterAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public MonsterController Controller { get; private set; }

    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public GameObject groundCheck;

    private MonsterStateMachine stateMachine;

    public IPoolable poolObject;

    private int health;

    private void Awake()
    {
        AnimationData.Initialize();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<MonsterController>();
        poolObject = GetComponentInChildren<IPoolable>();

        SetMonsterData();

        health = Data.MonsterData.health;

        this.transform.position = Managers.Map.points[0];

        stateMachine = new MonsterStateMachine(this);
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

    public void TakeDamage(int damage)
    {
        int resultDamage = Mathf.Max(damage - Data.MonsterData.defence, 1);
        health = Mathf.Max(health - resultDamage, 0);


        if (health <= 0)
        {
            Managers.Game.Count++;

            Managers.UI.gameUI.UpdateCount(Managers.Game.Count);

            poolObject.Release();

            health = Data.MonsterData.health;

            int p = Random.Range(0, 12);

            this.transform.position = Managers.Map.points[p];
        }
    }

    public void SetMonsterData()
    {
        MonsterInfo monsterInfo = null ;

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
            Data.MonsterData.health = monsterInfo.health;
            Data.MonsterData.mana = monsterInfo.mana;
            Data.MonsterData.attack = monsterInfo.attack;
            Data.MonsterData.defence = monsterInfo.defence;
            Data.MonsterData.agility = monsterInfo.agility;
            Data.MonsterData.speed = monsterInfo.speed;
            Data.MonsterData.exp = monsterInfo.exp;
        }
        else
        {
            Debug.LogWarning("몬스터 데이터를 찾을 수 없습니다: " + Data.monsterNumber);
        }

    }


}
