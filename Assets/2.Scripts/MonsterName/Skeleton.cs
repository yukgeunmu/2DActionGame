using UnityEngine;

public class Skeleton : MonoBehaviour, IPoolable
{
    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<Skeleton>(this);
    }
}
