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
        Debug.Log("로그인 화면");
    }

    public void SetGameUI()
    {
       Managers.Pool.PoolRegistry.Get<GameUI>();
    }
}
