using System.Collections;
using UnityEngine;

public class StarScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		//Destroy the object if it is outside the camera
		if (!GetComponent<Renderer> ().IsVisibleFrom (Camera.main))
			Destroy (gameObject);
	}
}
