using UnityEngine;
using System.Collections;

public class UpgradeScript : MonoBehaviour
{
	//Upgrade levels
	public int CannonDmgLvl;
	public int CannonFrLvl;
	public int PlayerMhpLvl;
	public int PlayerMoveSpeedLevel;

	// Use this for initialization
	void Start ()
	{
		//Retrieve upgrade levels
		GetCannonDmgLvl ();
		GetCannonFRLvl ();
		GetPlayerMHPLevel ();
		GetPlayerMoveSpeedLevel ();

		//Set initial upgrade levels if this is the first time playing
		if (CannonDmgLvl <= 1) {
			CannonDmgLvl = 1;
			SetCannonDmgLvl (CannonDmgLvl);
		}
		if (CannonFrLvl <= 1) {
			CannonFrLvl = 1;
			SetCannonFRLvl (CannonFrLvl);
		}
		if (PlayerMhpLvl <= 1) {
			PlayerMhpLvl = 1;
			SetPlayerMHPLevel (PlayerMhpLvl);
		}
	}
	// Update is called once per frame
	void Update ()
	{

	}
	//Player Cannon Damage Level functions
	public void SetCannonDmgLvl (int level)
	{
		PlayerPrefs.SetInt ("CannonDmgLvl", level);
	}

	public void GetCannonDmgLvl ()
	{
		CannonDmgLvl = PlayerPrefs.GetInt ("CannonDmgLvl");
	}
	//Player Cannon Fire Rate Level functions
	public void SetCannonFRLvl (int level)
	{
		PlayerPrefs.SetInt ("CannonFRLvl", level);
	}

	public void GetCannonFRLvl ()
	{
		CannonFrLvl = PlayerPrefs.GetInt ("CannonFRLvl");
	}
	//Player HP Level functions
	public void SetPlayerMHPLevel (int level)
	{
		PlayerPrefs.SetInt ("PlayerMHPLevel", level);
	}

	public void GetPlayerMHPLevel ()
	{
		PlayerMhpLvl = PlayerPrefs.GetInt ("PlayerMHPLevel");
	}
	//Player Move Speed Level Functions
	public void SetPlayerMoveSpeedLevel (int level)
	{
		PlayerPrefs.SetInt ("PlayerMoveSpeedLevel", level);
	}
	
	public void GetPlayerMoveSpeedLevel ()
	{
		PlayerMoveSpeedLevel = PlayerPrefs.GetInt ("PlayerMoveSpeedLevel");
	}
}
