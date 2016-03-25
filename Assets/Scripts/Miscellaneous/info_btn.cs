using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.Gestures;
using System;
using System.Collections.Generic;

public class info_btn : MonoBehaviour {

	public List<GameObject> thingsIWantToOpen;
	public List<GameObject> thingsIWantToClose;

	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += OnTapOpen;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= OnTapOpen;
	}

	public void OnTapOpen(object sender, EventArgs e){
		//Debug.Log ("SHOULD BE OPENING TUTORIAL");
		//thingIWantToOpen.SetActive(true);
		//thingIWantToClose.SetActive (false);

		foreach (GameObject go in thingsIWantToOpen) {
			go.SetActive (true);
		}

		foreach (GameObject go in thingsIWantToClose) {
			go.SetActive (false);
		}


	}

}
