using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public AttackTrigger AttackRange;


    private void Awake()
    {
        AttackRange = GetComponentInChildren<AttackTrigger>(true);
    }
}
