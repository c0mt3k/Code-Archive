using System.Collections;
using UnityEngine;

public class GameMenuScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void ReturnToHangar ()
	{
		Application.LoadLevel (3);
	}
}
