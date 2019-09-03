using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    public Collider rightToeBase;
    public char nextClick;

    void Start(){
        animator = GetComponent<Animator>();
        rightToeBase = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();
        nextClick='0';
    }

    // Update is called once per frame
    void Update(){
        //左クリックでkick
        if(nextClick=='0'){
            
        }

        if (Input.GetMouseButtonDown(1)){
            animator.SetBool("Kick", true);
 
            //右足コライダーをオンにする
            rightToeBase.enabled = true;
 
            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 1.5f);
        }else{
            animator.SetBool("Kick", false);
        }
    }


    private void ColliderReset(){
        // handCollider.enabled = false;
        rightToeBase.enabled = false;
    }
    void Hit(){

    }
}
