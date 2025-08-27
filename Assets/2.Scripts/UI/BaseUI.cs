using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uIManager;

    public virtual void Init(UIManager uIManager)
    {
        this.uIManager = uIManager;
    }

}
