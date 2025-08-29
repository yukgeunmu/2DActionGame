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
        Debug.Log("소켓 완료");

        Pool.Init();
        Debug.Log("풀 완료");

        await Resource.Init();
        Debug.Log("리소스 완료");

        Data.Init();
        Debug.Log("데이터 완료");


        Game.Init();
        Debug.Log("게임 완료");


        Map.Init();
        Debug.Log("맵 완료");


        Game.GameLogin();   

    }


    private void OnApplicationQuit()
    {
        Socket.OnDestroy();
        Debug.Log("종료 감지");
    }



}
