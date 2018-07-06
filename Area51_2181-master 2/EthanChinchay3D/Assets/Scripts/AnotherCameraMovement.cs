using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherCameraMovement : MonoBehaviour {
       
    public float moveSpeed;
    public Vector3 TargetDistance;
    public Transform Target;
    Vector3 TargetNode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        TargetNode = Target.position + (Target.right * TargetDistance.x) + (Target.up * TargetDistance.y) + (Target.forward * TargetDistance.z);
        transform.position = Vector3.MoveTowards(transform.position, TargetNode, moveSpeed * Time.deltaTime);
        transform.LookAt(Target.position + Vector3.up * 1.5f);
	}

	void OnDrawGizmos() {
        Gizmos.DrawSphere(TargetNode, 0.25f);
	}
}
