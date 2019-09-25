using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    
    void Start(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(Input.GetMouseButtonDown(0)){
            animator.SetBool("Punch",true);
        }
        if(Input.GetMouseButtonDown(1)){
            animator.SetBool("Kick", true);
        }
    }

    void Hit(){

    }

    void TestScript(float start,int end,Object atkObject){
        Debug.Log(start+" "+end);
    }
}
