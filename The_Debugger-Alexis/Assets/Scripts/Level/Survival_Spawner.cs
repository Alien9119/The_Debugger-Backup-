using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survival_Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;

    public float timeUnitilActive;
    
    public GameObject[] enemies;
    public float minTimeSpawns;
    public float maxTimeSpawns;
    public bool canSpawn;
    public float spawnTime;
    public int enemiesInRoom;
    public bool spawnerDone;
    //public GameObject spawnerDoneGameObject;

    //public GameObject Nest;
    private SpriteRenderer NestRender;

    private void Start()
    {
        StartCoroutine(Delay());
        Invoke("SpawnEnemy", 0.5f);
    }

    private void Update()
    {
        if (canSpawn)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                canSpawn = false;
            }
        }
    }

    void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeSpawns = Random.Range(minTimeSpawns, maxTimeSpawns);

        if (canSpawn)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], currentPoint.transform.position, Quaternion.identity);
            enemiesInRoom++;
        }

        Invoke("SpawnEnemy", timeSpawns);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(timeUnitilActive);
        canSpawn = true;
    }
}
