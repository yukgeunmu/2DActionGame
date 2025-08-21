using System;
using System.Collections.Generic;
using UnityEngine;

public class SocketManager : Singleton<SocketManager>
{
    private SocketIOUnity socket;

    private string serverUrl = "http://localhost:3000";


    protected override void Awake()
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

            DataManager.Instance.SetGameData(jsonData);
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

        socket.On("response", response =>
        {
            string jsonData = response.GetValue<string>();

            GameManager.Instance.player = JsonUtility.FromJson<Player>(jsonData);

        });
    }



    private void OnDestroy()
    {
        if (socket != null)
        {
            socket.Disconnect();
        }
    }
}