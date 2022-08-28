using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveC : MonoBehaviour
{
    public static GameObject main; 
    public GameObject indicator;
    public GameObject mesh;
    public GameObject rope;
    public float step = 0.1f;

    private void Start() {
        main = gameObject;
    }
    private void Update() {
        if(Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * step;
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.back * step;
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * step;
        }
        if(Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.forward * step;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mouseHit = hit.point;
        mouseHit.y = transform.position.y;
        indicator.transform.LookAt(mouseHit, Vector3.up);
        mesh.transform.LookAt(mouseHit, Vector3.up);


        if(Input.GetMouseButtonDown(0)) {
            FireRope();
        }
    }

    void FireRope() {
        GameObject newRope = Instantiate(rope, null);
        newRope.transform.position = indicator.transform.position;
        newRope.transform.rotation = indicator.transform.rotation;
    }
}
