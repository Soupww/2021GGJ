using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Events;
using UnityEngine;
public class killed : MonoBehaviour
{
    [SerializeField]

   // public Camerafocus cameraset;
    private bool flag = true;

    private float timespeed = 0.7f;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("huoche")&&flag)
        {
            flag = false;
            transform.GetChild(1).gameObject.SetActive(true);
            //transform.GetChild(2).gameObject.SetActive(true);
            Destroy(transform.GetChild(0).gameObject);
            GetComponent<NMTarget>().TriggerDeath();
            GetComponent<yunsuzou>().enabled = false;
            //cameraset.lookatobj(transform.GetChild(1));
            Time.timeScale = timespeed;
            Invoke("Timenormalize",2.0f);
            Invoke("DestroySelf", 4.0f);
        }
    }

    private void Timenormalize(){
        Debug.Log("Timenormalize");
        Time.timeScale = 1.0f;
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }


}

