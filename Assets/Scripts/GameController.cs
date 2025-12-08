using UnityEngine;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject upgradePrefab;
    public GameObject upgradeParent;

    private int wave = 0;
    private float enemiesPerWave = 3;
    private float multiplier = 1f;
    private float multiplierIncrement = 0.5f;

    private int upgradesToChoose = 3;

    private upgradeInfo[] upgrades = new upgradeInfo[]
    {
        new upgradeInfo('A', "AmmoUpgrade_0", "Increase max ammo by 2", 2f),
        new upgradeInfo('D', "DamageUpgrade_0", "Increase bullet damage by 4", 4f),
        new upgradeInfo('H', "HealthUpgrade_0", "Increase max health by 10", 10f),
        new upgradeInfo('J', "JumpUpgrade_0", "Increase jump height by 40%", 0.4f),
        new upgradeInfo('S', "SpeedUpgrade_0", "Increase movement speed by 30%", 0.3f),
        new upgradeInfo('P', "PiercingUpgrade_0", "Increase bullet piercing by 1", 1f)
    };

struct upgradeInfo
    {
        char identifier;
        string name;
        string description;
        float upgradeAmount;
        public upgradeInfo(char identifier, string name, string description, float upgradeAmount)
        {
            this.identifier = identifier;
            this.name = name;
            this.description = description;
            this.upgradeAmount = upgradeAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.enemiesRemaining == 0)
        {
            upgradeSelection();
            wave++;
            setupWave();
        }
        Debug.Log("Wave: " + wave + " Enemies Remaining: " + Global.enemiesRemaining);
    }

    void setupWave()
    {
        Global.enemiesRemaining = Mathf.RoundToInt(enemiesPerWave * multiplier);
        for (int i = 0; i < Global.enemiesRemaining; i++)
        {
            float spawnX = Random.Range(-90, 30);
            float spawnZ = Random.Range(-50, 40);
            Vector3 spawnPosition = new Vector3(spawnX, 25.0f, spawnZ);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        multiplier += multiplierIncrement;
        enemiesPerWave++;
    }

    void upgradeSelection()
    {
        float xPosition = -250f;
        for (int i = 0; i < upgradesToChoose; i++)
        {
            int randomIndex = Random.Range(0, upgrades.Length);
            upgradeInfo selectedUpgrade = upgrades[randomIndex];
            GameObject upgradeObject = Instantiate(upgradePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        
            Vector3 spawnPosition = new Vector3(xPosition, 0, 0);

            upgradeObject.transform.SetParent(upgradeParent.transform);
            upgradeObject.transform.localPosition = spawnPosition;
            upgradeObject.transform.localScale = new Vector3(1, 1, 1);

            xPosition += 250f;
        }
    }
}
