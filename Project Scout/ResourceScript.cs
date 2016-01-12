using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResourceScript : MonoBehaviour
{
	#region Public Variables
	// Resource values
	public float RRocks;
	public float RMetals;
	public float RGases;
	public float ROrganic;
	//Resource Text fields (Set these in the editor)
	public Text RockText;
	public Text MetalText;
	public Text GasText;
	public Text OrganicText;
	#endregion

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Update Text elements when the game is paused
		if (Object.FindObjectOfType<GameControllerScript> ().IsPaused) {
			RockText.text = string.Format (RRocks.ToString ("F2"));
			MetalText.text = string.Format (RMetals.ToString ("F2"));
			GasText.text = string.Format (RGases.ToString ("F2"));
			OrganicText.text = string.Format (ROrganic.ToString ("F2"));
		}
	}
}