using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour
{

    public float hpCurrent;
    public GameObject explosionPrefab;
    public gameControllerScript gameController;

    // Use this for initialization
    void Start()
    {

        //Find the game controller
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();

        //Initialize settings
        hpCurrent = gameController.playerCurrentHp;
    }

    void Update()
    {
        hpCurrent = gameController.playerCurrentHp;
        //Current HP cannot go negitive
        if (hpCurrent <= 0)
        {
            hpCurrent = 0;
            GameObject explosion;
            explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation) as GameObject;
            GameObject.Destroy(this.gameObject);
        }
    }
}
