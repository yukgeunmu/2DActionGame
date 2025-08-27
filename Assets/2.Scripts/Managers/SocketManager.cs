using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

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

        socket.On("response", response =>
        {
            string jsonData = response.GetValue<string>();

            Managers.Data.SetPlayerData(jsonData);
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