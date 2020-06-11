using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public float stoppinDistance;
    public float retReatDistance;
    private Transform player;

    // Shooting
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectTile;
    public float enemyHealth;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (Vector2.Distance(transform.position, player.position) > stoppinDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, player.position) < stoppinDistance && Vector2.Distance(transform.position, player.position) > retReatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retReatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots < 0)
        {
            Instantiate(projectTile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
            timeBtwShots -= Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Health.health -= 1;
            Destroy(gameObject);

        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

    }
}
