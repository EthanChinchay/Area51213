using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform lookTarget;
    public float targetHeight;
    public Vector3 TargetPoint;
    private Vector3 localPoint;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void LateUpdate()
    {
        localPoint = lookTarget.position + (lookTarget.right * TargetPoint.x) + (lookTarget.up * TargetPoint.y) + (lookTarget.forward * TargetPoint.z);
        transform.position = Vector3.MoveTowards(transform.position, lookTarget.position + TargetPoint, 5f * Time.deltaTime);
        transform.LookAt(lookTarget);

        /*transform.LookAt(lookTarget);
        float difference = Mathf.Abs (transform.position.y - lookTarget.position.y);
        if(difference != targetHeight){
            Vector3 temp = transform.position;
            temp.y = Mathf.MoveTowards(temp.y, lookTarget.position.y + targetHeight, 5f * Time.deltaTime);
            transform.position = temp;
        }   
        if (transform.position.x != lookTarget.position.y) {
            Vector3 temp = transform.position;
            temp.x = Mathf.MoveTowards(temp.x, lookTarget.position.x, 5f * Time.deltaTime);
                                    
        }*/             
    }
	private void OnDrawGizmos()
	{
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(localPoint, 0.25f);
	}
}

