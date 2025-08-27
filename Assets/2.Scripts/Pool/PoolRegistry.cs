using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolRegistry
{
    // ������ ������ƮǮ�� Type�� ���� Dictionary�� ����
    public Dictionary<Type, object> _typedPools = new();


    // Ǯ ����ϱ�
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

    // Ÿ�Կ� �´� ������Ʈ Ǯ���� ��������
    public T Get<T>() where T : Component
    {
        if (_typedPools.TryGetValue(typeof(T), out var obj))
        {
            return ((Pool<T>)obj).Get();
        }

        Debug.LogError($"No pool registered for type {typeof(T)}");
        return null;
    }

    // �� ����� ������Ʈ ��Ȱ��ȭ �ϱ�
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
}