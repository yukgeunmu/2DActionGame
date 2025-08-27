using System.Threading.Tasks;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    public static readonly GameManager Game = new();
    public static readonly DataManager Data = new();
    public static readonly SocketManager Socket = new();
    public static readonly UIManager UI = new();
    public static readonly PoolManager Pool = new();
    public static readonly ResourceManager Resource = new();
    public static readonly MapManager Map = new();

    protected override async Task Awake()
    {
        await base.Awake();

        Socket.Init();
        Debug.Log("���� �Ϸ�");

        Pool.Init();
        Debug.Log("Ǯ �Ϸ�");

        await Resource.Init();
        Debug.Log("���ҽ� �Ϸ�");

        Data.Init();
        Debug.Log("������ �Ϸ�");


        Game.Init();
        Debug.Log("���� �Ϸ�");


        Map.Init();
        Debug.Log("�� �Ϸ�");


        Game.GameLogin();   

    }




}
