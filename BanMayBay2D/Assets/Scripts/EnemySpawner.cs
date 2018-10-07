using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyGO;
    float maxSpawnRateInSeconds=5f;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // function to spawn an enemy
    void SpawnEnemy()
    {
        // bottom left
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // top right
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject enemy = (GameObject)Instantiate(EnemyGO);
        enemy.transform.position = new Vector2(Random.Range(min.x,max.x),max.y);
        ScheduledNextEnemySpawn();

    }
    void ScheduledNextEnemySpawn()
    {
        float spawnInSecond;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSecond = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSecond = 1f;
        Invoke("SpawnEnemy", spawnInSecond);
    }
    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if(maxSpawnRateInSeconds == 1)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
    // function to stop enemy spawner
    public void UnScheduledEnemySpawn()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
    // function to start enemy spawner
    public void ScheduleEnemySpawner()
    {
        //reset max spawn rate
        maxSpawnRateInSeconds = 5f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        // increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }
}
