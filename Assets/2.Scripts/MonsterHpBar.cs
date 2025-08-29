using UnityEngine;

public class MonsterHpBar : MonoBehaviour
{
    public Transform fill;

    public void SetHpBar(int currentHealth, int maxHealth)
    {
        float ratio = currentHealth / maxHealth;
        fill.localScale = new Vector3(ratio, 1, 1);
    }
}
