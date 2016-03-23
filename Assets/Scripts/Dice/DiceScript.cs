using UnityEngine;
using System.Collections;
using System;
using TouchScript;
using TouchScript.Gestures;

public enum DiceStates{None, AWaitingRoll, Rolling, RollChecking, RollEnded, RollResult}

public class DiceScript : MonoBehaviour {

	private int myRollResult;
	public int MyRollResult{ get { return myRollResult; } set { myRollResult = value; } }
	private bool rolling;
	//public bool Rolling{ get { return rolling; } set { rolling = value; } }
	private bool rollEnded;
	//public bool RollEnded{ get { return rollEnded; } set { rollEnded = value; } }
	private bool rollStarted;
	//public bool RollStarted{ get { return rollEnded; } set { rollEnded = value; } }

	public DiceStates MyDiceState;

	void OnEnable(){
		GetComponent<TransformGesture> ().Transformed += RollDice;
		//GetComponent<ReleaseGesture> ().Released += RollDice;
	}
	
	void OnDisable(){
		GetComponent<TransformGesture> ().Transformed -= RollDice;
		//GetComponent<ReleaseGesture> ().Released -= RollDice;

	}

	void Awake(){
		//RollDiceNoTap ();
		//BeforeRollStarted = true;
	}

	void Update(){
		if (MyDiceState.Equals(DiceStates.Rolling)) {
			StartCoroutine(RollChecker());
		}
		//Debug.Log ("We are Rolling : " + rolling);
	}
	

	void RollDice(object sender, EventArgs e){   
		if(MyDiceState.Equals(DiceStates.AWaitingRoll)){
			//MyDiceState = DiceStates.Rolling;
			StartCoroutine(InitiateRoll());
			transform.GetChild(0).transform.GetChild(0).transform.GetComponent<MeshRenderer> ().material.color = Color.black;
			if (GetComponent<TransformGesture> ().ScreenPosition.x > GetComponent<TransformGesture> ().PreviousScreenPosition.x) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (3, 0.5f, 0));
				GetComponent<Rigidbody> ().AddTorque (new Vector3 (-1000, 2000, -1200));

			} else {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (-3, 0.5f, 0));
				GetComponent<Rigidbody> ().AddTorque (new Vector3 (-1000, 2000, 2000));

			}
			if (GetComponent<TransformGesture> ().ScreenPosition.y > GetComponent<TransformGesture> ().PreviousScreenPosition.y) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0.5f, 3));
				GetComponent<Rigidbody> ().AddTorque (new Vector3 (-100, -1000, 800));
			} else {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0.5f, -3));
				GetComponent<Rigidbody> ().AddTorque (new Vector3 (-100, -1000, -1000));

			}

			if(gameObject.name.Equals("Dice_01")){
				//Dice_01_Pulse.Instance.Dice_01_Pulse_Off ();
			} else if (gameObject.name.Equals("Dice_02")){
				//Dice_02_Pulse.Instance.Dice_02_Pulse_Off ();
			}
		}
	}

	public IEnumerator RollChecker(){
			if (GetComponent<Rigidbody> ().velocity.x < 0.07f && GetComponent<Rigidbody> ().velocity.y < 0.07f && GetComponent<Rigidbody> ().velocity.z < 0.07f) {
				if (GetComponent<Rigidbody> ().angularVelocity.x < 0.1f && GetComponent<Rigidbody> ().angularVelocity.y < 0.1f && GetComponent<Rigidbody> ().angularVelocity.z < 0.1f) {
					transform.GetChild (0).transform.GetChild (0).transform.GetComponent<MeshRenderer> ().material.color = Color.black;
					MyDiceState = DiceStates.RollEnded;
					StartCoroutine(CollectRollResult());
				}
			} else {
				
			}
		yield return null;
	}

	IEnumerator CollectRollResult(){
		yield return new WaitForSeconds (1.0f);
		//transform.GetChild (0).transform.GetChild (0).transform.GetComponent<MeshRenderer> ().material.color = Color.grey;
		MyDiceState = DiceStates.RollResult;
		//Debug.Log ("Collecting the roll RESULT");
		StartCoroutine (LockDieRoll ());
		//StartCoroutine (ShowDiceTotalText());

	}



	IEnumerator LockDieRoll(){
		yield return new WaitForSeconds (2.0f);
		GetComponent<Rigidbody> ().isKinematic = true;
	}

	IEnumerator InitiateRoll(){
		yield return new WaitForSeconds (2.0f);
		MyDiceState = DiceStates.Rolling;
	}
	
	
	void RollDiceNoTap(){
		if (GetComponent<TransformGesture> ().ScreenPosition.x > GetComponent<TransformGesture> ().PreviousScreenPosition.x) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (30, 0.5f, 0));
			GetComponent<Rigidbody> ().AddTorque (new Vector3 (-1000, 2000, -1200));
		} else {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (-30, 0.5f, 0));
			GetComponent<Rigidbody> ().AddTorque (new Vector3 (-1000, 2000, 2000));
		}
		if (GetComponent<TransformGesture> ().ScreenPosition.y > GetComponent<TransformGesture> ().PreviousScreenPosition.y) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0.5f, 30));
			GetComponent<Rigidbody> ().AddTorque (new Vector3 (-100, -1000, 800));
		} else {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0.5f, -30));
			GetComponent<Rigidbody> ().AddTorque (new Vector3 (-100, -1000, -1000));
			
		}
		//rolling = true;
	} 


	public void TakeAwayDie(){
		transform.position = new Vector3 (UnityEngine.Random.Range (100, 110), 6, 0);
		MyDiceState = DiceStates.None;
		MyRollResult = 0;
		transform.GetChild (0).transform.GetChild (0).transform.GetComponent<MeshRenderer> ().material.color = Color.black;
	}

	public void BringInTheDie(){
		MyDiceState = DiceStates.AWaitingRoll;

		if(gameObject.name.Equals("Dice_01")){
			transform.position = new Vector3 (UnityEngine.Random.Range (0, 15), 6, UnityEngine.Random.Range (-10, 10));
			//Dice_01_Pulse.Instance.Dice_01_Pulse_On (this);
		} else if (gameObject.name.Equals("Dice_02")){
			transform.position = new Vector3 (UnityEngine.Random.Range (0, -15), 6, UnityEngine.Random.Range (-10, 10));

			//Dice_02_Pulse.Instance.Dice_02_Pulse_On (this);
		}

		MyRollResult = 0;
		transform.GetChild (0).transform.GetChild (0).transform.GetComponent<MeshRenderer> ().material.color = Color.black;
		GetComponent<Rigidbody> ().isKinematic = false;

	}


}
