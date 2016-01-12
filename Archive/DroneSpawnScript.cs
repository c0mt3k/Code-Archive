using UnityEngine;
using System.Collections;

public class DroneSpawnScript : MonoBehaviour
{

    public GameObject dronePrefab;
    public float shotCooldown;
    public float shotRate;

    public GameObject[] drones;

    // Use this for initialization
    void Start()
    {
        shotRate = Random.Range(1f, 1.75f);
        shotCooldown = Random.Range(0f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        drones = GameObject.FindGameObjectsWithTag("PlayerDrone");
        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
        if (GameObject.FindGameObjectWithTag("Enemy") != null && shotCooldown <= 0)
        {
            shotCooldown = shotRate;
            if (drones.Length <= 6)
            {
                GameObject drone = (GameObject)Instantiate(dronePrefab, transform.position, transform.rotation);
                drone.rigidbody2D.velocity = transform.up;
            }
        }
    }
}
