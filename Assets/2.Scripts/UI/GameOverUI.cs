using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI, IPoolable
{
    public TextMeshProUGUI ScoreText;
   

    public Transform IdContainer;
    public Transform NickNameContainer;
    public Transform ScoreContainer;

    public Button LobbyBtn;

    public List<TextMeshProUGUI> NickNameTextList;
    public List<TextMeshProUGUI> ScoreTextList;


    public List<Player> players;

    private void Awake()
    {
        Init(Managers.UI);
    }


    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
        uIManager.gameOverUI = this;
        LobbyBtn.onClick.AddListener(SetLobby);      
    }


    public void SetLobby()
    {
        uIManager.SetLoginUI();
    }


    public void SetScore()
    {
        ScoreText.text = Managers.Game.Count.ToString();
    }

    public void SetPlayerList()
    {
        for(int i = 0; i < Managers.Data.playerList.Count; i++)
        {
            NickNameTextList[i].text =  Managers.Data.playerList[i].nickName;
            ScoreTextList[i].text = Managers.Data.playerList[i].score.ToString();
        }
    }

    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<GameOverUI>(this);
    }


}
