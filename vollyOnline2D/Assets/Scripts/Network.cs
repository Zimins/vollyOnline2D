using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Network : MonoBehaviour {

	static SocketIOComponent socket;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		socket = GetComponent<SocketIOComponent> ();
		socket.On ("open", OnConnected);
		socket.On ("spawn", OnSpawned);
		socket.On ("moveRight", MoveRight);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") > 0) {
			socket.Emit ("moveRight");
			Debug.Log ("rightkey");
		} else if (Input.GetAxis ("Horizontal") < 0) {
			
		} else {
			
		}
	}

	void  MoveRight(SocketIOEvent e)
	{
		Debug.Log ("Right get");
	}
	void OnConnected(SocketIOEvent e)
	{
		Debug.Log ("player connected");
		socket.Emit ("move");
	}

	void OnSpawned(SocketIOEvent e)
	{
		Debug.Log ("spawned");
		Instantiate (playerPrefab);
	}
}
