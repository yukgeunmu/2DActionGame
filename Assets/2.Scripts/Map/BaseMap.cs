using UnityEngine;

public class BaseMap : MonoBehaviour, IPoolable
{

    public void Awake()
    {
    }


    private void Start()
    {

        InvokeRepeating(nameof(SpawnMonster), 0, 10);
    }


    private void SpawnMonster()
    {
        int p = Random.Range(0, 12);

        Managers.Pool.PoolRegistry.Get<Goblin>();
    }

    public void Release()
    {

    }
}
