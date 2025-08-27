using UnityEngine;

public class PoolManager
{
    public PoolRegistry PoolRegistry;

    private Transform transform;

    public void Init()
    {
        PoolRegistry = new PoolRegistry();
    }

}
