using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour
{

    public gameControllerScript gameController;

    // Use this for initialization
    void Start()
    {
        if (Application.loadedLevel == 1)
        {
            //Find the game controller
            gameController = GameObject.FindWithTag("GameController").GetComponent<gameControllerScript>();
        }
        if (Application.loadedLevel == 2)
        {
            //Find the game controller
            gameController = GameObject.FindWithTag("GameController").GetComponent<gameControllerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void StartClick()
    {
        Application.LoadLevel(Random.Range(3,5));
    }
    public void HardReset()
    {
        PlayerPrefs.DeleteAll();
    }
    public void EnemyLevelUp()
    {
        gameController.enemyLevel += 100;
        gameController.SetEnemyLevel(gameController.enemyLevel);
    }
    public void EnemyLevelDown()
    {
        if (gameController.enemyLevel > 1)
        {
            gameController.enemyLevel -= 100;
            gameController.SetEnemyLevel(gameController.enemyLevel);
        }
    }
    public void ToHangar()
    {
        Application.LoadLevel(1);
    }
    public void PlayerHpLevelUp()
    {
        float cost = gameController.PlayerHpUpgradeLevel * gameController.PlayerHpUpgradeLevel;
        if (gameController.currentSalvage >= cost)
        {
            gameController.currentSalvage -= cost;
            gameController.SetCurrentSalvage(gameController.currentSalvage);
            gameController.playerHpUpgradeAmount += 0.01f;
            gameController.SetHpUpgradeLevel(gameController.playerHpUpgradeAmount);
            gameController.PlayerHpUpgradeLevel++;
            gameController.SetHpUpgradeCost(gameController.PlayerHpUpgradeLevel);

        }
    }
    public void MissileDamageUp()
    {
        float cost = gameController.playerMissileDamageUpgradeLevel * gameController.playerMissileDamageUpgradeLevel;
        if (gameController.currentSalvage >= cost)
        {
            gameController.currentSalvage -= cost;
            gameController.SetCurrentSalvage(gameController.currentSalvage);
            gameController.playerMissileDamageUpgradeLevel++;
            gameController.SetMissileDamageUpgradeLevel(gameController.playerMissileDamageUpgradeLevel);
        }
    }
    public void PlayerShieldMitUp()
    {
        float cost = gameController.playerShieldMitigationLevel * gameController.playerShieldMitigationLevel;
        if(cost == 0)
        {
            cost = 1;
        }
        if (gameController.currentSalvage >= cost && gameController.playerShieldMitigationLevel < gameController.playerShieldMitigationMaxLevel)
        {
            gameController.currentSalvage -= cost;
            gameController.SetCurrentSalvage(gameController.currentSalvage);
            gameController.playerShieldMitigation -= 0.01f;
            gameController.playerShieldMitigationLevel++;
            gameController.SetPlayerShieldMitigationLevel(gameController.playerShieldMitigationLevel);
            gameController.SetPlayerShieldMitigation(gameController.playerShieldMitigation);
        }
    }
    public void PlayerShieldHpUp()
    {
        float cost = gameController.playerShieldHpUpgradeLevel * gameController.playerShieldHpUpgradeLevel;
        if (gameController.currentSalvage >= cost)
        {
            gameController.currentSalvage -= cost;
            gameController.SetCurrentSalvage(gameController.currentSalvage);
            gameController.playerShieldHpUpgradeLevel++;
            gameController.SetPlayerShieldHpLevel(gameController.playerShieldHpUpgradeLevel);
        }
    }
    public void MuteGame()
    {
        if (AudioListener.pause == false)
        {
            AudioListener.pause = true;
        }
        else
            AudioListener.pause = false;
    }
    public void SpeedNormal()
    {
        Time.timeScale = 1;
    }
    public void SpeedUp()
    {
        Time.timeScale = 2;
    }
}
