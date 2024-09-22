using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30;
    public float spawnRateIncrement = 1f;
    private float spawnNext = 0;

    public float maxTimeLimit = 3f;
    public float xLimit;
    // Update is called once per frame
    void Update()
    {
       if(Time.time > spawnNext) {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            
            spawnRatePerMinute += spawnRateIncrement;
            
            float rand = Random.Range(-xLimit, xLimit);

            Vector3 spawnPosition = new Vector3(rand, 7.5f, 6.21f);
           
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            Destroy(meteor, maxTimeLimit);
       
       }
    }
}
