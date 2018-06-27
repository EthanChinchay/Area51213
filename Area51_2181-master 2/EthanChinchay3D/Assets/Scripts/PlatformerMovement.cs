using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{

    public float horizontalSpeed;
    public float angularlSpeed;
    Vector3 movement;
    public Rigidbody rigidbody3D;
    public float impulseValue;
    Quaternion rotation;
    List<Collider> groundCollection;
    bool grounded;

    public Animator animatorController;

    public SwitchControl currentSwich;

    // Use this for initialization
    void Start()
    {
        groundCollection = new List<Collider> ();
    }

    // Update is called once per frame
    void Update()
    {
        movement = transform.position;
        rotation = rigidbody3D.rotation;
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.J))
        {
            rotation *= Quaternion.Euler(Vector3.up * angularlSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.K))
        {
            rotation *= Quaternion.Euler(Vector3.right * angularlSpeed * Time.fixedDeltaTime);
        }

        if (horizontalDirection != 0)
        {
            movement += transform.right * horizontalDirection * horizontalDirection * Time.fixedDeltaTime;
        }
        if (verticalDirection != 0)
        {
            movement += transform.forward * verticalDirection * verticalDirection * Time.fixedDeltaTime;
        }

        rigidbody3D.MovePosition(movement);
        rigidbody3D.MoveRotation(rotation);

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidbody3D.AddForce(Vector3.up * impulseValue, ForceMode.Impulse);
        }
        if (currentSwich != null && Input.GetKeyDown(KeyCode.E))
        {
            currentSwich.Active();
        }
    }
    //Raycast
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Switch")){
            currentSwich = other.GetComponent<SwitchControl>();

        }
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Switch")){
            currentSwich = null;

        }
    }
    void OnCollisionEnter(Collision collision){
        if (groundCollection.Contains(collision.collider)){
            foreach (ContactPoint contact in collision.contacts){
                Debug.DrawRay(contact.point, contact.normal * 5f, Color.red, 1f);
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.75f){
                    Debug.Log("Should be grounded");
                    grounded = true;
                    animatorController.SetBool("isGrounded", grounded);
                    groundCollection.Add(collision.collider);
                    break;
                }
            }
        }
    }
    void OnCollisionExit (Collision collision){
        if(groundCollection.Contains(collision.collider)){
            groundCollection.Remove(collision.collider);
        }
        if(groundCollection.Count <=0) { grounded = false; }
        animatorController.SetBool("isGrounded", grounded);
    }
}
