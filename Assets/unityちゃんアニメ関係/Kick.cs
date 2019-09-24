using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : StateMachineBehaviour
{

    const float ATK_MOVE_SPEED = 2f;
    const float ATK_START=10f;

    public int kickNum = 0;
    public float MovingTime;
    public Collider rightToeBase;
    public Collider leftToeBase;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

        rightToeBase = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();
        // leftToeBase = GameObject.Find("Character1_LeftToeBase").GetComponent<SphereCollider>();

        animator.SetBool("Kick", false);
        animator.SetBool("Atk", true);
        kickNum = animator.GetInteger("KickNum");
        kickNum++;
        animator.SetInteger("KickNum",kickNum);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rightToeBase = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();
        leftToeBase = GameObject.Find("Character1_LeftToeBase").GetComponent<SphereCollider>();
        MovingTime = animator.GetFloat("MovingTime");

        if(MovingTime==1){
            if(kickNum%2==0){	
                    rightToeBase.enabled = true;		
            }else{
                    leftToeBase.enabled = true;
            }
        }else{
             if(kickNum%2==1){	
                leftToeBase.enabled = false;		
            }else{
                rightToeBase.enabled = false;	
            }
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
