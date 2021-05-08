using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    Transform Player;
    Rigidbody2D rb;
    public float speed = 2.5f;
    Boss Boss;
    public float AttackRange = 3f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Player =  GameObject.FindGameObjectWithTag("Player").transform;
       rb= animator.GetComponent<Rigidbody2D>();
        Boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.LookAtPlayer();

        Vector2 target = new Vector2(Player.position.x, rb.position.y);
        Vector2 newPosition =  Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if(Vector2.Distance(Player.position, rb.position) <= AttackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}
