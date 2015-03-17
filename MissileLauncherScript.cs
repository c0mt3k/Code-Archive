using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MissileLauncherScript : MonoBehaviour

{

    public Rigidbody2D ShotPrefab;
    public Rigidbody2D PlayerShotPrefab;
    public Rigidbody2D EnemyShotPrefab;
    public Transform selectedTargetEnemy;
    public GameObject []enemyList;
    public float shotCooldown;
    public float shotRate;
    public gameControllerScript gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();
        //Decide who the script is attached to and assign the correct missile prefab
        if (transform.parent.tag == "Player")
        {
            shotRate = gameController.playerMissileFireRate;
            ShotPrefab = PlayerShotPrefab;
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            selectedTargetEnemy = enemyList[Random.Range(0, enemyList.Length)].transform;
        }
        if (transform.parent.tag == "Enemy")
        {
            shotRate = Random.Range(1f, 1.5f);
            ShotPrefab = EnemyShotPrefab;
            enemyList = GameObject.FindGameObjectsWithTag("Player");
            selectedTargetEnemy = enemyList[Random.Range(0, enemyList.Length)].transform;
        }
        shotCooldown = Random.Range(0f, 0.75f);
    }
    void Update()
    {
        //Find a new target if ours dies
        if (GameObject.FindGameObjectWithTag("Enemy") != null && transform.parent.tag == "Player")
        {
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            selectedTargetEnemy = enemyList[Random.Range(0, enemyList.Length)].transform;
        }
        //Run down the shot cooldown
        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
        //Shoot at the enemy if the shot cooldown is up and we have a target
        if (selectedTargetEnemy != null && shotCooldown <= 0)
        {
            shotCooldown = shotRate;
            Rigidbody2D bullet = (Rigidbody2D)Instantiate(ShotPrefab, transform.position, transform.rotation);
        }
    }
    void FixedUpdate()
    {

    }
}
