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
    public GameOverUI gameOverUI;

    public void SetLoginUI()
    {
        if(gameOverUI != null)
        {
            gameOverUI.Release();
        }

        Managers.Pool.PoolRegistry.Get<LoginUI>();
        Debug.Log("로그인 화면");
    }

    public void SetGameUI()
    {
       loginUI.Release();
       Managers.Pool.PoolRegistry.Get<GameUI>();
    }

    public void SetGameOverUI()
    {
        gameUI.Release();
        Managers.Pool.PoolRegistry.Get<GameOverUI>();
        gameOverUI.SetScore();
        gameOverUI.SetPlayerList();
    }

}
