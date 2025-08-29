using UnityEngine;

public class FlyingEye : MonoBehaviour, IPoolable
{
    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<FlyingEye>(this);
    }
}
