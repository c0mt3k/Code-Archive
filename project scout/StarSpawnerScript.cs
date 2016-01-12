using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawnerScript : MonoBehaviour
{

	public List<Rigidbody2D> Stars;
	float cooldown;
	float spawnRate = .001f;

	//Asteroid Speed Variables
	[Range(0.1f, 5)]
	public float
		StarSpeedMin = 0.1f;
	[Range(0.1f, 5)]
	public float
		StarSpeedMax = 0.5f;

	// Use this for initialization
	void Start ()
	{
		cooldown = spawnRate;
	}

	// Update is called once per frame
	void Update ()
	{
		if (cooldown <= 0)
			Spawn ();
		if (cooldown > 0)
			cooldown -= Time.deltaTime;
	}

	void Spawn ()
	{
		cooldown += spawnRate;
		Rigidbody2D asteroidClone = Instantiate (Stars [Random.Range (0, Stars.Count)], new Vector3 (Random.Range (40, -40), 24, 0), transform.rotation) as Rigidbody2D;
		Vector3 dir = new Vector3 (asteroidClone.transform.position.x, (asteroidClone.transform.position.y - 26), 0) - asteroidClone.transform.position;
		asteroidClone.GetComponent<Rigidbody2D> ().velocity = dir * Random.Range (StarSpeedMin, StarSpeedMax);
		asteroidClone.GetComponent<Transform> ().localScale = new Vector3 (Random.Range (.05f, .05f), Random.Range (.05f, .05f), 1);
	}
}
