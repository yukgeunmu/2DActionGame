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
        // Addressables에서 Label 기준으로 프리팹 자동 로드
        var handle = Addressables.LoadAssetsAsync<GameObject>(prefabLabel, null);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var go in handle.Result)
            {
                if (!go.TryGetComponent(out IPoolable component))
                {
                    Debug.LogWarning($"{go.name}에 Component가 없습니다.");
                    continue;
                }

                Type type = component.GetType();
                if (Managers.Pool.PoolRegistry._typedPools.ContainsKey(type))
                {
                    Debug.LogWarning($"중복 등록된 타입: {type}");
                    continue;
                }

                // Pool 묶음 생성
                Transform transform = new GameObject(type + "_Pool").transform;
                transform.SetParent(Managers.Instance.transform);

                var poolType = typeof(Pool<>).MakeGenericType(type);
                var pool = Activator.CreateInstance(poolType, component, transform);

                Managers.Pool.PoolRegistry._typedPools[type] = pool;
            }
        }
        else
        {
            Debug.LogError("Addressables 로딩 실패");
        }
    }

    public void LoadAnimatorController(string key, System.Action<RuntimeAnimatorController> onLoaded)
    {
        Addressables.LoadAssetAsync<RuntimeAnimatorController>(key).Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
                onLoaded?.Invoke(op.Result);
            else
                Debug.LogError($"AnimatorController {key} 로드 실패");
        };
    }

    public void LoadSpriteRenderImage(string key, System.Action<SpriteRenderer> onLoaded)
    {
        Addressables.LoadAssetAsync<SpriteRenderer>(key).Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
                onLoaded?.Invoke(op.Result);
            else
                Debug.LogError($"AnimatorController {key} 로드 실패");
        };
    }
}

    