﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectTile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public float enemyHealth;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // if you want projectTile to follow the player then change "TARGET" to "PLAYER.POSITION"

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjecTile();
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            DestroyProjecTile();
            Health.health -= 1;
        }
    }
    void DestroyProjecTile()
    {
        Destroy(gameObject);
    }


    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

    }

}
