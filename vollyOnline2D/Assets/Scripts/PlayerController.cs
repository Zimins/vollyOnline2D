using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using CnControls;

public class PlayerController : MonoBehaviour {


	Rigidbody2D rb2d;
	public float speedX;
	public float speedJump;

	bool isGrounded=true;


	void Awake(){

		rb2d = GetComponent<Rigidbody2D> ();
	}
	public void start(){
		
	}


	void FixedUpdate () {


		if (CnInputManager.GetAxis("Horizontal")>0) {
			MoveRight ();
		} else if (CnInputManager.GetAxis("Horizontal")<0) {
			MoveLeft ();
		}

		if(CnInputManager.GetAxis("Vertical")>0&&isGrounded){
			isGrounded = false;
			Debug.Log ("Jump!");
			Jump ();
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "LeftFloor") {
			isGrounded = true;
		};
	}

	public void Jump(){
		this.rb2d.AddForce (Vector2.up*speedJump*10f);
	}
	public void MoveRight(){
		Debug.Log ("right button pushed");
		Debug.Log (transform.position.x.ToString());
		transform.Translate (Vector2.right * speedX*Time.deltaTime);
	}

	public void MoveLeft(){
		Debug.Log (transform.position.x.ToString());
		transform.Translate (Vector2.left * speedX * Time.deltaTime);
	}


}
