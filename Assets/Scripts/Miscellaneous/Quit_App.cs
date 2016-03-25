using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.Gestures;
using System;
using UnityEngine.SceneManagement;

public class Quit_App : MonoBehaviour {

	void OnEnable(){
		GetComponent<TapGesture> ().Tapped += OnQuit;
	}

	void OnDisable(){
		GetComponent<TapGesture> ().Tapped -= OnQuit;
	}

	void OnQuit(object sender, EventArgs e){
		Application.Quit();
	}
}
