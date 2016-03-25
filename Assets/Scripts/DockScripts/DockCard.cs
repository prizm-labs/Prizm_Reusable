using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TouchScript;
using TouchScript.Behaviors;
using TouchScript.Gestures;
using System;

public class DockCard : MonoBehaviour {

	private bool foundSpot;
	public static int numPlayersToChooseDock;
	public string DockCardColor;
	public Color DockCardColorValue;

	public DockWall myDockWall;

	void Start() {


	}

	void OnEnable(){
		GetComponent<TransformGesture> ().TransformStarted += TurnOffKinematic;
		GetComponent<TransformGesture> ().Transformed += CheckPosition;
	}

	void OnDisable(){
		GetComponent<TransformGesture> ().TransformStarted -= TurnOffKinematic;
		GetComponent<TransformGesture> ().Transformed -= CheckPosition;

	}

	void TurnOffKinematic(object sender, EventArgs e){
		transform.GetComponent<Rigidbody> ().isKinematic = false;
	}

	void CheckPosition(object sender, EventArgs e){

		if (myDockWall == null) {
			return;
		}

		switch (myDockWall.gameObject.name) {
		case "top":
			if (transform.position.z >= 14.2f) {
				transform.position = new Vector3 (transform.position.x, transform.position.y, 14.2f);
			}
			break;
		case "left":
			if (transform.position.x <= -27.0f) {
				transform.position = new Vector3(-27.0f, transform.position.y, transform.position.z);
			}
			break;

		case "right":
			if (transform.position.x >= 27.1f) {
				transform.position = new Vector3(27.0f, transform.position.y, transform.position.z);
			}
			break;

		case "bottom":
			if (transform.position.z <= -14.3f) {
				transform.position = new Vector3(transform.position.x, transform.position.y, -14.2f);
			}
			break;
		
		default:
			Debug.Log ("NOOO Dockwall has that name");
			break;
		}

	}




	void OnCollisionEnter(Collision other) {

//		if (other.gameObject.GetComponent<DockWall> () != null) {
//			numPlayersToChooseDock++;
//			OrientDockCard(other.gameObject.name);
//		}
//		if (!Scanner_Rotate.Instance.PerformedRotation && numPlayersToChooseDock >= GameManager.Instance.PlayersRegisteredBeforeTurnOrder.Count) {
//			Scanner_Rotate.Instance.StartYYYRotation = true;
//			Scanner_Rotate.Instance.StartRotation = true;
//		}
	}

	public void OrientDockCard(string _dockLabel, GameObject dockWall){
		switch(_dockLabel){
		case "top":
			transform.eulerAngles = new Vector3 (0, 180, 0);
			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);
			break;
		case "bottom":
			transform.eulerAngles = new Vector3(0, 0, 0);
			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);

			break;
		case "left":
			transform.eulerAngles = new Vector3(0, 90, 0);
			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);

			break;
		case "right":
			transform.eulerAngles = new Vector3(0, -90, 0);
			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);

			break;
		default:

			break;
		}
		//transform.GetComponent<Rigidbody> ().isKinematic = true;
		//////SoundManager.Instance.PlayAudio (SoundManager.Instance.popSound, Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse ());
		myDockWall = dockWall.GetComponent<DockWall> ();

	}


}