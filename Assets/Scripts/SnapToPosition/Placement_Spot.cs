using UnityEngine;
using System.Collections;

public class Placement_Spot : MonoBehaviour {


	public Color colorStart = Color.red;
	public Color colorEnd = Color.green;
	public float duration = 1.0F;
	public Renderer rend;
	public bool pieceOnMe;

	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		if (!pieceOnMe) {
			float lerp = Mathf.PingPong (Time.time, duration) / duration;
			rend.material.color = Color.Lerp (colorStart, colorEnd, lerp);
		}
	}



	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.GetComponent<Movable_Snap_Piece> () != null) {
			Debug.Log ("touching a piece that is important to me");
			pieceOnMe = true;
			other.transform.position = new Vector3 (transform.position.x, transform.position.y+0.1f, transform.position.z);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.GetComponent<Movable_Snap_Piece> () != null) {
			pieceOnMe = false;

		}
	}

}
