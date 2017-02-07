using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class PlayerController : MonoBehaviour {

	private SocketIOComponent socket;
	Rigidbody2D rb2d;

	public float speedX;
	public float speedJump;
	public GameObject sprite;
	bool isGrounded=true;


	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
	}
	public void start(){
		
		socket = GetComponent<SocketIOComponent> ();

	}


	void FixedUpdate () {



		if (Input.GetAxis ("Horizontal") > 0) {
			transform.Translate (Vector2.right * speedX * Time.deltaTime);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			transform.Translate (Vector2.left * speedX * Time.deltaTime);
		}else if(Input.GetButtonDown("Jump")&&isGrounded){
			isGrounded = false;
			Debug.Log ("Jump!");
			rb2d.AddForce (Vector2.up*speedJump*10f);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log (coll.gameObject.name);
		if (coll.gameObject.name == "LeftFloor") {
			isGrounded = true;
		};
	}


}
