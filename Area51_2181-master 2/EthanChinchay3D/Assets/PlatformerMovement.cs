using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    Vector3 movement;
    public Rigidbody rigidbody3D;
    public float impulseValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movement = transform.position;
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        if(horizontalDirection !=0){
            movement += Vector3.right * horizontalDirection * horizontalSpeed * Time.deltaTime;
        }
        if (verticalDirection != 0){
            movement += Vector3.forward * verticalDirection * verticalSpeed * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            rigidbody3D.AddForce(Vector3.up * impulseValue, ForceMode.Impulse);
        }
        rigidbody3D.MovePosition (movement);

	}
}
