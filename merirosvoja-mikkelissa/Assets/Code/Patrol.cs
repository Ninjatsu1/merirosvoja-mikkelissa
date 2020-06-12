using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRigth = true;
    public Transform groundDetection;
    public float enemyHealth;
    private Animator anim;

    public GameObject effectToDie;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D grounfInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (enemyHealth <= 0)
        {
            Instantiate(effectToDie, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        if (grounfInfo.collider == false)
        {
            if (movingRigth == true)
            {

                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRigth = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRigth = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Instantiate(effectToDie, transform.position, Quaternion.identity);

            Health.health -= 1;
            Destroy(gameObject);

        }
    }


    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

    }


}
