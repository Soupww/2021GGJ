using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    private float speed = 2f;
    private bool hitTrain = false;
    private LineRenderer lineRenderer;
    private Rigidbody hitBody;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 2f;
        lineRenderer.endWidth = 2f;
        Invoke("DestroySelf", 3.0f);
    }
    private void FixedUpdate() {
        Vector3 targetDir = transform.forward;
        targetDir.y = 0;
        if(!hitTrain) {
            transform.position += targetDir * speed;
        } else {
            //hitBody.AddForce(hitBody.transform.up.normalized * 5000, ForceMode.Impulse);
            hitBody.AddForce((transform.position - hitBody.transform.position).normalized * 10000, ForceMode.Impulse);
            transform.position = Vector3.Lerp(transform.position, PlayerMoveC.main.transform.position, 0.04f);
            if((transform.position - PlayerMoveC.main.transform.position).magnitude < speed * 4) {
                CancelInvoke();
                DestroySelf();
            }
        }
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, PlayerMoveC.main.transform.position);
    }

    void DestroySelf() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "huoche") {
            Debug.LogWarning("I Hit: " + other.gameObject.name.ToString());
            hitBody = other.rigidbody;
            other.rigidbody.AddForce(other.transform.up * 5000, ForceMode.Impulse);
            //other.rigidbody.AddForce(-(transform.position - other.transform.position) * 10000, ForceMode.Impulse);
            hitTrain = true;
        }
    }


}
