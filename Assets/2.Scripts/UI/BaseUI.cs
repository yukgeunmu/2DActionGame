using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uIManager;

    public virtual void Init(UIManager uIManager)
    {
        this.uIManager = uIManager;
    }

    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
