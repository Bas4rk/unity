using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    public Collider rightToeBase;

    void Start(){
        animator = GetComponent<Animator>();
        rightToeBase = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update(){
        //Sを押すとHikick
        if (Input.GetKeyDown(KeyCode.F)){
            animator.SetBool("Kick", true);
 
            //右足コライダーをオンにする
            rightToeBase.enabled = true;
 
            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 1.5f);
        }
    }

    private void ColliderReset(){
        // handCollider.enabled = false;
        rightToeBase.enabled = false;
    }
    void Hit(){

    }
}
