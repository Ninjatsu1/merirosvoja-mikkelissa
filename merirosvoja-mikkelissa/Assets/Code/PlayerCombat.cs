using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    public GameObject sword;
    public bool attackAnimationPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Left mouse click
        {
            // Debug.Log("attack");
            MeleeAttack();
           
        }
       
        
    }
    void MeleeAttack()
    {
        Invoke("hideSword", 3.4f);
            attackAnimationPlaying = true;
        
            Debug.Log("lyö");
            sword.SetActive(true);
            //Play animation
            anim.SetTrigger("Attack");
            attackAnimationPlaying = false;

           
            Debug.Log("piilo");
        
        // 
        //sword.SetActive(false);
        //Detect enemies in range of attack
        //Damage the enemy
    }
    void hideSword()
    {
        sword.SetActive(false);

    }
}
