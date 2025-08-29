using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class Pool<T> where T : Component
{
    private ObjectPool<T> pool;
    private List<T> allObjects = new();

    public Pool(T _prefab, Transform _parent = null)
    {
        pool = new ObjectPool<T>(
            createFunc: () =>
            {
                var obj = GameObject.Instantiate(_prefab, _parent);
                allObjects.Add(obj);
                return obj;

            },
            actionOnGet: obj => obj.gameObject.SetActive(true),
            actionOnRelease: obj => obj.gameObject.SetActive(false),
            actionOnDestroy: obj => GameObject.Destroy(obj.gameObject)
            );
    }

    public T Get() => pool.Get();

    public void Release(T obj) => pool.Release(obj);


    public List<T> GetAllObjects() => allObjects;

    public void DeactivateAllActive()
    {
        foreach (var obj in allObjects)
        {
            if (obj.gameObject.activeSelf)
                pool.Release(obj);
        }
    }

    //������ �ı�
    public void DestroyObject(T obj)
    {
        if (allObjects.Contains(obj))
        {
            pool.Release(obj);           // ���� Ǯ���� Release (��Ȱ��ȭ)
            GameObject.Destroy(obj.gameObject); // �׸��� �ı�
            allObjects.Remove(obj);     // ����Ʈ������ ����
        }
    }

    // ��� ������Ʈ �ı�
    public void DestroyAll()
    {
        foreach (var obj in allObjects)
        {
            if (obj != null)
                GameObject.Destroy(obj.gameObject);
        }
        allObjects.Clear();
    }


}