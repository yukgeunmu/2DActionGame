using PimDeWitte.UnityMainThreadDispatcher;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SocketManager
{
    private SocketIOUnity socket;

    private string serverUrl = "http://localhost:3000";

    public string LoadDataJson { get; private set; }

    public void Init()
    {
        socket = new SocketIOUnity(serverUrl);

        socket.OnConnected += (sender, e) =>
        {
            Debug.Log("Socket.IO Connected");

            LoadData();
        };

        socket.Connect();
    }

    public void LoadData()
    {
        socket.Emit("loadData");

        socket.On("sendData", response =>
        {
            string jsonData = response.GetValue<string>();

            Debug.Log("Data loading from server is complete: " + jsonData);

            LoadDataJson = jsonData;
        });
    }

    public void SendCreatePlayer(int characterInfoId, int levelInfoId, string nickName)
    {

        var data = new Dictionary<string, object>()
        {
            { "handlerId", 1 },
            { "characterInfoId", characterInfoId },
            { "levelInfoId", levelInfoId },
            { "nickName", nickName }
        };

        socket.Emit("event", data);

        socket.On("response", (response) =>
        {
            string jsonData = response.GetValue<string>();
            Managers.Data.SetPlayerData(jsonData);

            socket.Off("response");
        });
    }

    public void SendSaveScorePlayer(int id, int exp, int score)
    {
        var data = new Dictionary<string, object>()
        {
            { "handlerId", 2 },
            { "id", id },
            { "exp", exp },
            { "score", score }
        };

        socket.Emit("event", data);

        socket.On("response", response =>
        {
            string jsonData = response.GetValue<string>();
            PlayerListWrapper wrapper = JsonUtility.FromJson<PlayerListWrapper>(jsonData);
            Managers.Data.playerList = wrapper.players;

            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                Managers.UI.SetGameOverUI();
            });

            socket.Off("response");
        });
    }

    public void SendInventoryItem(int itemId, int playerId)
    {
        var data = new Dictionary<string, object>()
        {
            { "handlerId", 3 },
            { "playerId", playerId },
            { "itemId",  itemId },
        };

        socket.Emit("event", data);

        socket.On("response", response =>
        {
            string jsonData = response.GetValue<string>();
            Debug.Log(jsonData);
            Item item = JsonUtility.FromJson<Item>(jsonData);
            Debug.Log($"인벤토리 저장: {item.name}");

            socket.Off("response");
        });
    }

    public void OnDestroy()
    {
        if (socket != null)
        {
            socket.Disconnect();
        }
    }
}