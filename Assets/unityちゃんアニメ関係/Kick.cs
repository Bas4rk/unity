using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : StateMachineBehaviour
{

    const float ATK_MOVE_SPEED = 2f;
    public int kickNum = 0;
    // private Animator animator;
    // public Collider leftToeBase;

    void Start(){
      
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        animator.SetBool("Kick", false);
        animator.SetBool("Atk", true);
        kickNum = animator.GetInteger("KickNum");
        kickNum++;
        animator.SetInteger("KickNum",kickNum);
        // leftToeBase.enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    //    unityChanMovement.setSpeed(ATK_MOVE_SPEED);
        // gameObject.GetComponent<UnityChanMovement>().setSpeed(ATK_MOVE_SPEED);
    }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //    leftToeBase.enabled = false;
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
