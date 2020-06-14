using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Squid : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    public float BossHealth;
    public GameObject effectToDie;

    void update () {

        if (BossHealth <= 0)
        {
            Instantiate(effectToDie, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("Hurt");//td
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }

    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void TakeDamage(int damage)
    {
        BossHealth -= damage;

    }
    
}
