using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotaSpeed;
    public Rigidbody rb;
    public Vector3 movement;
    Vector3 m_EulerAngleVelocity;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
         m_EulerAngleVelocity = new Vector3(0, 0, 0);
    }
    
    // Update is called once per frame
    void Update () {
        float vMove = Input.GetAxis("Vertical");
        if (vMove >= 0){
            movement = transform.up*vMove;
        }else{
            movement = transform.up*(vMove/2);
        }

        float hRota = Input.GetAxis("Horizontal");
        m_EulerAngleVelocity = new Vector3(0,0,hRota*rotaSpeed);

    }
    void FixedUpdate(){
        movePlayer(movement);
        rotatePlayer();
    }
    void movePlayer(Vector3 direction){
        rb.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }

    void rotatePlayer(){
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
