using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Reference to player prefab
    public GameObject player;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public GameObject enemyPrefab;
=======
=======
>>>>>>> Stashed changes

    //Reference to the prefabs for enemies
    public GameObject basicEnemy;
    public GameObject speedyEnemy;
    public GameObject bigEnemy;

    //Reference to prefabs for upgrades
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    public GameObject upgradePrefab;
    public GameObject upgradeParent;

    public AudioClip upgradeSound;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private int wave = 0;
    private float enemiesPerWave = 3;
    private float multiplier = 1f;
    private float multiplierIncrement = 0.5f;
=======
=======
>>>>>>> Stashed changes
    //Info for setting up waves
    [SerializeField] float enemiesPerWave = 3;
    [SerializeField] float multiplier = 1f;
    [SerializeField] float multiplierIncrement = 0.3f;
    [SerializeField] int wave = 0;
    private int typesOfEnemies = 1;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    private int upgradesToChoose = 3;

    private bool endingGame = false;

    //Array of type upgradeInfo to hold upgrade information
    private upgradeInfo[] upgrades = new upgradeInfo[]
    {
        new upgradeInfo(0, "AmmoUpgrade", "Increase max ammo by 2", 2f),
        new upgradeInfo(1, "DamageUpgrade", "Increase bullet damage by 4", 4f),
        new upgradeInfo(2, "HealthUpgrade", "Increase max health by 10", 10f),
        new upgradeInfo(3, "JumpUpgrade", "Increase jump height by 40%", 0.4f),
        new upgradeInfo(4, "PiercingUpgrade", "Increase bullet piercing by 1", 1f),
        new upgradeInfo(5, "SpeedUpgrade", "Increase movement speed by 30%", 0.3f)
    };

    //Struct to hold upgrade information
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
<<<<<<< Updated upstream
=======
    private void Start()
    {
        //Set all global variables to starting values
        Global.playerSpeedMult = 1f;
        Global.playerJumpForceMult = 1f;
        Global.bulletDamage = 10f;
        Global.maxAmmo = 6f;
        Global.maxHealth = 30f;
        Global.bulletPiercing = 1f;

        Global.enemiesDefeated = 0;
        Global.enemiesRemaining = 0;
        Global.waveActive = true;
    }
>>>>>>> Stashed changes

    void Update()
    {
        //If all enemies are defeated, then end wave and show upgrades
        if (Global.enemiesRemaining == 0 && Global.waveActive)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            Global.waveActive = false;
            Global.enemiesRemaining = -1;
            upgradeSelection();
        }
        //If player has selected an upgrade, then start next wave
        else if (Global.enemiesRemaining == -1 && Global.waveActive)
        {
            SfxManager.Instance.PlaySound(upgradeSound, transform, 1f);
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            wave++;
            setupWave();
        }

        //Ends the game after player dies
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        //increase wave by one, and if it's the correct wave, add different enemies
        wave++;
        if (wave == 3 || wave == 6)
        {
            typesOfEnemies++;
        }

        //Calculate how many enemies to spawn
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        Global.enemiesRemaining = Mathf.RoundToInt(enemiesPerWave * multiplier);

        //Loop for every enemy to spawn
        for (int i = 0; i < Global.enemiesRemaining; i++)
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            float spawnX = Random.Range(-90, 30);
            float spawnZ = Random.Range(-50, 40);
            Vector3 spawnPosition = new Vector3(spawnX, 25.0f, spawnZ);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
=======
            //Select random enemy type
            int randomEnemyType = Random.Range(0, typesOfEnemies);

            //get position to spawn enemy at
            float spawnX = Random.Range(-90, 30);
            float spawnZ = Random.Range(-50, 40);
            Vector3 spawnPosition = new Vector3(spawnX, 25.0f, spawnZ);
=======
            //Select random enemy type
            int randomEnemyType = Random.Range(0, typesOfEnemies);

            //get position to spawn enemy at
            float spawnX = Random.Range(-90, 30);
            float spawnZ = Random.Range(-50, 40);
            Vector3 spawnPosition = new Vector3(spawnX, 25.0f, spawnZ);
>>>>>>> Stashed changes

            //Get what type of enemy to spawn and spawn it
            switch (randomEnemyType)
            {
                case 0:
                    Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(speedyEnemy, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bigEnemy, spawnPosition, Quaternion.identity);
                    break;
            }
>>>>>>> Stashed changes
        }
        //Increase base value and multiplier for next wave
        multiplier += multiplierIncrement;
        enemiesPerWave++;
    }

    void upgradeSelection()
    {
        float xPosition = -250f;

        for (int i = 0; i < upgradesToChoose; i++)
        {
            //Select random upgrade from upgrades array
            int randomIndex = Random.Range(0, upgrades.Length);
            upgradeInfo selectedUpgrade = upgrades[randomIndex];
            GameObject upgradeObject = Instantiate(upgradePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        
            Vector3 spawnPosition = new Vector3(xPosition, 0, 0);

            //Make the upgrade object a child of the UI parent object and set its position and scale
            upgradeObject.transform.SetParent(upgradeParent.transform);
            upgradeObject.transform.localPosition = spawnPosition;
            upgradeObject.transform.localScale = new Vector3(1, 1, 1);

            //Change the upgrade object's properties based on the selected upgrade
            upgradeObject.GetComponent<Upgrade>().setupUpgrade(selectedUpgrade.index, selectedUpgrade.name, selectedUpgrade.description, selectedUpgrade.upgradeAmount);

            //Make sure the next upgrade spawns in the correct position
            xPosition += 250f;
        }
    }

    IEnumerator loadDeathScreen()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Death Screen");
    }
}
