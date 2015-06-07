using UnityEngine;
using System.Collections;

public class NameStick : MonoBehaviour {

	private Vector3 myPos = new Vector3 (0,1,0);
	private GameObject myPlay;
	private static string user = database.user;
	private GameObject Text;

	// Use this for initialization
	void Start () {
		myPlay = GameObject.Find (user + "/RollerBall");
		Text = GameObject.Find (user + "/Nametag");
	}
	
	// Update is called once per frame
	void Update () {
		Text.transform.position = myPlay.transform.position + myPos;
	}
}
