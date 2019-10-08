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
	public Transform ray;
	public CapsuleCollider mineCollider;
	public GameObject side_collider;
	public CapsuleCollider sideCollider;  


	RaycastHit hit;	// Rayが衝突したコライダーの情報を得る
    public float jumpPower;
	public float dis = 0f; //最大落下距離


    void Start()
    {
        playerRigid = this.GetComponent<Rigidbody>();
		animator = GetComponent <Animator> ();
		ray = GameObject.Find("Ray").transform; 
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
		Text score_text = score_object.GetComponent<Text> ();
		Text score_text1 = score_object1.GetComponent<Text> ();

		mineCollider.height = animator.GetFloat("ColliderHeight"); //　コライダの高さの変更
		sideCollider.height = animator.GetFloat("ColliderHeight")-0.3f;

		Debug.DrawLine (ray.position, ray.position + Vector3.down * 0.5f, Color.blue);
		if (Physics.SphereCast (new Ray (ray.position, Vector3.down), 0.5f, 0.5f)) {  //　地面に接地しているか判定
			score_text.text = "地面にいる";
			animator.SetBool ("Fall", false);
		    animator.SetBool ("Landing", false);

			if (Input.GetKeyDown(KeyCode.Space) && animator.GetCurrentAnimatorStateInfo(0).IsName("BlendTree")&&!animator.GetBool("Down")){
				Invoke("Jumpping", 0.2f);
				animator.SetBool ("Jump", true);		
        	}
		} else if (!animator.GetBool ("Fall")) {  //Fallへの移行判定
			dis = 0f; 

			Debug.DrawLine (ray.position, ray.position + Vector3.down * 1.0f, Color.red);
			if (!Physics.SphereCast (new Ray (ray.position, Vector3.down), 0.5f, 1.0f)) {
				animator.SetBool ("Fall", true);
			}
		} else if (animator.GetBool ("Fall")) {　//Landingの移行判定
			score_text.text = "落下中";
			score_text1.text = "最大高度は"+dis.ToString();

			if (Physics.SphereCast(new Ray (ray.position, Vector3.down), 0.5f, out hit, 30f)) if(dis<hit.distance)  dis=hit.distance; //ここあとで綺麗にかく。

			Debug.DrawLine (ray.position, ray.position + Vector3.down * 1.5f, Color.green);
			if (Physics.Linecast (ray.position, ray.position + Vector3.down * 1.5f) && dis >3.0f) { //disの値で落下の反動つかるか判定してる。きれいにかく。
				animator.SetBool ("Landing", true);
				score_text.text = "着地";
			}
		}
    }
}
