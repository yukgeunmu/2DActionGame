using System;
using UnityEngine;


[Serializable]
public class PlayerAnimationData
{
    //Ground Sub-StateMachine�� ����� ����
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string MoveParameterName = "Move";

    //Air Sub-StateMachine�� ����� ����
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
        // ��? Hash�� �ٲٴ� �ɱ�?
        // ���ɻ����� �Ź� ���ڿ����� hash�� ��ȯ�ϱ� ������ ���ɻ� ���� ����
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
