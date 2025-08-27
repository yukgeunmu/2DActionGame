using System.Data.Common;
using UnityEngine;

public class GameManager
{
    public Player player;
    public CharacterInfo characterInfo;
    public LevelInfo levelInfo;
    public int Count;
    public int StageNumber;

    public void Init()
    {
        Count = 0;
        StageNumber = 1;
        
    }

    public void GameLogin()
    {
        Managers.UI.SetLoginUI();
        Debug.Log("로그인 들어가자");
    }

    public void GameStart()
    {
        SetCharacterInfo();
        SetLevelInfo();

        Managers.Pool.PoolRegistry.Get<BaseMap>();
        Managers.Pool.PoolRegistry.Get<PlayerCondition>();
        Managers.UI.SetGameUI();
    }

    public void GameEnd(PlayerCondition player)
    {
        if (player.Data.PlayerData.health <= 0)
        {
            Debug.Log("플레이어 사망");
        }
    }

   public void NextStage()
    {

    }

    public void SetCharacterInfo()
    {
        for (int i = 0; i < Managers.Data.characterList.Count; i++)
        {
            if (Managers.Data.characterList[i].id == player.characterInfoId)
            {
                characterInfo = Managers.Data.characterList[i];
                return;
            }
        }
    }

    public void SetLevelInfo()
    {
        for(int i = 0; i < Managers.Data.levelInfoList.Count; i++)
        {
            if(Managers.Data.levelInfoList[i].id == player.levelInfoId)
            {
                levelInfo = Managers.Data.levelInfoList[i];
                return;
            }
        }
    }


}
