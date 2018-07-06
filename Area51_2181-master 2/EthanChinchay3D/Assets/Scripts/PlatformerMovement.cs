using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{

    public float movementSpeed;
    public float angularlSpeed;
    Vector3 movement;
    public Rigidbody rigidbody3D;
    public float impulseValue;
    Quaternion rotation;

    public PlayerScript playerScript;
    bool grounded;

    List<Collider> groundCollection;


    public Animator animatorController;

    public SwitchControl currentSwich;

    // Use this for initialization
    void Start() {
        groundCollection = new List<Collider> ();
    }

    // Update is called once per frame
    void FixedUpdate() {
        movement = transform.position;
        rotation = rigidbody3D.rotation;
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        //animatorController.SetFloat ("ForwardSpeed"); NormalizeMovement(verticalDirection);

        if (Input.GetKey(KeyCode.I)) {
            rotation *= Quaternion.Euler(Vector3.up * -angularlSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.O)) {
            rotation *= Quaternion.Euler(Vector3.up * angularlSpeed * Time.fixedDeltaTime);
        }

        if (horizontalDirection != 0) {
            movement += transform.right * movementSpeed * horizontalDirection * Time.fixedDeltaTime;
        }
        if (verticalDirection != 0) {
            movement += transform.forward * movementSpeed * verticalDirection * Time.fixedDeltaTime;
        }

        rigidbody3D.MovePosition(movement);
        rigidbody3D.MoveRotation(rotation);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rigidbody3D.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            playerScript.ModifyHp(-10f);
        } else if (Input.GetKeyDown(KeyCode.J) && !playerScript.currentPower.isWaiting) {
            Attack ();
        }
    }
    void Attack(){
        playerScript.currentPower.AttackRoundAbout ();
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Power")){
            PowerBehaviour targetPower = other.GetComponent<PowerBehaviour>();
            if(playerScript.currentPower != null || playerScript.currentPower != targetPower){
                playerScript.currentPower = targetPower;
                targetPower.AssignActivePlayer (this);
            }
        }
    }
    /*private void OnTriggerExit(Collider other){
        if (other.CompareTag("Switch")){
            currentSwich = null;

        }
    }*/
    float NormalizeMovement (float targetMovement){
        
        return (targetMovement + 1f)/2f ;
    }

    void OnCollisionStay (Collision collision){
        if (!groundCollection.Contains (collision.collider)){
            foreach (ContactPoint contact in collision.contacts){
                Debug.DrawRay(contact.point, contact.normal * 5f, Color.red, 1f);
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.75f){
                    Debug.Log("Should be grounded");
                    grounded = true;
                    animatorController.SetBool("isGrounded", grounded);
                    groundCollection.Add (collision.collider);
                    break;
                }
            }
        }
    }
    void OnCollisionExit (Collision collision){
        if(groundCollection.Contains(collision.collider)){
            groundCollection.Remove(collision.collider);
        }
        if (groundCollection.Count <= 0) {
            grounded = false;
            animatorController.SetBool("isGrounded", grounded);
        }
    }
}
