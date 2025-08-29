using UnityEngine;

public class MonsterDamageable : MonoBehaviour, IDamageable
{
    public MonsterCondition monsterCondition;
    public Transform hpBar;

    private void Awake()
    {
        monsterCondition = GetComponentInParent<MonsterCondition>();

    }

    public void TakeDamage(int damage)
    {
        int resultDamage = Mathf.Max(damage - monsterCondition.Data.MonsterData.defence, 1);
        monsterCondition.health = Mathf.Max(monsterCondition.health - resultDamage, 0);

        monsterCondition.stateMachine.ChangeState(monsterCondition.stateMachine.HurtState);
        float ratio = (float)monsterCondition.health / monsterCondition.Data.MonsterData.health;

        hpBar.localScale = new Vector3(ratio,1,1);

        if (monsterCondition.health <= 0)
        {
            Managers.Game.Count++;
            Managers.Game.CreateItem(this.transform);
            Managers.Game.player.exp += Managers.Game.MonsterExp;
            Managers.UI.gameUI.UpdateCount(Managers.Game.Count);

            Managers.Game.GameClear();

            monsterCondition.poolObject.Release();

            monsterCondition.health = monsterCondition.Data.MonsterData.health;

            int p = Random.Range(0, 15);

            Managers.Game.SpawnPositionMonster(monsterCondition);

            hpBar.localScale = new Vector3(1, 1, 1);
        }

        Invoke(nameof(ChangeState), 0.3f);
    }

    private void ChangeState()
    {
        monsterCondition.stateMachine.ChangeState(monsterCondition.stateMachine.IdleState);
    }

    public Rigidbody2D MainRb()
    {
        return monsterCondition.rb;
    }

}
