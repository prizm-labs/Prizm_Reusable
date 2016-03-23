using UnityEngine;
using System.Collections;
using System;
using TouchScript;
using TouchScript.Gestures;

public class Deck : MonoBehaviour {

	void OnEnable(){
		GetComponent<TransformGesture> ().Transformed += CheckForShake;
		//GetComponent<ReleaseGesture> ().Released += RollDice;
	}

	public void CheckForShake(object sender, EventArgs e){
		if (GetComponent<TransformGesture> ().DeltaPosition.x > 0.5f || GetComponent<TransformGesture> ().DeltaPosition.y > 0.6f ) {
			GetComponent<Animator> ().SetTrigger ("Shuffle");
		}
	}



}
