using UnityEngine;
using System.Collections;

public class DockWall : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.GetComponent<DockCard> () != null) {
			DockCard _dc = other.gameObject.GetComponent<DockCard> ();
			_dc.OrientDockCard (gameObject.name, gameObject);
			
		}
	}
	
}
