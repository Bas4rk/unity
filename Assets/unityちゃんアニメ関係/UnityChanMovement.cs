using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanMovement : MonoBehaviour
{
    private Animator animator;
    public GameObject fulcrum;  //カメラ角度のオブジェクト

    Vector3 localAngle;

    const float MaxWalkSpeed=2f;//最大歩き速度
    const float MaxRunSpeed=10f;//最大走り速度

    const float SpeedRate=0.1f; //歩き速度
    const float RtRate=5f;      //振り向き速度

    const float WekFall=2f;     //落下高所判定:低所
    const float medFall=4f;     //落下高所判定:中所
    const float StrFall=6f;     //落下高所判定:高所

    float speed = 0f;           //現在速度
    float reaction = 0f;        //落下の反動 着地時の速度制御
    float fallDis = 0f;        //Jumpスクリプトのdis。落下した最大の高さ


    //インタフェース オブジェクト
    public GameObject score_object;
    // public GameObject score_object1;
    public GameObject score_object2;
    public GameObject score_object3;


    //正反対のキー入力判定用
    public char wsKey;
    public char adKey;
    

    //初期化
    void Start () {
        animator = GetComponent<Animator>();         //Animator
        fulcrum = GameObject.Find("fulcrum");        //カメラ角度のオブジェクト
        wsKey='0';
        adKey='0';
    }

    //移動メソッド
    void move(int rt){
        float uniAngY = this.transform.localEulerAngles.y;              //UnityちゃんのY軸角度
        float goToAngY = (fulcrum.transform.localEulerAngles.y+rt)%360; //Unityちゃんが最終的に向きたいY軸角度


        moveRt(uniAngY,goToAngY);//向き変更
        
        if(speed < MaxWalkSpeed ){
            speed+=SpeedRate;  
        }
        if (Input.GetKey("left shift")) { 
            if(speed < MaxRunSpeed){  
                speed+=SpeedRate;
            }   
        }else if(speed > MaxWalkSpeed ){
            speed-=SpeedRate;
        }
    }

    //Unityちゃん向き変更
    void moveRt(float uniAng,float goAng){
        float nextAng;  //振り向く次の角度　現在角度+振り向き速度
        
        // Debug.Log("localAngle"+(localAngle.y+RtRate));

        // デバッグ用　テキストの表示を入れ替える
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "uniAng: "+uniAng.ToString();
        Text score_text2 = score_object2.GetComponent<Text> ();
        score_text2.text = "goAng: "+goAng.ToString();
        Text score_text3 = score_object3.GetComponent<Text> ();

        //右回りと左回りのどちらが早いのかを計算
        if(uniAng<goAng){
            if(goAng-uniAng < 180){
                rightTurn(uniAng,goAng);
            }else{
                leftTurn(uniAng,goAng);
            }
        }else{
            if(uniAng-goAng > 180){
                rightTurn(uniAng,goAng);
            }else{
                leftTurn(uniAng,goAng);
            }
        }
        this.transform.localEulerAngles=localAngle;//変更した値を代入
    }

//右回り
void rightTurn(float uniAng,float goAng){
    float nextAng;

    nextAng = localAngle.y+RtRate;
    if(nextAng > 360){
        nextAng -=360;
    }
    if(goAng+RtRate>=360){
        localAngle.y = goAng<=nextAng || nextAng<=goAng-360+RtRate ? goAng : nextAng;
    }else{
        localAngle.y = goAng<=nextAng && nextAng<=goAng+RtRate ? goAng : nextAng;
    }
}

//左回り
void leftTurn(float uniAng,float goAng){
    float nextAng;

    nextAng = localAngle.y-RtRate;
    if(nextAng < 0){
        nextAng +=360;
    }
    if(goAng-RtRate<=0){
        localAngle.y = goAng+360-RtRate<=nextAng||nextAng<=goAng ? goAng : nextAng;
    }else{
        localAngle.y = goAng>=nextAng&&nextAng>=goAng-RtRate ?  goAng : nextAng;
    }
}

//移動キー入力判定　反対のキーが入力されていた場合、先に押されていたキーを優先する
int getOrie(){

    //有効なキーを判定
    if(wsKey=='0'){
        if(Input.GetKey(KeyCode.W)) {
            wsKey='W';
        }else if(Input.GetKey(KeyCode.S)) {
            wsKey='S';
        }
    }else if(!(Input.GetKey(KeyCode.W))&&wsKey=='W'||!(Input.GetKey(KeyCode.S))&&wsKey=='S'){
        wsKey='0';
    }
    if(adKey=='0'){
        if(Input.GetKey(KeyCode.A)) {
            adKey='A';
        }else if(Input.GetKey(KeyCode.D)) {
            adKey='D';
        }
    }else if(!(Input.GetKey(KeyCode.A))&&adKey=='A'||!(Input.GetKey(KeyCode.D))&&adKey=='D'){
        adKey='0';
    }


    //方角の選択
    if(wsKey=='W'){
        switch(adKey){
            case 'A': return 315;
            case 'D': return 45;
            case '0': return 0;
        }
        
    }else if(wsKey=='S'){
        switch(adKey){
            case 'A': return 225;
            case 'D': return 135;
            case '0': return 180;
        }
    }else{
        switch(adKey){
            case 'A': return 270;
            case 'D': return 90;
        }
    }
    return -1;
}

    // アップデートごとに読み込む
    void Update () {
        animator.SetFloat ("Speed", speed);	                    //Animatorへ現在の状態をセット
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Landing")){
            fallDis = this.GetComponent<Jump> ().dis;
            if(fallDis > StrFall){//着地時横移動速度制御
                reaction = 0.7f;
            }else{
                reaction = 0.8f;
            }
            speed*=reaction;
        }
        transform.position += transform.forward * speed/100;    //前へ移動
        

        int orie = getOrie();   //進む方角の選択
        if(orie>=0){
            move(orie);         //進行方向へ進む
        }else if(speed > 0.05){ //進行方向未入力
            speed-=SpeedRate;   //止まる
        }
    }
}