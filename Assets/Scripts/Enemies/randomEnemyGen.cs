using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class randomEnemyGen : MonoBehaviour
{
    public GameObject[] enemies;
    private int randX;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int l = enemies.Length;
            randX = Random.Range(0, l);
            Instantiate(enemies[randX], transform.position, Quaternion.identity);
        }
    }
}
