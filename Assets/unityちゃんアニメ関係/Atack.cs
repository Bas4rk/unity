using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    public Collider rightToeBase;
    public Collider leftToeBase;

    public char nextClick;
    public int kick;

    
    void Start(){
        animator = GetComponent<Animator>();
        rightToeBase = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();
        leftToeBase = GameObject.Find("Character1_LeftToeBase").GetComponent<SphereCollider>();
        nextClick='0';
        kick=0;
    }

    // Update is called once per frame
    void Update(){

        // if (Input.GetMouseButtonDown(1)){
        //     animator.SetBool("Kick", true);
 
        //     //右足コライダーをオンにする
        //     rightToeBase.enabled = true;
 
        //     //一定時間後にコライダーの機能をオフにする
        //     Invoke("ColliderReset", 1.5f);
        // }else{
        //     animator.SetBool("Kick", false);
        // }

        // if(Input.GetMouseButtonDown(1) && animator.GetCurrentAnimatorStateInfo(0).IsName("BlendTree")){
        //     animator.SetBool ("Kick", true);
        //     leftToeBase.enabled = true;
        //     Invoke("LeftColliderReset", 1.0f);		
        // }else{
        //     animator.SetBool("Kick", false);
        // }

        // if(Input.GetMouseButtonDown(1) && animator.GetCurrentAnimatorStateInfo(0).IsName("Kick1")){
        //     animator.SetBool ("Kick2", true);
        //     rightToeBase.enabled = true;
        //     Invoke("RightColliderReset", 1.0f);
        // }else{
        //     animator.SetBool("Kick2", false);
        // }

        // if(Input.GetMouseButtonDown(1) && animator.GetCurrentAnimatorStateInfo(0).IsName("Kick2")){
        //     animator.SetBool ("Kick3", true);
        //     leftToeBase.enabled = true;
        //     Invoke("LeftColliderReset", 1.0f);		
        // }else{
        //     animator.SetBool("Kick3", false);
        // }

        if(Input.GetMouseButtonDown(1)){
            kick++;
            animator.SetInteger ("Kick", kick);
            if(kick%2==1){
                leftToeBase.enabled = true;
                Invoke("LeftColliderReset", 1.0f);		
            }else{
                rightToeBase.enabled = true;
                Invoke("RightColliderReset", 1.0f);
            }	
        }else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.99){
            kick=0;
            animator.SetInteger("Kick", kick);
        }
    }


    private void RightColliderReset(){
        // handCollider.enabled = false;
        rightToeBase.enabled = false;
    }

    private void LeftColliderReset(){
        // handCollider.enabled = false;
        leftToeBase.enabled = false;
    }
    void Hit(){

    }
}
