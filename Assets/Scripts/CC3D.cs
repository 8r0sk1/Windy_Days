using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC3D : MonoBehaviour
{

    private Rigidbody rBody;

    //public float maxSpeed;
    public float movementSpeed = 5f, dashSpeed = 7.5f;
    private float InputX, InputZ;
    private bool toDash = false;
    private bool isDashing;

    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
            if(!isDashing)
                toDash = true;
        Debug.Log("DASH");
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(InputX, 0f, InputZ);

        //rotazione
        if(move.magnitude > 0f && !isDashing)
            this.transform.forward = move.normalized;

        //controllo dash
        if (toDash)
        {
            rBody.velocity = Vector3.zero;
            rBody.AddForce(this.transform.forward * dashSpeed, ForceMode.VelocityChange);
            isDashing = true;
            toDash = false; //dash è già iniziato
        }

        if (isDashing)
        {
            if (rBody.velocity.magnitude <= 0.1f)
                isDashing = false;
        }
        else 
            rBody.MovePosition(this.transform.position + move * movementSpeed * Time.deltaTime);
    }
}
