using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public float hpMax;
    public float hpCurrent;
    public float expValue;
    public float salvageValue;
    public int level;
    public bool isBoss;
    public GameObject explosionPrefab;
    public gameControllerScript gameController;

    // Use this for initialization
    void Start()
    {
        //Find the game controller
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();

        level = gameController.enemyLevel;
        if (isBoss == false)
        {
            hpMax = Random.Range(gameController.playerMissileDamage *1,gameController.playerMissileDamage *3);
            hpCurrent = hpMax;
            salvageValue = gameController.playerLevel * 0.15f;
            expValue = (gameController.playerLevel * 0.5f);
        }
        if (isBoss == true)
        {
            hpMax = Random.Range(gameController.playerMissileDamage * 5, gameController.playerMissileDamage * 7);
            hpCurrent = hpMax;
            salvageValue = gameController.playerLevel * 0.35f;
            expValue = (gameController.playerLevel * 1.5f);
        }
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
