using UnityEngine;
using UnityEngine.Pool;


public class Pool<T> where T : Component
{
    private ObjectPool<T> pool;

    public Pool(T _prefab, Transform _parent = null)
    {
        pool = new ObjectPool<T>(
            createFunc: () => GameObject.Instantiate(_prefab, _parent),
            actionOnGet: obj => obj.gameObject.SetActive(true),
            actionOnRelease: obj => obj.gameObject.SetActive(false),
            actionOnDestroy: obj => GameObject.Destroy(obj.gameObject)
            );
    }

    public T Get() => pool.Get();

    public void Release(T obj) => pool.Release(obj);

}