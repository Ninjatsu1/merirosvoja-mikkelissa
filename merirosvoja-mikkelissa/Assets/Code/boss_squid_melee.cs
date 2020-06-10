using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_squid_melee : MonoBehaviour
{
    public int attackDamage = 5;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    // Start is called before the first frame update

    public void MeleeAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            Debug.Log("Damaged player");
        }
    }
    
}
