using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    public Collider rightToeBase;
    public Collider leftToeBase;

    public int kickNum;
    public bool kick;
    
    void Start(){
        animator = GetComponent<Animator>();
        rightToeBase = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();
        leftToeBase = GameObject.Find("Character1_LeftToeBase").GetComponent<SphereCollider>();
        kickNum=0;
        kick=false;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(Input.GetMouseButtonDown(1)){
            animator.SetBool("Kick", true);
            //kickNum++;
            kickNum = animator.GetInteger("KickNum");

            if(kickNum%2==1){	
                rightToeBase.enabled = true;
                Invoke("RightColliderReset", 1.0f);			
            }else{
                leftToeBase.enabled = true;
                Invoke("LeftColliderReset", 1.0f);			
            }
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
