using System.Collections;
using UnityEngine;

public class HangarScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void BackToMainMenu ()
	{
		Application.LoadLevel (0);
	}

	public void LaunchScout ()
	{
		Application.LoadLevel (1);
	}

	public void UpgradeCannonDmg ()
	{
		if (Object.FindObjectOfType<UpgradeScript> ().CannonDmgLvl < 10) {
			Object.FindObjectOfType<UpgradeScript> ().SetCannonDmgLvl (Object.FindObjectOfType<UpgradeScript> ().CannonDmgLvl += 1);
		}
	}

	public void UpgradeCannonFR ()
	{
		if (Object.FindObjectOfType<UpgradeScript> ().CannonFrLvl < 5) {
			Object.FindObjectOfType<UpgradeScript> ().SetCannonFRLvl (Object.FindObjectOfType<UpgradeScript> ().CannonFrLvl += 1);
		}
	}

	public void UpgradePlayerMHP ()
	{
		if (Object.FindObjectOfType<UpgradeScript> ().PlayerMhpLvl < 10) {
			Object.FindObjectOfType<UpgradeScript> ().SetPlayerMHPLevel (Object.FindObjectOfType<UpgradeScript> ().PlayerMhpLvl += 1);
		}
	}

	public void UpgradePlayerMoveSpeed ()
	{
		if (Object.FindObjectOfType<UpgradeScript> ().PlayerMoveSpeedLevel < 5) {
			Object.FindObjectOfType<UpgradeScript> ().SetPlayerMoveSpeedLevel (Object.FindObjectOfType<UpgradeScript> ().PlayerMoveSpeedLevel += 1);
		}
	}
}
