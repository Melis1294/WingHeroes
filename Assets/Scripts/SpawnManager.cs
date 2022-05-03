using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] enemies;
    public GameObject powerup;
    public float spawnDelay = 2;
    public float enemySpawnInterval = 4;
    public float powerupSpawnInterval = 9;
    private float yUpperBound = 14.0f;
    private float yLowerBound = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", spawnDelay, enemySpawnInterval);
        InvokeRepeating("SpawnPowerup", spawnDelay, powerupSpawnInterval);
    }

    void SpawnRandomEnemy()
    {
        int randomindex = Random.Range(0, enemies.Length);
        Instantiate(enemies[randomindex], transform.position, enemies[randomindex].transform.rotation);
    }

    void SpawnPowerup()
    {
        float powerupsInScene = GameObject.FindGameObjectsWithTag("Powerup").Length;
        if (powerupsInScene == 0)
        {
            float randomY = Random.Range(yLowerBound, yUpperBound);
            Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
            Instantiate(powerup, spawnPos, powerup.transform.rotation);
        }
            
    }
}
