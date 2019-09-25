using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPunch1 : StateMachineBehaviour
{
    const float ATK_START=0.35f;
    const float ATK_END=0.55f;

    public float movingTime;
    public Collider character1_LeftHand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        animator.SetBool("Punch", false);
        animator.SetBool("Atk", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        character1_LeftHand = GameObject.Find("Character1_LeftHand").GetComponent<SphereCollider>();
        movingTime = animator.GetFloat("MovingTime");

        if(ATK_START<=movingTime&&movingTime<=ATK_END){
            character1_LeftHand.enabled = true;
        }else{
            character1_LeftHand.enabled = false;		
        }
    }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
      
    // }

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