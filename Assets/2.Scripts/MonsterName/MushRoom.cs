using UnityEngine;

public class MushRoom : MonoBehaviour, IPoolable
{
    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<MushRoom>(this);
    }
}
