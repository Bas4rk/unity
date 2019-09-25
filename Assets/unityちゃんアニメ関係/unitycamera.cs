using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unitycamera : MonoBehaviour
{


    //public GameObject unitychan;
    public Vector3 unitychan;
    public Transform fulcrum;
    float X_Rotation;
    float Y_Rotation;
    const float Camsp=10f;

    public GameObject score_object1;

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        fulcrum = GameObject.Find("fulcrum").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //unitychan = GameObject.Find("unitychan_dynamic").transform.position;
        fulcrum.position = player.transform.position;//unitychan;

        if (Input.GetMouseButton(2)) {
            X_Rotation = Input.GetAxis("Mouse X");
            Y_Rotation = Input.GetAxis("Mouse Y");

            Text score_text1 = score_object1.GetComponent<Text> ();
            score_text1.text = "CameraAng: "+this.transform.localEulerAngles.y.ToString();
        }
        // X_Rotation = Input.GetAxis("Mouse X");
        // Y_Rotation = Input.GetAxis("Mouse Y");
        // fulcrum.Rotate(Y_Rotation, -X_Rotation, 1);
        //fulcrum.Rotate(Y_Rotation, 0, 0);

        Vector3 localAngle = fulcrum.localEulerAngles;

        localAngle.x -= Y_Rotation*Camsp;
        localAngle.y += X_Rotation*Camsp;
        localAngle.z = 0;
        fulcrum.localEulerAngles = localAngle;
    }
}
