using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftKick : StateMachineBehaviour
{
    private Animator animator;
    public Collider leftToeBase;
    public bool kick;

    void Start(){
        animator = GameObject.Find("unitychan_dynamic").GetComponent<Animator>();
        leftToeBase = GameObject.Find("Character1_LeftToeBase").GetComponent<SphereCollider>();
        kick=false;
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       kick = false;
       animator.SetBool("Kick", kick);
      // leftToeBase.enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       //leftToeBase.enabled = false;
    }

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
