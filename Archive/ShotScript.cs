using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{

    public int damage = 1;

    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }
    void FixedUpdate()
    {
        float step = 5000f * Time.deltaTime;
        rigidbody2D.velocity = transform.right * step;
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Enemy")
        {
            otherCollider.GetComponent<EnemyScript>().hpCurrent -= damage;
            Destroy(this.gameObject);
        }
    }
}
