using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShieldScript : MonoBehaviour {

    public float hpMax;
    public float hpCurrent;
    public float mitigation;

    public int level;

    public gameControllerScript gameController;

	// Use this for initialization
	void Start () 
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();

        level = gameController.playerLevel;
        hpMax = gameController.playerMaxShieldHp;
        hpCurrent = gameController.playerCurrentShieldHp;
        mitigation = gameController.playerShieldMitigationLevel;
	}
	
	// Update is called once per frame
	void Update () 
    {
        hpMax = gameController.playerMaxShieldHp;
        hpCurrent = gameController.playerCurrentShieldHp;
        //Current HP cannot go negitive
        if (hpCurrent <= 0)
        {
            hpCurrent = 0;
            GameObject.Destroy(this.gameObject);
        }
	}
    public void TakeDamage(float damage)
    {
        hpCurrent -= damage * mitigation;
    }
}
