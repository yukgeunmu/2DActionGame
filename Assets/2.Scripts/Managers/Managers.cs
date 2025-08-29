using System.Threading.Tasks;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance { get; private set; }
    public static readonly GameManager Game = new();
    public static readonly DataManager Data = new();
    public static readonly SocketManager Socket = new();
    public static readonly UIManager UI = new();
    public static readonly PoolManager Pool = new();
    public static readonly ResourceManager Resource = new();
    public static readonly MapManager Map = new();

    protected async Task Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

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


    private void OnApplicationQuit()
    {
        Socket.OnDestroy();
        Debug.Log("���� ����");
    }



}
