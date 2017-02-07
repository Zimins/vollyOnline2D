using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreater : MonoBehaviour {

	public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
		if (Input.GetButtonDown ("Fire1"))
			BallSpawn ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BallSpawn(){

	
	}
}
