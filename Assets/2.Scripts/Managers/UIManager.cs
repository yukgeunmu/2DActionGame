using UnityEngine;



public enum UIState
{
    Login,
    Game
}

public class UIManager
{
    public UIState currentState =  UIState.Login;
    public UIState preState = UIState.Login;

    public LoginUI loginUI;
    public GameUI gameUI;

    public void SetLoginUI()
    {
        Managers.Pool.PoolRegistry.Get<LoginUI>();
        Debug.Log("�α��� ȭ��");
    }

    public void SetGameUI()
    {
       Managers.Pool.PoolRegistry.Get<GameUI>();
    }
}
