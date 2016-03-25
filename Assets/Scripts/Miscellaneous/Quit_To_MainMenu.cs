using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.Gestures;
using System;
using UnityEngine.SceneManagement;

public class Quit_To_MainMenu : MonoBehaviour {

	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += GoToMainMenu;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= GoToMainMenu;
	}

	void GoToMainMenu(object sender, EventArgs e){
		SceneManager.LoadScene ("MainMenu_Scene");

	}

}
