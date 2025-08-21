using UnityEngine;



public enum UIState
{
    Login,
    Game
}



public class UIManager : Singleton<UIManager>
{
    public UIState currentState =  UIState.Login;
    public UIState preState = UIState.Login;


    private LoginUI loginUI = null;
    private GameUI gameUI = null;

    protected override void Awake()
    {
        base.Awake();
        loginUI = GetComponentInChildren<LoginUI>(true);
        loginUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
    }

    private void ChangeState(UIState state)
    {
        currentState = state;

        loginUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
    }


    public void OnClickGame()
    {
        ChangeState(UIState.Game);
    }



}
