using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameControllerScript : MonoBehaviour
{
    //Player Variables
    public float currentExp;
    public float expToLevel;
    public int playerLevel;
    public int playerTalentPoints;
    public float playerMaxHp;
    public float playerCurrentHp;
    public float playerHpUpgradeAmount;
    public int PlayerHpUpgradeLevel;
    public float playerShieldMitigation;
    public int playerShieldMitigationLevel;
    public float playerShieldMitigationMaxLevel;
    public int playerShieldHpUpgradeLevel;
    public float playerMaxShieldHp;
    public float playerCurrentShieldHp;
    public float currentSalvage;
    public float playerMissileDamage;
    public float playerMissileFireRate;
    public int playerMissileDamageUpgradeLevel;
    public float playerMissileUpgradeDamage;
    public float playerLaserTurretRange;

    //Enemy Variables
    public int enemyLevel;

    //Text elements
    public Text playerLevelText;
    public Text playerHealthText;
    public Text salvageText;
    public Text winLoseText;
    public Text missileDamageText;
    public Text enemyLevelText;
    public Text hpLevelText;
    public Text missileDamageLevelText;
    public Text shieldMitText;
    public Text shieldHpText;

    void Start()
    {
        GetLevel();
        GetTalentPoints();
        GetExp();
        GetEnemyLevel();
        GetSalvageLevel();
        GetPlayerShieldMitigationLevel();
        GetPlayerShieldMitigation();
        GetPlayerShieldHpLevel();
        GetHpUpgradeLevel();
        GetHpUpgradeCost();
        GetMissileDamageUpgradeLevel();
        Time.timeScale = 2;

        if (playerLevel == 0)
        {
            playerLevel = 1;
            SetLevel(playerLevel);
        }
        if (enemyLevel == 0)
        {
            enemyLevel = 1;
            SetEnemyLevel(enemyLevel);
        }
        if (playerHpUpgradeAmount == 0)
        {
            playerHpUpgradeAmount = 1;
            SetHpUpgradeLevel(playerHpUpgradeAmount);
        }
        if (PlayerHpUpgradeLevel == 0)
        {
            PlayerHpUpgradeLevel = 1;
            SetHpUpgradeCost(PlayerHpUpgradeLevel);
        }
        if (playerShieldHpUpgradeLevel == 0)
        {
            playerShieldHpUpgradeLevel = 1;
        }
        if (playerShieldMitigation == 0)
        {
            playerShieldMitigation = 0.99f;
        }
        if (playerShieldMitigationLevel == 0)
        {
            playerShieldMitigationLevel = 1;
            SetPlayerShieldMitigationLevel(playerShieldMitigationLevel);
        }
        if (playerMissileFireRate == 0)
        {
            playerMissileFireRate = 3.00f;
        }
        if (playerMissileDamageUpgradeLevel == 0)
        {
            playerMissileDamageUpgradeLevel = 1;
        }

        //Test Values
        playerLaserTurretRange = 17;

        //Finalized Values
        playerMaxHp = playerLevel * 10;
        playerCurrentHp = playerMaxHp;
        playerMaxShieldHp = (playerLevel + playerShieldHpUpgradeLevel) * 20;
        playerCurrentShieldHp = playerMaxShieldHp;
        playerShieldMitigationMaxLevel = 80;
        playerMissileDamage = playerLevel + playerMissileDamageUpgradeLevel;
    }

    // Update is called once per frame
    void Update()
    {
        //Controlls level 2 (Hangar)
        if (Application.loadedLevel == 1)
        {
            //update stats
            expToLevel = playerLevel * (playerLevel * 10);
            playerMaxHp = playerLevel * 10;
            playerCurrentHp = playerMaxHp;
            playerMissileDamage = playerLevel + playerMissileDamageUpgradeLevel;
            playerMaxShieldHp = (playerLevel + playerShieldHpUpgradeLevel) * 20;
            playerCurrentShieldHp = playerMaxShieldHp;

            //Find Text Elements
            playerLevelText = GameObject.FindGameObjectWithTag("PlayerLevelText").GetComponent<Text>();
            salvageText = GameObject.FindGameObjectWithTag("PlayerSalvageLevelText").GetComponent<Text>();
            playerHealthText = GameObject.FindGameObjectWithTag("PlayerHealthText").GetComponent<Text>();
            missileDamageText = GameObject.FindGameObjectWithTag("PlayerMissileDamage").GetComponent<Text>();
            enemyLevelText = GameObject.FindGameObjectWithTag("EnemyLevelText").GetComponent<Text>();
            hpLevelText = GameObject.FindGameObjectWithTag("HpLevelText").GetComponent<Text>();
            missileDamageLevelText = GameObject.FindGameObjectWithTag("MissileDamageLevelText").GetComponent<Text>();
            shieldMitText = GameObject.FindGameObjectWithTag("ShieldMitigationText").GetComponent<Text>();
            shieldHpText = GameObject.FindGameObjectWithTag("ShieldHpText").GetComponent<Text>();

            //Update Text Elements
            playerLevelText.text = "Level: " + playerLevel.ToString() + " | " + "Exp: " + currentExp.ToString() + " / " + expToLevel.ToString() + " | " + "Talent Points: " + playerTalentPoints.ToString();
            salvageText.text = "Salvage: " + currentSalvage.ToString("C");
            playerHealthText.text = "Health: " + playerMaxHp + " | " + "Shield: " + playerMaxShieldHp + " Mitigation: " + playerShieldMitigationLevel.ToString() + "%";
            missileDamageText.text = "Missile Damage: " + playerMissileDamage.ToString() + " | Fire Rate: 1 missile per " + playerMissileFireRate.ToString() + " seconds";
            enemyLevelText.text = enemyLevel.ToString();
            hpLevelText.text = "Hp Level: " + ((playerHpUpgradeAmount / 1) * 100).ToString() + "%" + " - Cost: " + (PlayerHpUpgradeLevel * PlayerHpUpgradeLevel).ToString("C");
            missileDamageLevelText.text = "Missile Damage Level: " + playerMissileDamageUpgradeLevel.ToString() + " - Cost: " + (playerMissileDamageUpgradeLevel * playerMissileDamageUpgradeLevel).ToString("C");
            shieldMitText.text = "Shield Mitigation Level: " + playerShieldMitigationLevel.ToString() + " - Cost: " + (playerShieldMitigationLevel * playerShieldMitigationLevel).ToString("C");
            shieldHpText.text = "Shield Hp Level: " + playerShieldHpUpgradeLevel.ToString() + " - Cost: " + (playerShieldHpUpgradeLevel * playerShieldHpUpgradeLevel).ToString("C");
        }
        //Controls Patrol 1
        if (Application.loadedLevel >= 3)
        {
            //update stats
            expToLevel = playerLevel * (playerLevel * 10);
            SetExp(currentExp);
            SetCurrentSalvage(currentSalvage);
            if (playerCurrentShieldHp <= playerMaxShieldHp && playerCurrentShieldHp >= 1)
            {
                playerCurrentShieldHp += (playerMaxShieldHp * 0.01f) * Time.deltaTime;
            }
            //Shield can't go less than 0
            if (playerCurrentShieldHp <= 0)
            {
                playerCurrentShieldHp = 0;
            }

            //Increases the players level if current experience = experience to level
            if (currentExp >= expToLevel)
            {
                playerLevel++;
                playerTalentPoints++;
                currentExp = 0;
                SetLevel(playerLevel);
                SetTalentPoints(playerTalentPoints);
            }

            //Find Text Elements
            winLoseText = GameObject.FindGameObjectWithTag("WinLoseText").GetComponent<Text>();
            playerLevelText = GameObject.FindGameObjectWithTag("PlayerLevelText").GetComponent<Text>();
            salvageText = GameObject.FindGameObjectWithTag("PlayerSalvageLevelText").GetComponent<Text>();
            playerHealthText = GameObject.FindGameObjectWithTag("PlayerHealthText").GetComponent<Text>();

            //Update Text Elements
            playerLevelText.text = "Level: " + playerLevel.ToString() + " | " + "Exp: " + ((currentExp / expToLevel) * 100).ToString("F2") + "%";
            salvageText.text = "Salvage: " + currentSalvage.ToString("C");
            playerHealthText.text = "Health: " + ((playerCurrentHp / playerMaxHp) * 100).ToString("F2") + "%" + " | " + "Shield: " + ((playerCurrentShieldHp / playerMaxShieldHp) * 100).ToString("F2") + "%";

            //Check if all enemies or player is dead and restart game
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                winLoseText.text = "You Won! Restarting in 3 seconds";
                StartCoroutine("ReloadLevel");
            }
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                winLoseText.text = "You Died! Restarting in 3 seconds";
                playerCurrentHp = 0;
                StartCoroutine("ReloadLevel");
            }
        }
    }
    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(3);
        if (Application.loadedLevel == 5)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
            Application.LoadLevel(Random.Range(3, 5));
    }
    //Player Prefs
    public void SetLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
    }
    public void GetLevel()
    {
        playerLevel = PlayerPrefs.GetInt("CurrentLevel");
    }
    public void SetTalentPoints(int talentPoints)
    {
        PlayerPrefs.SetInt("PlayerTalentPoints", talentPoints);
    }
    public void GetTalentPoints()
    {
        playerTalentPoints = PlayerPrefs.GetInt("PlayerTalentPoints");
    }
    public void SetExp(float exp)
    {
        PlayerPrefs.SetFloat("CurrentExp", exp);
    }
    public void GetExp()
    {
        currentExp = PlayerPrefs.GetFloat("CurrentExp");
    }
    public void SetEnemyLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentEnemyLevel", level);
    }
    public void GetEnemyLevel()
    {
        enemyLevel = PlayerPrefs.GetInt("CurrentEnemyLevel");
    }
    public void SetCurrentSalvage(float salvage)
    {
        PlayerPrefs.SetFloat("CurrentSalvageLevel", salvage);
    }
    public void GetSalvageLevel()
    {
        currentSalvage = PlayerPrefs.GetFloat("CurrentSalvageLevel");
    }
    public void SetPlayerShieldMitigationLevel(int shieldMitigationLevel)
    {
        PlayerPrefs.SetInt("PlayerShieldMitigationLevel", shieldMitigationLevel);
    }
    public void GetPlayerShieldMitigationLevel()
    {
        playerShieldMitigationLevel = PlayerPrefs.GetInt("PlayerShieldMitigationLevel");
    }
    public void SetPlayerShieldMitigation(float shieldMitigation)
    {
        PlayerPrefs.SetFloat("PlayerShieldMitigation", shieldMitigation);
    }
    public void GetPlayerShieldMitigation()
    {
        playerShieldMitigation = PlayerPrefs.GetFloat("PlayerShieldMitigation");
    }
    public void SetPlayerShieldHpLevel(int upgradeLevel)
    {
        PlayerPrefs.SetInt("ShieldHpUpgradeLevel", upgradeLevel);
    }
    public void GetPlayerShieldHpLevel()
    {
        playerShieldHpUpgradeLevel = PlayerPrefs.GetInt("ShieldHpUpgradeLevel");
    }
    public void SetHpUpgradeLevel(float hpUpgradeLevel)
    {
        PlayerPrefs.SetFloat("HpUpgradeLevel", hpUpgradeLevel);
    }
    public void GetHpUpgradeLevel()
    {
        playerHpUpgradeAmount = PlayerPrefs.GetFloat("HpUpgradeLevel");
    }
    public void SetHpUpgradeCost(int cost)
    {
        PlayerPrefs.SetInt("HpUpgradeCost", cost);
    }
    public void GetHpUpgradeCost()
    {
        PlayerHpUpgradeLevel = PlayerPrefs.GetInt("HpUpgradeCost");
    }
    public void SetMissileDamageUpgradeLevel(int missileDamageUpgradeLevel)
    {
        PlayerPrefs.SetInt("MissileDamageUpgradeLevel", missileDamageUpgradeLevel);
    }
    public void GetMissileDamageUpgradeLevel()
    {
        playerMissileDamageUpgradeLevel = PlayerPrefs.GetInt("MissileDamageUpgradeLevel");
    }

}
