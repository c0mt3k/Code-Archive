using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
	
	#region Public Variables
	PlayerScript player;
	public GameObject PausePanel;
	public GameObject PlayerHpImage;
	public GameObject PlayerHpText;
	public GameObject PlayerHpText2;
	public GameObject LowHpWarning;
	public Text CannonDmgLevelText;
	public Text CannonFRLevelText;
	public Text HullLevelText;
	public Text ThrusterLevelText;
	public bool IsPaused;
	#endregion
	
	// Use this for initialization
	void Start ()
	{
		if (Application.loadedLevel == 1) {
			Time.timeScale = 1;
			LowHpWarning.GetComponent<Animator> ().SetBool ("lowHP", false);
			PlayerHpImage.GetComponent<Animator> ().SetBool ("lowHP", false);
		} else
		if (Application.loadedLevel == 3) {
		}
		player = Object.FindObjectOfType<PlayerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.loadedLevel == 1) {
			PlayerHpImage.GetComponent<Image> ().fillAmount = (((player.CurrentHp / player.HpMax) * 100) / 100);
			PlayerHpText.GetComponent<Text> ().text = string.Format ("Hull: {0}%", ((player.CurrentHp / player.HpMax) * 100).ToString ("F0"));
			PlayerHpText2.GetComponent<Text> ().text = string.Format ("{0} / {1}", player.CurrentHp.ToString ("F0"), player.HpMax.ToString ("F0"));
			if (player.CurrentHp < player.HpMax / 4) {
				LowHpWarning.SetActive (true);
				LowHpWarning.GetComponent<Animator> ().SetBool ("lowHP", true);
				GameObject.Find ("playerHpImage").GetComponent<Animator> ().SetBool ("lowHP", true);
			} else {
				LowHpWarning.SetActive (false);
				GameObject.Find ("playerHpImage").GetComponent<Animator> ().SetBool ("lowHP", false);
			}
			//Pauses the game if the player is alive and on the right level and the player presses space
			if (player.CurrentHp > 0 && Application.loadedLevel == 1)
			if (Input.GetKeyDown ("space"))
			if (Time.timeScale == 1) {
				IsPaused = true;
				Time.timeScale = 0;
				PausePanel.SetActive (true);
			} 
			//unpauses the game if the player is alive and on the right level and the player presses space
			else {
				IsPaused = false;
				Time.timeScale = 1;
				PausePanel.SetActive (false);
			}
			if (player.CurrentHp <= 0) {
				//Display a bunch of text telling the player how much he sucks
				GameObject.Find ("winLoseText").GetComponent<Text> ().text = "You Lose!";
				GameObject.Find ("restartText").GetComponent<Text> ().text = "Press 'Space' to return to the hangar";
				//Listen for the space bar so the player can suck at the game some more
				if (Input.GetKeyDown ("space"))
					Application.LoadLevel (3);
			}
		} else
		if (Application.loadedLevel == 3) {
			//Update text elements according to what upgrade level they are
			CannonDmgLevelText.text = gameObject.GetComponent<UpgradeScript> ().CannonDmgLvl.ToString ();
			CannonFRLevelText.text = gameObject.GetComponent<UpgradeScript> ().CannonFrLvl.ToString ();
			HullLevelText.text = gameObject.GetComponent<UpgradeScript> ().PlayerMhpLvl.ToString ();
			ThrusterLevelText.text = gameObject.GetComponent<UpgradeScript> ().PlayerMoveSpeedLevel.ToString ();
			//Listen for the space bar to launch the game
			if (Input.GetKeyDown ("space"))
				Application.LoadLevel (1);
		}
	}
}