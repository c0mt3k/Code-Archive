using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour
{
    public float damage;
    public float health;
    public Transform target;
    public int thrustSpeed;
    public GameObject explosionPrefab;
    public MissileLauncherScript controller;
    public gameControllerScript gameController;

    // Update is called once per frame
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();
        if (gameObject.tag == "PlayerMissile")
        {
            controller = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MissileLauncherScript>();
            damage = gameController.playerMissileDamage;
        }
        if (gameObject.tag == "EnemyMissile")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            damage = (gameController.playerLevel /2) + 0.50f;
        }
        target = controller.selectedTargetEnemy;
    }
    void Update()
    {
        //Destroy the object if it is outside the camera
        if (renderer.IsVisibleFrom(Camera.main) == false)
        {
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation) as GameObject;
            GameObject.Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        float step = thrustSpeed * Time.deltaTime;
        //rotate towards the enemy if we have a target
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.rigidbody2D.AddForce(dir * step);
        }
    }

    //Damage the target and destroy the missile
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (gameObject.tag == "PlayerMissile" && otherCollider.CompareTag("Enemy"))
        {
            otherCollider.GetComponent<EnemyScript>().hpCurrent -= damage;
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation) as GameObject;
            GameObject.Destroy(this.gameObject);
        }
        if (gameObject.tag == "EnemyMissile" && otherCollider.CompareTag("Player"))
        {
            gameController.playerCurrentHp -= damage;
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation) as GameObject;
            GameObject.Destroy(this.gameObject);
        }
        if (gameObject.tag == "EnemyMissile" && otherCollider.GetComponent<ShieldScript>())
        {
            gameController.playerCurrentShieldHp -= damage * gameController.playerShieldMitigation;
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation) as GameObject;
            GameObject.Destroy(this.gameObject);
        }
    }
}
