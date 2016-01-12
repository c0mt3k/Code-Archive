using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

	#region PublicVariables
	public List<Transform> Cannons;
	public GameObject SelectedCannon;
	public UpgradeScript Upgrader;
	public float Cooldown;
	public float FireRate;
	#endregion

	int i;

	// Use this for initialization
	void Start ()
	{
		Upgrader = Object.FindObjectOfType<UpgradeScript> ();
		Cooldown = 0;

		foreach (Transform child in transform)
			Cannons.Add (child.transform);
	}

	// Update is called once per frame
	void Update ()
	{
		FireRate = .3f - (Upgrader.CannonFrLvl * 0.05f);
		if (Cooldown > 0)
			Cooldown -= Time.deltaTime;
		if (i == Cannons.Count)
			i = 0;
		while (i < Cannons.Count) {
			SelectedCannon = Cannons [i].gameObject;
			if (Cooldown <= 0) {
				i += 1;
				Cooldown += FireRate;
				SelectedCannon.gameObject.GetComponent<GunScript> ().SendMessage ("Fire");
			} else
				break;
		}
	}
}
