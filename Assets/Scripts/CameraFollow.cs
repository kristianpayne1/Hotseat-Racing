using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraFollow : MonoBehaviour {
 
    public Transform cameraTarget;
    public float sSpeed = 10.0f;
    public Transform lookTarget;
    public Rigidbody lookTargetRigidbody;
    
    private Vector3 offset;
    private Vector3 lastPos;
    
    public bool stopFollowing;

    void Start() {
        stopFollowing = false;
        offset = cameraTarget.position - transform.position;
    }
 
    void FixedUpdate() {
        if (!stopFollowing) {
            Vector3 cPos = Vector3.Normalize(lookTargetRigidbody.velocity) * offset.z;
            cPos.y = 0f;
            Vector3 dPos = cameraTarget.position - cPos - cameraTarget.up * offset.y;
            transform.position = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        }
        transform.LookAt(lookTarget.position);
    }
     
}