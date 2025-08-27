using System;
using UnityEngine;


[Serializable]
public class PlayerAnimationData
{
    //Ground Sub-StateMachine에 사용할 정보
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string MoveParameterName = "Move";

    //Air Sub-StateMachine에 사용할 정보
    [SerializeField] private string airParameterName = "@Air";
    [SerializeField] private string jumpParameterName = "Jump";
    [SerializeField] private string fallParameterName = "Fall";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string NormalAttackParameterName = "NormalAttack";

    [SerializeField] private string hutParameterName = "Hurt";

    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }

    public int MoveParameterHash { get; private set; }

    public int AirParameterHash { get; private set; }
    public int JumpParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int NormalAttackParameterHash { get; private set; }

    public int HurtParameterHash { get; private set; }

    public void Initialize()
    {
        // 왜? Hash로 바꾸는 걸까?
        // 성능상으로 매번 문자열에서 hash로 변환하기 때문에 성능상 좋지 않음
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        MoveParameterHash = Animator.StringToHash(MoveParameterName);

        AirParameterHash = Animator.StringToHash(airParameterName);
        JumpParameterHash = Animator.StringToHash(jumpParameterName);
        FallParameterHash = Animator.StringToHash(fallParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        NormalAttackParameterHash = Animator.StringToHash(NormalAttackParameterName);

        HurtParameterHash = Animator.StringToHash(hutParameterName);
    }

}
