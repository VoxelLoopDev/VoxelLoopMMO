using UnityEngine;
using System.Collections;

public class database : MonoBehaviour {

    //Core
    public static string user;
    public bool testMode;
    public string testUsername;

    //Server
    public static Object spawnedplayer;
    public GameObject playerPrefab;
    private const string typeName = "VoxelLoopMMO";
    private const string gameName = "LocalDev #1";

	// Use this for initialization
	void Start () {
        if (testMode == true) {
            print("Test mode is enabled, starting test mode.");
            user = testUsername;
            startServer();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void startServer ()
    {
        print("Starting main server on port 25000!");
        Network.InitializeServer(2500, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
    }

    void OnServerInitialized()
    {
        print("Server running, listening.");
        connectToServer();
    }

    void connectToServer ()
    {
        print("Connecting to server...");
        Network.Connect("127.0.0.1", 25000);
    }

    void OnConnectedToServer ()
    {
        print("Connected to server, spawning player!");
        SpawnPlayer();
    }

    void SpawnPlayer ()
    {
        print("Spawning Player!");
        Object newPlayer = Network.Instantiate(playerPrefab, new Vector3(400f, 25f, 100f), Quaternion.identity, 0);
        newPlayer.name = user;
        spawnedplayer = newPlayer;
    }
}
