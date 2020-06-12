using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;
    private Animator anim;

    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {

                Collider2D[] enemiesToDamange = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamange.Length; i++)
                {
                    enemiesToDamange[i].GetComponent<Patrol>().TakeDamage(damage);
                    enemiesToDamange[i].GetComponent<ShootingEnemy>().TakeDamage(damage);
                    enemiesToDamange[i].GetComponent<FlyingPatrol>().TakeDamage(damage);
                    enemiesToDamange[i].GetComponent<projectTile>().TakeDamage(damage);

                }
                anim.SetBool("Ishit", true);
            }
            else
            {
                anim.SetBool("Ishit", false);
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    //helps visualize attack and range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
