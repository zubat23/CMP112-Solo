using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;

    private int wave = 0;
    private float enemiesPerWave = 3;
    private float multiplier = 1f;
    private float multiplierIncrement = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if (Global.enemiesRemaining == 0)
        {
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
}
