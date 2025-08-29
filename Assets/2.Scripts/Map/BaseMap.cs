using UnityEngine;

public class BaseMap : MonoBehaviour, IPoolable
{

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnMonster), 0, 5);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnMonster));
    }


    private void SpawnMonster()
    {
        int p = Random.Range(0, 100);

        for (int i = 0; i < Managers.Game.SpawnMonster; i++)
        {
            if (p <= 50) Managers.Pool.PoolRegistry.Get<Goblin>();
            else if (p > 50 && p <= 80) Managers.Pool.PoolRegistry.Get<MushRoom>();
            else if (p > 80 && p <= 95) Managers.Pool.PoolRegistry.Get<FlyingEye>();
            else Managers.Pool.PoolRegistry.Get<Skeleton>();
        }
    }

    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<BaseMap>(this);
    }
}
