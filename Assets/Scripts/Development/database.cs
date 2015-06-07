using UnityEngine;
using System.Collections;

public class database : MonoBehaviour {

    //This file is purely for testing, it replicates the database.cs usually used for the login system.
    //Other scripts can refer to this like they would the standard database.cs.
    //-Curtis

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
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI () {
        if (GUI.Button(new Rect(10, 160, 150, 30), "Start local server"))
        {
            print("Starting Local Server...");
            startServer();
        }
        if (GUI.Button(new Rect(10, 200, 150, 30), "Connect to local server"))
        {
            print("Connecting to Local Server...");
            connectToServer();
        }
    }

    void startServer ()
    {
        print("Starting main server on port 25000!");
        Network.InitializeServer(32, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
    }

    void OnServerInitialized()
    {
        print("Server running, listening.");
    }

    void connectToServer ()
    {
        print("Connecting to server...");
        Network.Connect("127.0.0.1", 25000);
    }

    void OnConnectedToServer ()
    {
        if (Network.isClient)
        {
            print("Connected to server, spawning player!");
            print("Username is: " + user);
            SpawnPlayer();
        }
    }

    void SpawnPlayer ()
    {
        print("Spawning Player!");
        Object newPlayer = Network.Instantiate(playerPrefab, new Vector3(400f, 25f, 100f), Quaternion.identity, 0);
        newPlayer.name = user;
        spawnedplayer = newPlayer;
    }
}
