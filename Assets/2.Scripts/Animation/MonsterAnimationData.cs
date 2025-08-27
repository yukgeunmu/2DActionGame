using System;
using UnityEngine;

[Serializable]
public class MonsterAnimationData
{
    //Ground Sub-StateMachine�� ����� ����
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string MoveParameterName = "Move";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string NormalAttackParameterName = "NormalAttack";

    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }

    public int MoveParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int NormalAttackParameterHash { get; private set; }

    public void Initialize()
    {
        // ��? Hash�� �ٲٴ� �ɱ�?
        // ���ɻ����� �Ź� ���ڿ����� hash�� ��ȯ�ϱ� ������ ���ɻ� ���� ����
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        MoveParameterHash = Animator.StringToHash(MoveParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        NormalAttackParameterHash = Animator.StringToHash(NormalAttackParameterName);
    }
}
