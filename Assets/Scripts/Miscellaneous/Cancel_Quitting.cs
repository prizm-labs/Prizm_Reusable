using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.Gestures;
using System;

public class Cancel_Quitting : MonoBehaviour {


	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += CancelTheQuit;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= CancelTheQuit;
	}

	void CancelTheQuit(object sender, EventArgs e){
		transform.parent.transform.gameObject.SetActive (false);
	}

}
