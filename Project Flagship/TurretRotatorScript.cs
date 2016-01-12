using UnityEngine;
using System.Collections;

public class TurretRotatorScript : MonoBehaviour
{

    public Transform selectedTargetEnemy;

    // Use this for initialization
    void Start()
    {
        if (transform.parent.tag == "Player")
        {
            selectedTargetEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        if (transform.parent.tag == "Enemy")
        {
            selectedTargetEnemy = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        selectedTargetEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        if (GameObject.FindGameObjectWithTag("Enemy") != null && transform.parent.tag == "Player")
        {
            selectedTargetEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        if (this.transform.tag == "PlayerDrone")
        {
            selectedTargetEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        if (transform.parent.tag == "Enemy")
        {
            selectedTargetEnemy = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void FixedUpdate()
    {
        //rotate towards the enemy if we have a target
        if (selectedTargetEnemy != null)
        {
            Vector3 dir = selectedTargetEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
