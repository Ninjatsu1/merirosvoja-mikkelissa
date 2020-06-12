using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviormentTrap : MonoBehaviour
{



    public GameObject effectToDie;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Instantiate(effectToDie, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("Bottle");//td
            Health.health -= 1;
            Destroy(gameObject);

        }
    }
}
