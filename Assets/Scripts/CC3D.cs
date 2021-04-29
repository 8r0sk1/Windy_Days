using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC3D : MonoBehaviour
{

    private Rigidbody rBody;

    //public float maxSpeed;
    public float movementSpeed = 5f, dashSpeed = 7.5f, rotationSpeed = 0.125f;
    private float InputX, InputZ;
    private bool toDash = false;
    private bool isDashing = false;

    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
            if (!isDashing && !toDash)
            {
                toDash = true;
                isDashing = true;

                //DEBUG
                Debug.Log("Inizio dash");
            }
    }

    private void FixedUpdate()
    {
        Vector3 move;
        if (!isDashing)
            move = new Vector3(InputX, 0f, InputZ);
        else
            move = Vector3.zero;

        //rotazione
        if (move.magnitude > 0f && !isDashing)
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(move.normalized),rotationSpeed);

        //controllo dash
        if (toDash)
        {
            //rBody.velocity = Vector3.zero;
            rBody.AddForce(this.transform.forward * dashSpeed, ForceMode.VelocityChange);
            toDash = false; //dash è già iniziato
        }
        else if (isDashing)
        {
            if (rBody.velocity.magnitude < 0.01f)
            {
                isDashing = false;
                //DEBUG
                Debug.Log("Fine dash");
            }
        }
        //controllo move
        else
        {
            float speedFactor = Mathf.Clamp(Mathf.Abs(move.x) + Mathf.Abs(move.z), 0f, 1f);
            rBody.MovePosition(this.transform.position + move.normalized * speedFactor * movementSpeed * Time.deltaTime);
        }

        //DEBUG
        //Debug.Log(rBody.velocity);
    }
}
