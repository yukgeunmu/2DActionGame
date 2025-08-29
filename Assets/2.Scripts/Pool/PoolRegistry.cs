using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolRegistry
{
    // 관리할 오브젝트풀을 Type에 따라 Dictionary로 관리
    public Dictionary<Type, object> _typedPools = new();


    // 풀 등록하기
    public void Register<T>(T prefab, Transform parent = null) where T : Component
    {
        Type type = typeof(T);
        if (_typedPools.ContainsKey(type))
        {
            Debug.LogWarning($"Pool for {type} already registered.");
            return;
        }

        var pool = new Pool<T>(prefab, parent ?? Managers.Instance.transform);
        _typedPools[type] = pool;
    }

    // 타입에 맞는 오브젝트 풀에서 가져오기
    public T Get<T>() where T : Component
    {
        if (_typedPools.TryGetValue(typeof(T), out var obj))
        {
            return ((Pool<T>)obj).Get();
        }

        Debug.LogError($"No pool registered for type {typeof(T)}");
        return null;
    }

    // 다 사용한 오브젝트 비활성화 하기
    public void Release<T>(T obj) where T : Component
    {
        if (_typedPools.TryGetValue(typeof(T), out var poolObj))
        {
            ((Pool<T>)poolObj).Release(obj);
        }
        else
        {
            Debug.LogWarning($"Tried to release unregistered object type: {typeof(T)}");
        }
    }




    /*  
         사용예시
         List<Monster1> allMonster1s = Managers.Pool.PoolRegistry.GetAll<Monster1>();

        foreach (var m in allMonster1s)
        {
            Debug.Log(m.name);
        }
    */
    public List<T> GetAll<T>() where T : Component
    {
        if (_typedPools.TryGetValue(typeof(T), out var obj))
        {
            return ((Pool<T>)obj).GetAllObjects();
        }
        return new List<T>();
    }



    // Monster1 활성화된 오브젝트 모두 비활성화
    //Managers.Pool.PoolRegistry.DeactivateAllActive<Monster1>();
    public void DeactivateAllActive<T>() where T : Component
    {
        if (_typedPools.TryGetValue(typeof(T), out var poolObj))
        {
            ((Pool<T>)poolObj).DeactivateAllActive();
        }
    }

    // 해당 풀 전부 파괴
    public void DestroyAll<T>() where T : Component
    {
        if (_typedPools.TryGetValue(typeof(T), out var poolObj))
        {
            ((Pool<T>)poolObj).DestroyAll();
        }
    }

    //개별 선택 파괴
    public void DestroyObject<T>(T obj) where T : Component
    {
        if (_typedPools.TryGetValue(typeof(T), out var poolObj))
        {
            ((Pool<T>)poolObj).DestroyObject(obj);
        }
        else
        {
            Debug.LogWarning($"Tried to release unregistered object type: {typeof(T)}");
        }
    }

}