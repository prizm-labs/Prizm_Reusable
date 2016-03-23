using UnityEngine;
using System.Collections;

public class Dice_Num_Collider : MonoBehaviour {

	public DiceScript theDieMyParent;
	public int theNumOppositeMe;

	void Start(){
//		Debug.Log ("Dice Collider is active");
	}

	void OnTriggerEnter(Collider other){
		if ((other.gameObject.tag.Equals ("DiceFloor") || other.gameObject.GetComponent<Dice_Wall>() != null) && Time.time > 1.0f) {
				theDieMyParent.MyRollResult = theNumOppositeMe;
		//	SoundManager.Instance.PlayAudio (SoundManager.Instance.diceSounds [UnityEngine.Random.Range (0, SoundManager.Instance.diceSounds.Count - 1)], 
		//		Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse());
			GetComponent<AudioSource>().Play();

		}
	}
}
