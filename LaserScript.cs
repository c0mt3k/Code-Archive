using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    LineRenderer laser;
    LaserTurret turret;
    Transform target;
    public float damage;


    void Start()
    {
        laser = this.gameObject.GetComponent<LineRenderer>();
        turret = GetComponentInParent<LaserTurret>();
        laser.enabled = false;
        damage = 70f;
    }
    void Update()
    {
        target = turret.selectedTarget;
        if (target != null)
        {
            laser.enabled = true;
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, target.position);
            target.GetComponent<MissileScript>().health -= damage * Time.deltaTime;
        }
        else
            laser.enabled = false;
    }
}
