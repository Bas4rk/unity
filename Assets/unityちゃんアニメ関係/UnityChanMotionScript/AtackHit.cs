using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackHit : MonoBehaviour{    
    //オブジェクトと接触した瞬間に呼び出される
    Animator animator;
    Animator ucAnimator;
    void OnTriggerEnter(Collider other){
 
        //攻撃した相手がEnemyの場合
        if(other.CompareTag("Enemy")){
            // Destroy(other.gameObject);
            animator = other.gameObject.GetComponent<Animator>();
            ucAnimator = GetComponent<Animator>();
            int damage = ucAnimator.GetInteger("AtkDamage");
            int hp = animator.GetInteger("HP");

            animator.SetBool("Hit",true);
            animator.SetInteger("HP",hp-damage);
            Debug.Log("hit");
 
        }
    }
}