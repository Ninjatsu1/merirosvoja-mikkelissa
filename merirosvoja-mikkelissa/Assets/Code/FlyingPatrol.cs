﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime;

    public float enemyHealth;

    public GameObject effectToDie;


    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {



        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (enemyHealth <= 0)
        {
            Instantiate(effectToDie, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("Hurt");//td
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Instantiate(effectToDie, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("Hurt");//td
            Health.health -= 1;
            Destroy(gameObject);

        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

    }

}
