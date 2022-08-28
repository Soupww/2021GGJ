using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafocus : MonoBehaviour
{
    public GameObject obj;//观察对象集合
    //public GameObject targetob;
    private int num=0;
  
  //  public Transform target;
    public float distance = 3.0f;//摄像机正对物体的距离
    public float height = 1.0f;//摄像机正对物体的高度
    public float damping = 0.1f;//摄像机位移速度
    private bool smoothRotation = true;//是否平滑转动角度
    public float rotationDamping = 10.0f;//摄像机角度转动的速度
    public float x_=0f;//摄像机距离物体x轴的距离
    private Vector3 targetLookAtOffset;//

    public float bumperDistanceCheck = 2.5f;
    public float bumperCameraHeight = 1.0f;
    private Vector3 bumperRayOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookatobj(obj.transform);
    }

    public void lookatobj(Transform target){
        //Vector3 wantedposition = target.position;
        //Vector3 wantedposition = target.transform.TransformPoint(target.transform.localPosition);
        Vector3 wantedposition = target.TransformPoint(x_, height, -distance);
        //RaycastHit hit;
        transform.position = Vector3.Lerp(transform.position, wantedposition, Time.deltaTime * damping);
      
        Vector3 lookposition = target.position;
        Quaternion wantedRotation = Quaternion.LookRotation(lookposition - transform.position, target.up);
        if (smoothRotation)
        {
            //平滑转动摄像机
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else transform.rotation = wantedRotation;
    }
}
