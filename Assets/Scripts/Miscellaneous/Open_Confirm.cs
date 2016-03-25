using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.Gestures;
using System;

public class Open_Confirm : MonoBehaviour {

	public GameObject dialogueConfirm;

	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += OpenConfirmDialog;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= OpenConfirmDialog;
	}

	void OpenConfirmDialog(object sender, EventArgs e){
		dialogueConfirm.SetActive (true);


	}


}
