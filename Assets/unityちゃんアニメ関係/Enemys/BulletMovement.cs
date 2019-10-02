using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    const float SPEED=0.5f;
    const float LIFE_TIME=5;
    const int INPACT_LEVEL=3;

    public Animator unityAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,LIFE_TIME);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        this.transform.position += this.transform.forward * SPEED;
    }

    void OnTriggerEnter(Collider other)
    {
 
        //攻撃した相手がPlayerの場合
        if(other.CompareTag("Player")){
            Debug.Log("Hit");
            unityAnimator=other.GetComponent<Animator>();
            unityAnimator.SetInteger("ImpactLevel",INPACT_LEVEL);
        }
    }
}
