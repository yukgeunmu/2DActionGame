using System;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ResourceManager
{
    private string prefabLabel = "PooledPrefab";

    public async Task Init()
    {
        await LoadAssetAsync();
    }
    public async Task LoadAssetAsync()
    {
        // Addressables���� Label �������� ������ �ڵ� �ε�
        var handle = Addressables.LoadAssetsAsync<GameObject>(prefabLabel, null);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var go in handle.Result)
            {
                if (!go.TryGetComponent(out IPoolable component))
                {
                    Debug.LogWarning($"{go.name}�� Component�� �����ϴ�.");
                    continue;
                }

                Type type = component.GetType();
                if (Managers.Pool.PoolRegistry._typedPools.ContainsKey(type))
                {
                    Debug.LogWarning($"�ߺ� ��ϵ� Ÿ��: {type}");
                    continue;
                }

                // Pool ���� ����
                Transform transform = new GameObject(type + "_Pool").transform;
                transform.SetParent(Managers.Instance.transform);

                var poolType = typeof(Pool<>).MakeGenericType(type);
                var pool = Activator.CreateInstance(poolType, component, transform);

                Managers.Pool.PoolRegistry._typedPools[type] = pool;
            }
        }
        else
        {
            Debug.LogError("Addressables �ε� ����");
        }
    }

    public void LoadAnimatorController(string key, System.Action<RuntimeAnimatorController> onLoaded)
    {
        Addressables.LoadAssetAsync<RuntimeAnimatorController>(key).Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
                onLoaded?.Invoke(op.Result);
            else
                Debug.LogError($"AnimatorController {key} �ε� ����");
        };
    }

    public void LoadSpriteRenderImage(string key, System.Action<SpriteRenderer> onLoaded)
    {
        Addressables.LoadAssetAsync<SpriteRenderer>(key).Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
                onLoaded?.Invoke(op.Result);
            else
                Debug.LogError($"AnimatorController {key} �ε� ����");
        };
    }
}

    