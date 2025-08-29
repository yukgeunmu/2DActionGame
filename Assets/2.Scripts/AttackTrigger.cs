using System;
using System.Collections;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{

    public int damage;
    public LayerMask targetLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & targetLayer) != 0)
        {
            if (collision.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(damage);

                Vector2 direction = (collision.transform.position.x > transform.position.x)
                        ? new Vector2(1f, 0f).normalized
                        : new Vector2(-1f, 0f).normalized;

                StartCoroutine(Knockback(target.MainRb().transform, direction, 0.1f, 2f));

            }
        }
    }

    IEnumerator Knockback(Transform target, Vector2 dir, float duration, float distance)
    {
        Vector2 start = target.position;
        Vector2 end = start + dir * distance;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            target.position = Vector2.Lerp(start, end, elapsed / duration);
            yield return null;
        }
    }
}
