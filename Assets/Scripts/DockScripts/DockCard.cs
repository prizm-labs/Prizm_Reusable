using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TouchScript;
using TouchScript.Behaviors;
using TouchScript.Gestures;
using System;

public class DockCard : MonoBehaviour {

//	private Player myPlayer;
//	public Player MyPlayer{ get { return myPlayer; } set { myPlayer = value; } }
//	private bool foundSpot;
//	public static int numPlayersToChooseDock;
//	public string DockCardColor;
//	public Color DockCardColorValue;
//	public RectTransform Private_INNER_TuorialPanel;
//	public RectTransform yesNoPanel;
//	public RectTransform oKPanel;
//	public RectTransform Trade_Build_Buy_Prompt;
//	public Text privatePromptText;
//	//public RectTransform tradeOptionPanel;
//	public Button learnMore_Btn;
//	public RectTransform MyTradeTray;
//	public Button CompleteTradeBtn;
//
//	public Transform myItemAppearArea;
//
//	public Image MyRoadImage;
//	public Image MySettlementImage;
//	public Image MyCityImage;
//	public Text MyRoadInHandNumber;
//	public Text MySettlementInHandNumber;
//	public Text MyCityInHandNumber;
//
//	public Text MyResourceCardsInHandText;
//
//	public List<Sprite> IconsForDevCardsPlayed;
//	public List<Image> ListOfDevCardSpots;
//
//	public List<Sprite> TwoAchievementCards;
//	public Text VictoryPointText;
//	public Image roadAchievementSlot;
//	public Image armyAchievementSlot;
//	public DockWall myDockWall;
//
//	void Start() {
//		//roadAchievementSlot = transform.Find ("Canvas/p_achievements/i_road_achievement").gameObject;
//		//armyAchievementSlot = transform.Find ("Canvas/p_achievements/i_army_achievement").gameObject;
//		roadAchievementSlot.color = myPlayer.MyColorValue;
//		armyAchievementSlot.color = myPlayer.MyColorValue;
//		//roadAchievementSlot.enabled = false;
//		//armyAchievementSlot.enabled = false;
//		//transform.GetComponent<Rigidbody> ().isKinematic = false;
//
//	}
//
//	void OnEnable(){
//		GetComponent<TransformGesture> ().TransformStarted += TurnOffKinematic;
//		GetComponent<TransformGesture> ().Transformed += CheckPosition;
//		//GetComponent<TransformGesture> ().TransformCompleted += TurnOnKinematic;
//	}
//
//	void OnDisable(){
//		GetComponent<TransformGesture> ().TransformStarted -= TurnOffKinematic;
//		GetComponent<TransformGesture> ().Transformed -= CheckPosition;
//
//		//GetComponent<TransformGesture> ().TransformCompleted -= TurnOnKinematic;
//
//	}
//
//	void TurnOffKinematic(object sender, EventArgs e){
//		transform.GetComponent<Rigidbody> ().isKinematic = false;
//	}
//
////	void TurnOnKinematic(object sender, EventArgs e){
////		transform.GetComponent<Rigidbody> ().isKinematic = true;
////	}
//
//	void CheckPosition(object sender, EventArgs e){
//
//		if (myDockWall == null) {
//			return;
//		}
//
//		switch (myDockWall.gameObject.name) {
//		case "top":
//			if (transform.position.z >= 14.2f) {
//				transform.position = new Vector3 (transform.position.x, transform.position.y, 14.2f);
//			}
//			break;
//		case "left":
//			if (transform.position.x <= -27.0f) {
//				transform.position = new Vector3(-27.0f, transform.position.y, transform.position.z);
//			}
//			break;
//
//		case "right":
//			if (transform.position.x >= 27.1f) {
//				transform.position = new Vector3(27.0f, transform.position.y, transform.position.z);
//			}
//			break;
//
//		case "bottom":
//			if (transform.position.z <= -14.3f) {
//				transform.position = new Vector3(transform.position.x, transform.position.y, -14.2f);
//			}
//			break;
//		
//		default:
//			Debug.Log ("NOOO Dockwall has that name");
//			break;
//		}
//
//	}
//
//
//
//	public void UpdateMyDockCardVisually(){
//		MyRoadImage.color = MyPlayer.MyColorValue;
//		MySettlementImage.color = MyPlayer.MyColorValue;
//		MyCityImage.color = MyPlayer.MyColorValue;
//
//		MyRoadInHandNumber.text = MyPlayer.MyRoadsInHand.Count.ToString ();
//		MySettlementInHandNumber.text = GetNumSettlementsInHand ().ToString ();
//		MyCityInHandNumber.text = GetNumCitiesInHand ().ToString ();
//
//		MyResourceCardsInHandText.text = MyPlayer.MyResourcesInHand.Count.ToString ();
//
//		foreach (DevelopmentCard devCard in MyPlayer.MyDevCardPlayedVisible) {
//			//Debug.Log ("determining type of devCard: " + devCard.MyTypeOfDevCard.ToString());
//			if (!devCard.hasBeenDocked) {
//				devCard.hasBeenDocked = true;
//
//				switch (devCard.MyTypeOfDevCard) {
//				case TypeOfDevCard.Knight:
//					FindMeAnOpenDevCardSpot ().sprite = IconsForDevCardsPlayed [0];
//					break;
//				case TypeOfDevCard.BuildRoad:
//					FindMeAnOpenDevCardSpot ().sprite = IconsForDevCardsPlayed [1];
//					break;
//				case TypeOfDevCard.Monopoly:
//					FindMeAnOpenDevCardSpot ().sprite = IconsForDevCardsPlayed [3];
//					break;
//				case TypeOfDevCard.VictoryPoint:
//					FindMeAnOpenDevCardSpot ().sprite = IconsForDevCardsPlayed [4];
//					break;
//				case TypeOfDevCard.YearOfPlenty:
//					FindMeAnOpenDevCardSpot ().sprite = IconsForDevCardsPlayed [2];
//					break;
//				default:
//					Debug.LogError ("warning! did not find type of devcard for: " + devCard.MyTypeOfDevCard.ToString ());
//					break;
//				}
//			}
//		}
//
//		MyPlayer.MyVictoryPtTotal = CalculateTotalPtScoreSansConcealedDevCards ();
//		VictoryPointText.text = MyPlayer.MyVictoryPtTotal.ToString();
//
//		if (myPlayer.IHaveLargestArmy) {
//			armyAchievementSlot.enabled = true;
//		} else {
//			armyAchievementSlot.enabled = false;
//		}
//
//		if (myPlayer.IHaveLongestRoad ) { //&& myPlayer.myLongestRoadSegment >= 5) {
//			roadAchievementSlot.enabled = true;
//		} else {
//			roadAchievementSlot.enabled = false;
//		}
//
//	}
//
//	public void GiveMeLongestRoad() {
//		foreach (Player ply in GameManager.Instance.TheOneOfficialAllPlayerListInOrderOfTurns) {
//			ply.IHaveLongestRoad = false;
//			ply.MyDockCard.UpdateMyDockCardVisually ();
//			if (ply.CheckIfWinner ()) {	//re-syncs victory points
//				ply.DimTheScreenAndTurnOnSpecialCam (true);
//			}
//		}
//
//		MyPlayer.IHaveLongestRoad = true;
//		UpdateMyDockCardVisually ();
//
//		if (myPlayer.CheckIfWinner ()) {
//			myPlayer.DimTheScreenAndTurnOnSpecialCam (true);
//		}
//	}
//
//	public void GiveMeLargestArmy() {
//		foreach (Player ply in GameManager.Instance.TheOneOfficialAllPlayerListInOrderOfTurns) {
//			ply.IHaveLargestArmy = false;
//			ply.MyDockCard.UpdateMyDockCardVisually ();
//			if (ply.CheckIfWinner ()) {	//re-syncs victory points
//				//SoundManager.Instance.PlayAudio (SoundManager.Instance.playerEnterList [UnityEngine.Random.Range (0, SoundManager.Instance.playerEnterList.Count - 1)], 
//					//Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse ());
//				ply.DimTheScreenAndTurnOnSpecialCam (true);
//			}
//		}
//
//		MyPlayer.IHaveLargestArmy = true;
//		UpdateMyDockCardVisually ();
//		if (myPlayer.CheckIfWinner ()) {
//			//SoundManager.Instance.PlayAudio (SoundManager.Instance.playerEnterList [UnityEngine.Random.Range (0, SoundManager.Instance.playerEnterList.Count - 1)], 
//				//Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse ());
//			myPlayer.DimTheScreenAndTurnOnSpecialCam (true);
//		}
//	}
//
//	public int CalculateTotalPtScoreSansConcealedDevCards(){
//		int j = 0;
//
//		//each settlement on board you get 1 point
//		j += GetMyNumSettlementsOnBoard();
//
//		//each city on board you get 2 points
//		j += GetMyNumCitiesOnBoard()*2;
//
//		//each activated +1 dev Card
//		j += GetMyNumVPInDevCardsActivated();
//
//		//this player has longest road +2
//		if (MyPlayer.IHaveLongestRoad ) { //&& MyPlayer.myLongestRoadSegment >= 5) {
//			j += 2;
//		}
//
//		//this player has largest army +2 
//		if (MyPlayer.IHaveLargestArmy) {
//			j += 2;
//		}
//
//		return j;
//
//	}
//
//
//	Image FindMeAnOpenDevCardSpot (){
//
//		foreach (Image img in ListOfDevCardSpots) {
//			if (img.sprite.name.Equals ("DevCard_Icons_5")) {
//				return img;
//			}
//		}
//		return null;
//	}
//
//	int GetNumSettlementsInHand(){
//		int i = 0;
//		foreach (Establishment est in MyPlayer.MyEstablishmentsInHand) {
//			if (est.MyTypeOfEstablishment.Equals (TypeOfEstablishment.Settlement)) {
//				i++;
//			}
//		}
//		return i;
//
//	}
//
//	int GetNumCitiesInHand(){
//		int i = 0;
//		foreach (Establishment est in MyPlayer.MyEstablishmentsInHand) {
//			if (est.MyTypeOfEstablishment.Equals (TypeOfEstablishment.City)) {
//				i++;
//			}
//		}
//		return i;
//	}
//
//	int GetMyNumSettlementsOnBoard(){
//		int i = 0;
//		//Debug.Log ("getting num of settlements for: " + MyPlayer.MyName);
//		foreach (Establishment est in MyPlayer.MyEstablishmentsOnBoard) {
//			//Debug.Log ("went through establishment");
//			if (est.MyTypeOfEstablishment.Equals (TypeOfEstablishment.Settlement)) {
//				//Debug.Log ("FOUND A SETTLEMENT!");
//				i++;
//			}
//		}
//		//Debug.Log ("found total settlements: " + i.ToString ());
//		return i;
//	}
//
//	int GetMyNumCitiesOnBoard(){
//		int i = 0;
//		foreach (Establishment est in MyPlayer.MyEstablishmentsOnBoard) {
//			if (est.MyTypeOfEstablishment.Equals (TypeOfEstablishment.City)) {
//				i++;
//			}
//		}
//		return i;
//	}
//
//	int GetMyNumVPInDevCardsActivated(){
//		int i = 0;
//		foreach (DevelopmentCard dCard in MyPlayer.MyDevCardPlayedVisible) {
//			if (dCard.MyTypeOfDevCard.Equals(TypeOfDevCard.VictoryPoint)) {
//				i++;
//			}
//		}
//		return i;
//	}
//
//
//	void OnCollisionEnter(Collision other) {
//
////		if (other.gameObject.GetComponent<DockWall> () != null) {
////			numPlayersToChooseDock++;
////			OrientDockCard(other.gameObject.name);
////		}
////		if (!Scanner_Rotate.Instance.PerformedRotation && numPlayersToChooseDock >= GameManager.Instance.PlayersRegisteredBeforeTurnOrder.Count) {
////			Scanner_Rotate.Instance.StartYYYRotation = true;
////			Scanner_Rotate.Instance.StartRotation = true;
////		}
//	}
//
//	public void OrientDockCard(string _dockLabel, GameObject dockWall){
//		switch(_dockLabel){
//		case "top":
//			transform.eulerAngles = new Vector3 (0, 180, 0);
//			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);
//			break;
//		case "bottom":
//			transform.eulerAngles = new Vector3(0, 0, 0);
//			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);
//
//			break;
//		case "left":
//			transform.eulerAngles = new Vector3(0, 90, 0);
//			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);
//
//			break;
//		case "right":
//			transform.eulerAngles = new Vector3(0, -90, 0);
//			transform.position = new Vector3 (transform.position.x, 4.5f, transform.position.z);
//
//			break;
//		default:
//
//			break;
//		}
//		//transform.GetComponent<Rigidbody> ().isKinematic = true;
//		SoundManager.Instance.PlayAudio (SoundManager.Instance.popSound, Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse ());
//		myDockWall = dockWall.GetComponent<DockWall> ();
//
//	}
//
//
//	public void CompleteTheTrade(){
//		Debug.Log ("Started COMPLETE the trade.");
//		StartCoroutine (FinishTransaction ());
//		SoundManager.Instance.PlayAudio (SoundManager.Instance.popSound, Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse ());
//
//
//	}
//
//	public IEnumerator FinishTransaction() {
//		Debug.Log ("Started finish the transaction.");
//		foreach (Player ply in GameManager.Instance.TheOneOfficialAllPlayerListInOrderOfTurns) {
//			foreach (GameObject go in ply.myTradeList) {
//				if (go.GetComponent<Resource> () != null) {
//					Resource resCard = go.GetComponent<Resource> ();
//					resCard.record.mongoDocument.location = "hand";
//					resCard.record.mongoDocument.owner = ply.MyName;
//					Debug.Log ("setting " + resCard.record.mongoDocument.typeOfResource + " to : " + ply.MyName + "'s hand");
//					yield return StartCoroutine (resCard.record.Sync ());
//					Player.expectingCleanupCardsRobberPhase++;
//				}
//			}
//
//			ply.myTradeList.Clear ();
//			ply.MyDockCard.MyTradeTray.gameObject.SetActive (false);
//			ply.MyDockCard.Private_INNER_TuorialPanel.gameObject.SetActive(false);
//			ply.MyDockCard.UpdateMyDockCardVisually();
//		}
//
//		GameManager.Instance.CurrentPlayerTurn.TradeComplete = true;
//		SoundManager.Instance.PlayAudio (SoundManager.Instance.dangerImpendingList [UnityEngine.Random.Range(0,SoundManager.Instance.dangerImpendingList.Count -1 )], 
//			Vector3.zero, SoundManager.Instance.GetMeAn_FX_AudioSourceNotInUse ());
//	}
//	
//	public void CancelTheTrade(){
//		MyPlayer.TradeComplete = true;
//	}
//
//	public void SubmitPlayerInput(string input){
//		MyPlayer.MyLatestInput = input;
//	}
}