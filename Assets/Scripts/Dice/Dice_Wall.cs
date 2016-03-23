using UnityEngine;
using System.Collections;

public class Dice_Wall : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		//Debug.Log ("Should be playing dice sound COLLIDER ENTER");

		if (collision.gameObject.GetComponent<DiceScript> ()!= null ) {
			//SoundManager.Instance.PlayAudio (SoundManager.Instance.diceSounds [UnityEngine.Random.Range (0, SoundManager.Instance.diceSounds.Count - 1)], 
				//Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse());
		}
		//|| collision.gameObject.GetComponent<Dice_Num_Collider> ()!= null  
		if (collision.gameObject.GetComponent<Dice_Num_Collider> ()!= null ) {
			//SoundManager.Instance.PlayAudio (SoundManager.Instance.diceSounds [UnityEngine.Random.Range (0, SoundManager.Instance.diceSounds.Count - 1)], 
				//Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse());
		}
	}

	void OnTriggerEnter(Collider collision) {
		//Debug.Log ("Should be playing dice sound TRIGGER ENTER");
		if (collision.gameObject.GetComponent<Dice_Num_Collider> ()!= null ) {
			//SoundManager.Instance.PlayAudio (SoundManager.Instance.diceSounds [UnityEngine.Random.Range (0, SoundManager.Instance.diceSounds.Count - 1)], 
				//Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse());
		}
	}
}
