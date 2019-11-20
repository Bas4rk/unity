using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
	public GameObject score_object;
	public GameObject score_object1;


    public Rigidbody playerRigid;
	private Animator animator;
	public CapsuleCollider mineCollider;
	public GameObject side_collider;
	public CapsuleCollider sideCollider;  


	RaycastHit hit;	// Rayが衝突したコライダーの情報を得る
    public float jumpPower;
	public float dis = 0f; //最大落下距離

	Transform rayTf;//Ray
	Ray ray;

	const float RAY_DIS_GROUND=0.5f;	//地上判定Ray距離
	const float	RAY_DIS_LANDING=0.6f;	//着地判定Ray距離
	const float RAY_DIS_FALLING=0.7f;	//落下判定Ray距離

	const float JUMP_START_TIME=0.2f;	//ジャンプ開始時間


    void Start()
    {
        playerRigid = this.GetComponent<Rigidbody>();
		animator = GetComponent <Animator> ();
		rayTf = GameObject.Find("Ray").transform;
		
		mineCollider = this.GetComponent<CapsuleCollider> ();
		sideCollider = side_collider.GetComponent<CapsuleCollider>();

    }
	void Jumpping()
	{
		playerRigid.AddForce(transform.up * jumpPower);
		animator.SetBool ("Jump", false);
	}
    void Update()
    {
		ray = new Ray(rayTf.position,rayTf.up*-1);
		// Text score_text = score_object.GetComponent<Text> ();
		// Text score_text1 = score_object1.GetComponent<Text> ();

		mineCollider.height = animator.GetFloat("ColliderHeight"); //　コライダの高さの変更
		sideCollider.height = animator.GetFloat("ColliderHeight")-0.3f;

		Debug.DrawLine (rayTf.position, rayTf.position + Vector3.down * RAY_DIS_GROUND, Color.blue);
		if (Physics.Raycast (ray, RAY_DIS_GROUND)) {  //　地面に接地しているか判定
			// score_text.text = "地面にいる";
			animator.SetBool ("Fall", false);
		    animator.SetBool ("Landing", false);

			if (Input.GetKeyDown(KeyCode.Space) && animator.GetCurrentAnimatorStateInfo(0).IsName("BlendTree")&&!animator.GetBool("Down")&&!animator.GetBool("Jump")){
				animator.SetBool ("Jump", true);
				Invoke("Jumpping",JUMP_START_TIME);
        	}
		} else if (!animator.GetBool ("Fall")) {  //Fallへの移行判定
			// dis = 0f;
			// Debug.DrawLine (ray.position, ray.position + Vector3.down * 1.0f, Color.red);
			if (!Physics.Raycast (ray,RAY_DIS_FALLING)) {
				animator.SetBool ("Fall", true);
			}
		} else if (animator.GetBool ("Fall")) {　//Landingの移行判定
			// score_text.text = "落下中";
			// score_text1.text = "最大高度は"+dis.ToString();

			// if (Physics.SphereCast(new Ray (ray.position, Vector3.down), 0.5f, out hit, 30f)) if(dis<hit.distance)  dis=hit.distance; //ここあとで綺麗にかく。

			// Debug.DrawLine (ray.position, ray.position + Vector3.down * 1.5f, Color.green);
			if (Physics.Raycast (ray, out hit, RAY_DIS_LANDING)) {
				animator.SetBool ("Landing", true);
				// score_text.text = "着地";
			}
		}
    }
}
