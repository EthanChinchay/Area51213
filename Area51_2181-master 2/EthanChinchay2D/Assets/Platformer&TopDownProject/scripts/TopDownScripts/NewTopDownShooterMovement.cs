using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTopDownShooterMovement : MonoBehaviour{

    public float speed = 1;
    public Rigidbody2D rigidbody2DD;
    bool ShouldMove = true;
    // Use this for initialization
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.position;
        if (Input.GetKey(KeyCode.A) && ShouldMove){
            movement += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && ShouldMove){
            movement += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && ShouldMove){
            movement += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && ShouldMove){
            movement += Vector3.right * speed * Time.deltaTime;
        }
        rigidbody2DD.MovePosition(movement);
    }
    /*void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Wall")
        {
            Debug.Log("Run you fools");
            ShouldMove = false;
        }
    }*/
}