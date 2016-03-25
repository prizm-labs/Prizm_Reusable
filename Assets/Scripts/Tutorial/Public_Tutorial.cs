using UnityEngine;
using System.Collections;

public class Public_Tutorial : MonoBehaviour {

	public GameObject myBouncingArrow;
	public GameObject myImage;
	public GameObject myText;

	public static Public_Tutorial Instance;

	void Awake(){
		Instance = this;
	}

	void Start(){
		//myDefaultPos = transform.position;
		//offScreenPosition = new Vector3(myDefaultPos.x, myDefaultPos.y, 100);
	}


}
