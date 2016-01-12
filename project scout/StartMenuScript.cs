using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
	public GameControllerScript GameController;
	public UpgradeScript UpgradeScript;
	// Use this for initialization
	void Start ()
	{
		GameController = GameObject.Find ("GameController").GetComponent<GameControllerScript> ();
		UpgradeScript = GameObject.Find ("GameController").GetComponent<UpgradeScript> ();
	}

	public void MainMenuLoad ()
	{
		Application.LoadLevel (0);
	}

	public void StartGame ()
	{
		Application.LoadLevel (3);
	}

	public void CreditsLoad ()
	{
		Application.LoadLevel (2);
	}

	public void HardReset ()
	{
		UpgradeScript.CannonDmgLvl = 1;
		UpgradeScript.CannonFrLvl = 1;
		UpgradeScript.PlayerMhpLvl = 1;
		UpgradeScript.PlayerMoveSpeedLevel = 0;
		UpgradeScript.SetCannonDmgLvl (UpgradeScript.CannonDmgLvl);
		UpgradeScript.SetCannonFRLvl (UpgradeScript.CannonFrLvl);
		UpgradeScript.SetPlayerMHPLevel (UpgradeScript.PlayerMhpLvl);
		UpgradeScript.SetPlayerMoveSpeedLevel (UpgradeScript.PlayerMoveSpeedLevel);
	}
}
