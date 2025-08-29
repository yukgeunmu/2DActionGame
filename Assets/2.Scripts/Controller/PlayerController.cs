using UnityEngine;
using UnityEngine.InputSystem;
using System;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{
    // InputPlayer 클래스는 생성하기 전에 작성한 클래스 이름
    public InputPlayer input { get; private set; }
    public InputPlayer.PlayerActionActions playerActions { get; private set; } //     input.PlayerAction 이거 생략 하기 위해

    public AttackTrigger AttackRange;


    private void Awake()
    {
        input = new InputPlayer();

        playerActions = input.PlayerAction;

        Camera.main.GetComponent<CameraMove>().SetTarget(this.transform);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
