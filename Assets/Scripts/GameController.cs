using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public GameObject upgradePrefab;
    public GameObject upgradeParent;

    public AudioClip upgradeSound;

    private int wave = 0;
    private float enemiesPerWave = 3;
    private float multiplier = 1f;
    private float multiplierIncrement = 0.5f;

    private int upgradesToChoose = 3;

    private bool endingGame = false;

    private upgradeInfo[] upgrades = new upgradeInfo[]
    {
        new upgradeInfo(0, "AmmoUpgrade", "Increase max ammo by 2", 2f),
        new upgradeInfo(1, "DamageUpgrade", "Increase bullet damage by 4", 4f),
        new upgradeInfo(2, "HealthUpgrade", "Increase max health by 10", 10f),
        new upgradeInfo(3, "JumpUpgrade", "Increase jump height by 40%", 0.4f),
        new upgradeInfo(4, "PiercingUpgrade", "Increase bullet piercing by 1", 1f),
        new upgradeInfo(5, "SpeedUpgrade", "Increase movement speed by 30%", 0.3f)
    };

struct upgradeInfo
    {
        public int index;
        public string name;
        public string description;
        public float upgradeAmount;
        public upgradeInfo(int index, string name, string description, float upgradeAmount)
        {
            this.index = index;
            this.name = name;
            this.description = description;
            this.upgradeAmount = upgradeAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.enemiesRemaining == 0 && Global.waveActive)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            Global.waveActive = false;
            Global.enemiesRemaining = -1;
            upgradeSelection();
        }
        else if (Global.enemiesRemaining == -1 && Global.waveActive)
        {
            SfxManager.Instance.PlaySound(upgradeSound, transform, 1f);
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            wave++;
            setupWave();
        }

        if (player == null && !endingGame)
        {
            endingGame = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            StartCoroutine(loadDeathScreen());

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

            upgradeObject.GetComponent<Upgrade>().setupUpgrade(selectedUpgrade.index, selectedUpgrade.name, selectedUpgrade.description, selectedUpgrade.upgradeAmount);
            
            xPosition += 250f;
        }
    }

    IEnumerator loadDeathScreen()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Death Screen");
    }
}
