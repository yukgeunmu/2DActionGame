using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IPoolable obj))
        {
            if(collision.TryGetComponent(out PlayerCondition player))
            {
                player.transform.position = new Vector2(0f,8.0f);
            }
            else
            {
                obj.Release();
            }
        }
    }
}
