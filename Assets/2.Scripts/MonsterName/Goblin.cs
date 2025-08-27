using UnityEngine;

public class Goblin : MonoBehaviour, IPoolable
{
    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<Goblin>(this);
    }
}
