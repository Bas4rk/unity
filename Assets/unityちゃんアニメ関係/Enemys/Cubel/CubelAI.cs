using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubelAI : MonoBehaviour
{
    const float TIME_OUT=3f;        //射撃間隔
    const float TARAGET_SEARCH=20f; //索敵範囲
    const float TARGET_DISTANCE=4f; //対象との適正距離
    const float BACK_SPEED=-0.03f;  //後退速度
    const int MAX_HP=10;            //最大HP

    private float timeElapsed;
    public GameObject Bullet;
    Vector3 parent;

    public GameObject TargetObject; ///目標位置
    NavMeshAgent m_navMeshAgent; /// NavMeshAgent
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // NavMeshAgent コンポーネントを取得
        m_navMeshAgent=GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("HP",MAX_HP);
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetInteger("HP")>0&&animator.GetBool("Hit")==false){
            Debug.Log(m_navMeshAgent.remainingDistance);
            float dis = Vector3.Distance(this.transform.position,TargetObject.transform.position);
            if(dis<TARAGET_SEARCH){//索敵範囲に入ったら追跡
                // NavMesh が準備できているなら
                if(m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid){
                    // NavMeshAgent に目的地をセット
                    m_navMeshAgent.SetDestination(TargetObject.transform.position);
                }
                // 一定時間ごとに弾を射出する
                timeElapsed += Time.deltaTime;
                if(timeElapsed>=TIME_OUT){
                    GameObject obj = (GameObject)Resources.Load("Bullet");
                    Instantiate(obj,transform.position,transform.rotation);
                    timeElapsed=0.0f;
                }


                if(m_navMeshAgent.remainingDistance<TARGET_DISTANCE){//近づきすぎた場合に後ろへ下がる
                    this.transform.position += this.transform.forward * BACK_SPEED;
                }

                //　プレイヤーの方向を取得
                var playerDirection = new Vector3(TargetObject.transform.position.x, transform.position.y, TargetObject.transform.position.z) - transform.position;
                //　敵の向きをプレイヤーの方向に少しづつ変える
                var dir = Vector3.RotateTowards(transform.forward, playerDirection, m_navMeshAgent.angularSpeed * Time.deltaTime, 0f);
                //　算出した方向の角度を敵の角度に設定
                transform.rotation = Quaternion.LookRotation(dir);
            }else{
                m_navMeshAgent.SetDestination(this.transform.position);
            }

        }
        if(animator.GetBool("Death"))Destroy(this.gameObject);
    }
}
