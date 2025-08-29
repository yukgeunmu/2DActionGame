using UnityEngine;

public class PlayerDamageable : MonoBehaviour, IDamageable
{
    public PlayerCondition playerCondition;

    private void Awake()
    {
        playerCondition = GetComponentInParent<PlayerCondition>();
    }
    public void TakeDamage(int damage)
    {

        playerCondition.stateMachine.ChangeState(playerCondition.stateMachine.HurtState);

        int resultDamage = Mathf.Max(damage - playerCondition.Data.PlayerData.defence, 1);
        playerCondition.health = Mathf.Max(playerCondition.health - resultDamage, 0);

        float percentage = (float)playerCondition.health / playerCondition.Data.PlayerData.health;
        Managers.UI.gameUI.UpdateHpSlider(percentage);

        if (playerCondition.health <= 0)
        {
            Managers.Game.GameEnd(playerCondition);
            return;
        }

        Invoke(nameof(ChangeState), 0.3f);
    }

    public Rigidbody2D MainRb()
    {
        return playerCondition.rb;
    }


    public void ChangeState()
    {
        playerCondition.stateMachine.ChangeState(playerCondition.stateMachine.IdleState);
    }
}
