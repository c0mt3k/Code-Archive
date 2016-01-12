using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{
	public List<Rigidbody2D> Asteroids;
	float cooldown;
	float spawnRate;

	//Asteroid Speed Variables
	public float
		AsteroidSpeedMin = 0.1f;
	public float
		AsteroidSpeedMax = 0.5f;

	//Asteroid Spawn Rate Variables
	public float SpawnRateMin = .01f;
	public float SpawnRateMax = 1f;

	// Use this for initialization
	void Start ()
	{
		cooldown = Random.Range (SpawnRateMin, SpawnRateMax);
	}

	// Update is called once per frame
	void Update ()
	{
		if (cooldown <= 0) {
			spawnRate = Random.Range (SpawnRateMin, SpawnRateMax);
			Spawn ();
		}
		if (cooldown > 0)
			cooldown -= Time.deltaTime;
		if (SpawnRateMax > SpawnRateMin)
			SpawnRateMax -= Time.deltaTime / 100;
	}

	void Spawn ()
	{
		cooldown += spawnRate;
		Rigidbody2D asteroidClone;
		asteroidClone = Instantiate (Asteroids [Random.Range (0, Asteroids.Count)], new Vector3 (Random.Range (40, -40), 25, 0), transform.rotation) as Rigidbody2D;
		Vector3 dir;
		dir = new Vector3 (Random.Range (50, -50), -40, 0) - asteroidClone.transform.position;
		asteroidClone.GetComponent<Rigidbody2D> ().velocity = dir * Random.Range (AsteroidSpeedMin, AsteroidSpeedMax);
		asteroidClone.GetComponent<Transform> ().localScale = new Vector3 (Random.Range (1f, 3f), Random.Range (1f, 3f), 1);
		asteroidClone.GetComponent<AsteroidScript> ().HpMax = asteroidClone.transform.localScale.x * asteroidClone.transform.localScale.y;
	}
}
