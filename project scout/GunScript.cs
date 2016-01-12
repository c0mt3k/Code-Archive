using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class GunScript : MonoBehaviour
{

	public List<Transform> GunObjects;
	public Transform SelectedGunObject;
	public Rigidbody2D BulletPrefab;
	public AudioClip GunShotClip;
	public AudioSource Audio;
	int i = 0;

	// Use this for initialization
	void Start ()
	{
		//Find the Audio Source to scale gunshot sound to volume level
		Audio = GetComponent<AudioSource> ();

		//Find each GunObject in children elements and add it to the list
		foreach (Transform child in transform)
			GunObjects.Add (child.gameObject.transform);
	}

	// Update is called once per frame
	void Update ()
	{
		//Reset the counter if we have gone through all of the gunObjects
		if (i <= GunObjects.Count)
			i = 0;
	}

	//Function to fire the weapon
	public void Fire ()
	{
		while (i < GunObjects.Count) {
			SelectedGunObject = GunObjects [i].transform;
			i += 1;
			Audio.PlayOneShot (GunShotClip);
			Rigidbody2D bulletClone = Instantiate (BulletPrefab, SelectedGunObject.transform.position, SelectedGunObject.transform.rotation) as Rigidbody2D;
		}
	}
}
