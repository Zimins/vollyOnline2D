using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLogics : MonoBehaviour {


	public Text homePoint;
	public Text awayPoint;

	int homeScore =0;
	int awayScore = 0; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.gameObject.name == "LeftFloor") {
			awayScore++;
			awayPoint.text = awayScore.ToString ();
		};

		if (coll.gameObject.name == "RightFloor") {
			homeScore++;
			homePoint.text = homeScore.ToString ();
		};
	}

}
