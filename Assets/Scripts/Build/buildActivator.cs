using UnityEngine;
using System.Collections;

public class buildActivator : MonoBehaviour {

    //This script is used to activate the buildCore when the user enters a plot of land they own.
    //-Curtis

    //Core
    public static string user;

    //Build
    private GameObject playerCam;

	// Use this for initialization
	void Start () {
        print("Build Module is active, waiting for client to ender buildable zone.");
        playerCam = GameObject.Find(user + "/Camera");
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        user = database.user;
//        print("Hit object: " + col); //Debugging
//        if (col.gameObject.name == user + "Land")
        if(col.gameObject.name == user + "Land")
        {
            if (Network.isClient && GetComponentInChildren<NetworkView>().isMine)
            {
                playerCam = GameObject.Find(user + "/Camera");
                print("Entered a buildable area, activating build tools.");
                ((Behaviour)playerCam.GetComponent("buildCore")).enabled = true;
            }
        }
    }
}
