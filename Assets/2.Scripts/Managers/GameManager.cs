using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager
{
    public Player player;
    public CharacterInfo characterInfo;
    public LevelInfo levelInfo;
    public int Count;
    public int StageNumber;
    public List<int> MonsterId;
    public int MonsterLevel = 1;
    public int MonsterExp = 1;
    public int SpawnMonster = 1;

    public void Init()
    {
        Count = 0;
        MonsterId = new List<int>();
        StageNumber = Managers.Data.stageList[0].stageLevel;
        MonsterLevel = Managers.Data.stageList[0].monsterLevel;
        MonsterExp = Managers.Data.stageList[0].stageExp;
        SpawnMonster = Managers.Data.stageList[0].spawn;

    }

    public void GameLogin()
    {
        Managers.UI.SetLoginUI();
        Debug.Log("로그인 들어가자");
    }

    public void GameStart(int characterInfoId, int levelInfoId, string nickName)
    {
        SetCharacterInfo(characterInfoId);
        SetLevelInfo(levelInfoId);
        player = new Player(0, characterInfoId, levelInfoId, nickName, 0, 0);
        Managers.Pool.PoolRegistry.Get<BaseMap>();
        Managers.Pool.PoolRegistry.Get<PlayerCondition>();
        Managers.UI.SetGameUI();
    }

    public void GameEnd(PlayerCondition player)
    {
        if (player.health <= 0)
        {
            Managers.Socket.SendSaveScorePlayer(this.player.id, this.player.exp, Count);
            DestroyObject();
            Init();
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("플레이어 사망");
        }
    }


    public void GameClear()
    {
        if (StageNumber >= 10)
        {
            Managers.Socket.SendSaveScorePlayer(player.id, player.exp, Count);
            DestroyObject();
            Init();
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Count % 10 == 0 && Count != 0)
        {
            NextStage();
        }
    }

    public void NextStage()
    {
        int nextStage = StageNumber;
        StageNumber = Managers.Data.stageList[nextStage].stageLevel;
        MonsterLevel = Managers.Data.stageList[nextStage].monsterLevel;
        MonsterExp = Managers.Data.stageList[nextStage].stageExp;
        SpawnMonster = Managers.Data.stageList[nextStage].spawn;

        Managers.UI.gameUI.StageText.text = StageNumber.ToString();
    }


    public void SetCharacterInfo(int characterInfoId)
    {
        for (int i = 0; i < Managers.Data.characterList.Count; i++)
        {
            if (Managers.Data.characterList[i].id == characterInfoId)
            {
                characterInfo = Managers.Data.characterList[i];
                return;
            }
        }
    }

    public void SetLevelInfo(int levelInfoId)
    {
        for (int i = 0; i < Managers.Data.levelInfoList.Count; i++)
        {
            if (Managers.Data.levelInfoList[i].id == levelInfoId)
            {
                levelInfo = Managers.Data.levelInfoList[i];
                return;
            }
        }
    }


    public void CreateItem(Transform transform)
    {
        int random = Random.Range(0,100);

        if(random >= 0 && random <= 30)
        {
            HealItem item = Managers.Pool.PoolRegistry.Get<HealItem>();

            item.CreatePosition(transform);
        } else if(random > 30 && random <= 60)
        {
            StrongItem item = Managers.Pool.PoolRegistry.Get<StrongItem>();

            item.CreatePosition(transform);
        } else if(random > 60)
        {
            PoisonItem item = Managers.Pool.PoolRegistry.Get<PoisonItem>();

            item.CreatePosition(transform);
        }

    }


    public void SpawnPositionMonster(MonsterCondition monsterCondition)
    {
        int playerPositionX = (int)monsterCondition.stateMachine.Target.transform.localPosition.x;

        int p = Random.Range(playerPositionX - 3, playerPositionX + 3);

        monsterCondition.transform.position = new Vector2(p, 8);
    }

    public void DestroyObject()
    {
        Managers.Pool.PoolRegistry.DestroyAll<Goblin>();
        Managers.Pool.PoolRegistry.DestroyAll<MushRoom>();
        Managers.Pool.PoolRegistry.DestroyAll<FlyingEye>();
        Managers.Pool.PoolRegistry.DestroyAll<Skeleton>();
        Managers.Pool.PoolRegistry.DestroyAll<PlayerCondition>();
        Managers.Pool.PoolRegistry.DestroyAll<BaseMap>();
    }

}
