using UnityEngine;
using System.Collections;
using System;
using TouchScript;
using TouchScript.Gestures;
using System.Collections.Generic;

public class Mute_Sound : MonoBehaviour {


	public List<AudioSource> allSFXSOURCES;



	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += OnMutePress;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= OnMutePress;
	}

	public void OnMutePress(object sender, EventArgs e){
		AudioListener.pause = !AudioListener.pause;

		SoundManager.Instance.efxSource1.Stop ();
		SoundManager.Instance.efxSource2.Stop ();
		SoundManager.Instance.efxSource3.Stop ();
		SoundManager.Instance.efxSource4.Stop ();

	}

}
