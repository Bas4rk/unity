using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_Attack2 : StateMachineBehaviour
{
    const float ATK_START=0.1f;
    const float ATK_END=0.55f;
    const int ATK_DAMAGE=4;

    public float movingTime;
    public Collider sword;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("SwordAttack", false);
        //animator.SetBool("Atk", true);
        animator.SetInteger("AtkDamage",ATK_DAMAGE);  
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sword = GameObject.Find("Sword").GetComponent<CapsuleCollider>();
        //animator.SetFloat("MovingTime",0.8f);
        movingTime=animator.GetFloat("MovingTime");
        //sword.enabled = true;
        if(ATK_START<=movingTime&&movingTime<=ATK_END){ 
            sword.enabled = true;
        }else{
            sword.enabled = false;		
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
