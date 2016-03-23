using UnityEngine;
using System.Collections;

public class DiceCorner_Sound : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals ("DiceFloor") && Time.time > 5.0f) {
			//SoundManager.Instance.PlayAudio (SoundManager.Instance.diceSounds [UnityEngine.Random.Range (0, SoundManager.Instance.diceSounds.Count - 1)], 
				//Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse());
			GetComponent<AudioSource>().Play();
		}
	}

}
