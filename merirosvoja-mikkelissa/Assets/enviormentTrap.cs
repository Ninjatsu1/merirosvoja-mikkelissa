using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviormentTrap : MonoBehaviour
{



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Health.health -= 1;
            Destroy(gameObject);

        }
    }
}
