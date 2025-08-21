using UnityEngine;

public class GameUI : BaseUI
{
    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
    }
}
