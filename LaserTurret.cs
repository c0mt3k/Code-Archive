using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserTurret : MonoBehaviour
{

    public Transform selectedTarget;
    [Tooltip("Please Enter the Player's tag")]
    public string playerTag;
    [Tooltip("Please Enter the Enemy's tag")]
    public string enemyTag;

    public CircleCollider2D range;
    public gameControllerScript gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();
        range = this.gameObject.GetComponent<CircleCollider2D>();
        range.radius = gameController.playerLaserTurretRange;
    }

    void Update()
    {
        //Rotate turret to face current target
        if (selectedTarget != null)
        {
            Vector3 dir = selectedTarget.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (this.transform.parent.tag == "Player" && otherCollider.tag == "EnemyMissile")
        {
            if (selectedTarget == null)
            {
                selectedTarget = otherCollider.transform;
            }
        }
        if (this.transform.parent.tag == "Enemy" && otherCollider.tag == "PlayerMissile")
        {
            if (selectedTarget == null)
            {
                selectedTarget = otherCollider.transform;
            }
        }
    }
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (this.transform.parent.tag == "Player" && otherCollider.tag == "EnemyMissile")
        {
            if (selectedTarget == null)
            {
                selectedTarget = otherCollider.transform;
            }
        }
        if (this.transform.parent.tag == "Enemy" && otherCollider.tag == "PlayerMissile")
        {
            if (selectedTarget == null)
            {
                selectedTarget = otherCollider.transform;
            }
        }
    }

    //void OnTriggerEnter2D(Collider2D otherCollider)
    //{
    //    if (this.GetComponentInParent<HealthScript>().isPlayer == true && otherCollider.tag == "EnemyMissile")
    //    {
    //        selectedTarget = otherCollider.transform;
    //    }
    //}
    //void OnTriggerStay2D(Collider2D otherCollider)
    //{
    //    if (this.GetComponentInParent<HealthScript>().isPlayer == true && otherCollider.tag == "EnemyMissile")
    //    {
    //        selectedTarget = otherCollider.transform;
    //    }
    //}
}
