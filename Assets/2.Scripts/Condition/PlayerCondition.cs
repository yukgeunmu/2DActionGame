using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.GraphicsBuffer;

public class PlayerCondition : MonoBehaviour, IPoolable
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public PlayerController Input { get; private set; }

    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public GameObject groundCheck;


    [field: SerializeField] public PlayerSO Data { get; private set; }

    public int health { get; set; }


    public PlayerStateMachine stateMachine;


    private void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SetPlayerData();
        health = Data.PlayerData.health;
        SelectSprite(Managers.Game.characterInfo.id);
        Managers.Resource.LoadAnimatorController(Managers.Game.characterInfo.id.ToString(), (controller) =>
        {
            Animator.runtimeAnimatorController = controller;
            stateMachine = new PlayerStateMachine(this);
            stateMachine.ChangeState(stateMachine.IdleState);
        });
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (stateMachine != null)
        {
            stateMachine.HandleInput();
            stateMachine.Update();
            LevelUp();
        }
    }

    private void FixedUpdate()
    {
        if(stateMachine != null)
        {
            stateMachine.PhysicsUpdate();
        }
;
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
        Data.PlayerData.exp = 0;
    }


    public void LevelUp()
    {
        if (Managers.Game.player.exp >= Data.PlayerData.maxExp)
        {
            Managers.Game.player.levelInfoId += 1;
            Managers.Game.SetLevelInfo(Managers.Game.player.levelInfoId);

            Data.PlayerData.health += Managers.Game.levelInfo.statPoints;
            Data.PlayerData.mana += Managers.Game.levelInfo.statPoints;
            Data.PlayerData.attack += Managers.Game.levelInfo.statPoints;
            Data.PlayerData.defence += Managers.Game.levelInfo.statPoints;
            Data.PlayerData.agility += Managers.Game.levelInfo.statPoints;
            Data.PlayerData.speed += Managers.Game.levelInfo.statPoints;
            Data.PlayerData.level = Managers.Game.levelInfo.level;
            Data.PlayerData.maxExp = Managers.Game.levelInfo.requiredExp;
            Managers.Game.player.exp = Mathf.Max(Managers.Game.player.exp - Data.PlayerData.maxExp, 0);

            health = Data.PlayerData.health;
            Managers.UI.gameUI.UpdateHpSlider(1);
            Managers.UI.gameUI.UpdateLevelText(Data.PlayerData.level);


        }

        Managers.UI.gameUI.UpdateExp((float)Managers.Game.player.exp / Data.PlayerData.maxExp);
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, Data.PlayerData.health);
        Managers.UI.gameUI.UpdateHpSlider(health / Data.PlayerData.health);
    }

    public void Strong(int amount)
    {
        health = Mathf.Min(Data.PlayerData.attack + amount, 20);
    }

    public void SelectSprite(int characterId)
    {
        Debug.Log("캐릭터아이디:" + characterId);

        Sprite target = null;
        switch (characterId)
        {
            case (int)Enums.SelectCharacter.Aria:
                target = spriteRenderer.sprite = Data.characterSprite[0];
                break;
            case (int)Enums.SelectCharacter.Lowell:
                target = spriteRenderer.sprite = Data.characterSprite[1];
                break;
            case (int)Enums.SelectCharacter.Elena:
                target = spriteRenderer.sprite = Data.characterSprite[2];
                break;
            case (int)Enums.SelectCharacter.Masamune:
                target = spriteRenderer.sprite = Data.characterSprite[3];
                break;

        }

        spriteRenderer.sprite = target;
        Debug.Log("적용된 스프라이트: " + (target != null ? target.name : "null"));
    }

    public void Release()
    {

    }
}
