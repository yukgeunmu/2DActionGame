using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int damage);


    public Rigidbody2D MainRb();
}
