using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShordGetScript : MonoBehaviour
{
// Start is called before the first frame update
const float TARAGET_SEARCH=2f; //索敵範囲
public GameObject TargetObject; ///目標位置
GameObject o;
void Start()
{
    o = GameObject.Find("Character1_LeftHand");
}
// Update is called once per frame
void Update(){
float dis = Vector3.Distance(this.transform.position,TargetObject.transform.position);
if(dis<TARAGET_SEARCH){
GameObject obj = (GameObject)Resources.Load("shord");
Instantiate(obj,o.transform.position,o.transform.rotation);
}
}
}
