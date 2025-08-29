using UnityEngine;

public class StrongItem : MonoBehaviour, IPoolable
{
    public ItemSO itemData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerCondition target))
        {
            target.Strong(itemData.data.attack);
            Managers.Socket.SendInventoryItem(itemData.data.id, Managers.Game.player.id);
            Release();
        }
    }

    private void Awake()
    {
        for (int i = 0; i < Managers.Data.itemList.Count; i++)
        {
            if (itemData.data.id == Managers.Data.itemList[i].id)
            {
                itemData.data = Managers.Data.itemList[i];
            }
        }
    }
    public void CreatePosition(Transform transform)
    {
        this.transform.position = transform.position;
    }

    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<StrongItem>(this);
    }
}
