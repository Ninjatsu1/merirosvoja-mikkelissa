using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_walk : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D MyRigidbody2D;
    public float speed = 3f;
    Boss_Squid boss_squid;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //    
       player = GameObject.FindGameObjectWithTag("Player").transform;
        MyRigidbody2D = animator.GetComponent<Rigidbody2D>();
        boss_squid = animator.GetComponent<Boss_Squid>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss_squid.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, MyRigidbody2D.position.y);
        Vector2 NewPosition = Vector2.MoveTowards(MyRigidbody2D.position, target, speed * Time.fixedDeltaTime);
        MyRigidbody2D.MovePosition(NewPosition);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

  
}
