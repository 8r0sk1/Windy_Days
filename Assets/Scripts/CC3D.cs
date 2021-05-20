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
    private Vector2 speedVector;
    private Animator anim;
    private float dashElapsedTime;
    public float dashTime;

    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();

        rBody.useGravity = true;
    }

    /*
    void OnEnable()
    {
        rBody.useGravity = true;
    } */

    public void DashEvent(int arg)
    {
        isDashing = (arg == 0) ? false : true;

        //DEBUG
        Debug.Log(isDashing);
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        speedVector = new Vector2(InputX, InputZ);
        if (speedVector.magnitude > 0.1) 
                anim.SetBool("isRunning", true);
        else 
                anim.SetBool("isRunning", false);
        anim.SetFloat("runSpeed", Mathf.Max(speedVector.x,speedVector.y));
        anim.SetFloat("dashSpeed", dashSpeed);

        if (Input.GetButtonDown("Jump") && !isDashing)
        {
            //dashElapsedTime = 0f;
            //toDash = true;

            isDashing = true;
            anim.SetTrigger("toDash");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack1");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("attack2");
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
        if (Mathf.Clamp(move.magnitude,0,1) > 0f && !isDashing)
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(move.normalized),rotationSpeed);

        /*
        //controllo dash
        if (toDash)
        {
            anim.SetTrigger("toDash");
            isDashing = true;
            //rBody.velocity = Vector3.zero;

            //rBody.AddForce(this.transform.forward * dashSpeed, ForceMode.VelocityChange);
            toDash = false; //dash è già iniziato
        }

        else if (isDashing)
        {
            /*
            if ((new Vector2(rBody.velocity.x, rBody.velocity.z)).magnitude < 0.01f)
            {
                isDashing = false;
                //DEBUG
                Debug.Log("Fine dash");
            }*/

            /*
            rBody.velocity = this.transform.forward * dashSpeed;

            if(dashElapsedTime > dashTime)
            {
                isDashing = false;
            }

            dashElapsedTime += Time.fixedDeltaTime; 
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
            {
                isDashing = false;
                //DEBUG
                Debug.Log("Fine dash");
            }
        } */
        
        //controllo move
        if(!isDashing)
        {
            float speedFactor = Mathf.Clamp(Mathf.Abs(move.x) + Mathf.Abs(move.z), 0f, 1f);
            rBody.MovePosition(this.transform.position + move.normalized * speedFactor * movementSpeed * Time.deltaTime);
        }

        //DEBUG
        //Debug.Log(rBody.velocity);
    }
}
