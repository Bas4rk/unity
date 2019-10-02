using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    const float TIME_OUT=3f;
    private float timeElapsed;
    public GameObject Bullet;
    Vector3 parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed>=TIME_OUT){
            GameObject obj = (GameObject)Resources.Load("Bullet");
            Instantiate(obj,transform.position,transform.rotation);
            timeElapsed=0.0f;
        }
    }
}
