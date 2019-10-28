using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWavenumber;

    int enemiesRemainingToSpawn;
    float nextSpawnTime;

     void Start()
    {
        
    }
     void Update()
    {
        if (enemiesRemainingToSpawn >0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn -= 1;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            //spawn location of enemies
            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
        }
    }
    void NextWave()
    {
        currentWavenumber++;
        currentWave = waves[currentWavenumber - 1];

        enemiesRemainingToSpawn = currentWave.enemyCount;
    }
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }

}
