﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawn : MonoBehaviour
{    
    public GameObject island;
    public GameObject battleship;
    public GameObject enemy;

    public Transform Spawn1;
    public Transform Spawn2;
    
    System.Random R = new System.Random();
    void Start()
    {
        StartCoroutine("ObstacleSpawner");
        StartCoroutine("EnemySpawner");
    }
    IEnumerator ObstacleSpawner()
    {
        while (true) //while loop instead of StartCoroutine(Spawner()); Maybe less memory use, and optional break;
        {
            float spawnTimer = R.Next(10, 15);
            switch (R.Next(1, 3))
            {
                case 1:
                    Instantiate(island, Spawn1.position, Spawn1.rotation);
                    break;
                case 2:
                    Instantiate(battleship, Spawn1.position, Spawn1.rotation);
                    break;
            }
            yield return new WaitForSeconds(spawnTimer);

            spawnTimer = R.Next(10, 15);
            switch (R.Next(1, 3))
            {
                case 1:
                    Instantiate(island, Spawn2.position, Spawn2.rotation);
                    break;
                case 2:
                    Instantiate(battleship, Spawn2.position, Spawn2.rotation);
                    break;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
    IEnumerator EnemySpawner()
    {
        int difficulty = 10;
        float spawnTimer = 0f;
        Vector3 spacer = new Vector3(0, 10, 0);
        while (true)
        {
            //left
            spawnTimer = R.Next(difficulty, difficulty++);
            spacer.x += R.Next(1, 5);
            Instantiate(enemy, spacer, enemy.transform.rotation);
            yield return new WaitForSeconds(spawnTimer);
            //right
            spawnTimer = R.Next(difficulty, difficulty++);
            spacer.x -= R.Next(1, 5);
            Instantiate(enemy, spacer, enemy.transform.rotation);
            yield return new WaitForSeconds(spawnTimer);
            //reset
            if (difficulty > 1)
            {
                difficulty--;
            }
        }
    }
}
