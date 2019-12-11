using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShordGetScript : MonoBehaviour
{
// Start is called before the first frame update
const float TARAGET_SEARCH=2f; //索敵範囲
public GameObject TargetObject; ///目標位置
// public GameObject o;
// public GameObject weapon;
public GameObject gameObject;
public    GameObject characterPre;//生成するもの
public    GameObject character;
public    Animator animator;
void Start()
{
    // o = transform.gameObject;
    animator = GetComponent<Animator>();
     
}
// Update is called once per frame
void Update(){
    float dis = Vector3.Distance(this.transform.position,TargetObject.transform.position);
    // animator.GetBool("Shord");
    if(dis<TARAGET_SEARCH && animator.GetBool("Sword")==false){
        gameObject.SetActive(true);  
        animator.SetBool ("Sword", true);	 
    }
}
}
//o.transform.position
//o.transform.position.x,o.transform.position.y,o.transform.position.z