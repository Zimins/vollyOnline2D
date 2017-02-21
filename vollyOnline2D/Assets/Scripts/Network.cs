using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Network : MonoBehaviour {

	static SocketIOComponent socket;
	public GameObject homePlayer;
	public GameObject awayPlayer;
	public Vector2 homePosition = new Vector2(-2.5f,-1f);
	public Vector2 awayPosition = new Vector2(2.5f,-1f);


	// Use this for initialization
	void Start () {
		socket = GetComponent<SocketIOComponent> ();
		socket.On ("open", OnConnected);
		socket.On ("spawn", OnSpawned);
		socket.On ("homePlayerConnect", OnHomePlayerConnected);
		socket.On ("awayPlayerConnect", OnAwayPlayerConnected);
		socket.On ("move", onMove);
		socket.On ("requestPosition", OnRequestPosition);
	}

	void Update () {
		if (Input.GetAxis ("Horizontal") > 0) {
			Dictionary<string, string> data = new Dictionary<string, string>();
			data["x"] = homePlayer.transform.localPosition.x.ToString ();
			data["y"] = homePlayer.transform.position.y.ToString();

			socket.Emit ("move",new JSONObject(data));
		} else if (Input.GetAxis ("Horizontal") < 0) {
			Dictionary<string, string> data = new Dictionary<string, string>();
			data["x"] = homePlayer.transform.position.x.ToString();
			data["y"] = homePlayer.transform.position.y.ToString();

			socket.Emit ("move",new JSONObject(data));
		}
	}

	void  onMove(SocketIOEvent e)
	{
		Debug.Log ("move get");
	}
	void OnConnected(SocketIOEvent e)
	{
		Debug.Log ("player connected");
	}

	void OnSpawned(SocketIOEvent e)
	{
		Debug.Log ("spawned");
	}

	void OnRequestPosition(SocketIOEvent e){
		Debug.Log ("request position from other client");

	}
	void OnHomePlayerConnected(SocketIOEvent e){
		Debug.Log ("homespawned");
		Instantiate (homePlayer);
	}

	void OnAwayPlayerConnected(SocketIOEvent e){
		Debug.Log ("awayspawned");
		Instantiate (awayPlayer);
	}
}
