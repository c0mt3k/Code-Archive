using UnityEngine;
using System.Collections;

public class GunTurretScript : MonoBehaviour
{

    public Rigidbody2D ShotPrefab;
    public Transform selectedTargetEnemy;
    public float shotCooldown;
    public float shotRate;
    public gameControllerScript gameController;
    public TurretRotatorScript turretTargetSystem;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();
        turretTargetSystem = gameObject.GetComponentInParent<TurretRotatorScript>();
        selectedTargetEnemy = turretTargetSystem.selectedTargetEnemy;
        shotRate = Random.Range(0.50f, 0.75f);
        shotCooldown = Random.Range(0f, 0.75f);
    }
    void Update()
    {
        //Find a new target if ours dies
        selectedTargetEnemy = turretTargetSystem.selectedTargetEnemy;
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
    //void FixedUpdate()
    //{
    //    //rotate towards the enemy if we have a target
    //    if (selectedTargetEnemy != null)
    //    {
    //        Vector3 dir = selectedTargetEnemy.transform.position - transform.position;
    //        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    }
    //}
}
