using UnityEngine;
using System.Collections;

public class BossEnemyScript : MonoBehaviour {

    public float hpMax;
    public float hpCurrent;
    public float expValue;
    public float salvageValue;
    public int level;
    public GameObject explosionPrefab;
    public gameControllerScript gameController;

    // Use this for initialization
    void Start()
    {
        //Find the game controller
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();

        level = gameController.enemyLevel;
        hpMax = (level * 10) + 10;
        hpCurrent = hpMax;
        salvageValue = level * 0.35f;
        expValue = (level * 0.75f) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Current HP cannot go negitive
        if (hpCurrent <= 0)
        {
            gameController.currentExp += expValue;
            gameController.currentSalvage += salvageValue;
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation) as GameObject;
            GameObject.Destroy(this.gameObject);
        }
    }
}
