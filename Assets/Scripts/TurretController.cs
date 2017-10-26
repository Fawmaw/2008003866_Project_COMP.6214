﻿using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject EnemyShot;
    private GameObject player;
    private int turretLives;
    void Start()
    {
        turretLives = 4;
        player = GameObject.Find("Player");
        StartCoroutine("TurretShoot");
    }
    void Update()
    {
        transform.position = transform.parent.position;
        if (player != null)
        {
            transform.up = (player.transform.position - transform.position) / 1.5f;
        }
    }
    IEnumerator TurretShoot()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            Instantiate(EnemyShot, transform.position, transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "SingleShot(Clone)" && PlayerScript.onUpperLayer == false)
        {
            turretLives--;
            //PlayerScript.UpdateText();
            if (turretLives < 1)
            {
                Destroy(gameObject);
                PlayerScript.score += 100;
            }
            Destroy(collision.gameObject);
        }
    }
}
