using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC2D : MonoBehaviour
{
    private Rigidbody rBody;

    //private float t = 0f;
    private float oldInputX = 0f;
    private float inputX;
    //private float inputY
    //public float airDrag = 0, groundDrag = 0;
    public float moveSpeed = 10;
    public float maxVelocity;
    //public float jumpVelocity;
    public float maxJumpHeight, minJumpHeight;

    public GameObject groundCheck;
    public LayerMask groundMask;

    private Vector3 move;

    private float maxJumpTime;
    private float elapsedJumpTime;
    private float jumpVelocity;
    private bool isGrounded;
    public bool isJumping;
    private bool isOpposingDirection;
    private Vector3 windForce;
    private Vector3 totalWindForce;
    private float windForceJumpReduction;

    // Start is called before the first frame update
    void Start()
    {
        windForce = Vector3.zero;
        totalWindForce = Vector3.zero;
        move = Vector3.zero;

        isGrounded = false;

        rBody = this.GetComponent<Rigidbody>();

        rBody.freezeRotation = false;
        rBody.constraints = RigidbodyConstraints.FreezePositionZ;

        //calcolo massimo tempo di jump
        jumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * minJumpHeight);
        maxJumpTime = (maxJumpHeight - minJumpHeight)/jumpVelocity; //moto rettilineo uniforme finchè si tiene premuto spazio
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        //inputY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            elapsedJumpTime = 0;
            isJumping = true;
            //rBody.drag = airDrag;
            isGrounded = false;
            
            //DEBUG
            //Debug.Log("JUMP UP SUPERSTAR");
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        //Gestione rotazione
        
        
        if (inputX < 0f)
        { //quando cambia direzione
            //t = 0f;
            //initialRot = this.transform.rotation;
            //finalRot = Quaternion.LookRotation(Vector3.left, Vector3.up) * this.transform.rotation;
            this.transform.forward = Vector3.left;
        }
        if(inputX > 0f)
        {
            this.transform.forward = Vector3.right;
        }

        //if (t < 1f)
        //{
            //this.transform.rotation = Quaternion.Lerp(initialRot, finalRot, t);
            //t += Time.deltaTime / 500;
        //}
        

        oldInputX = inputX;

    }

    private void FixedUpdate()
    {
        //spostamento orizzontale
        move.x = inputX;

        //jump

        //controllo se sforo tempo salto
        if (elapsedJumpTime > maxJumpTime)
            isJumping = false;

        if (isJumping)
        {
            elapsedJumpTime += Time.fixedDeltaTime;
            Vector3 jumpMove = new Vector3(0, jumpVelocity, 0);
            rBody.AddForce(new Vector3(0f, -rBody.velocity.y, 0f), ForceMode.VelocityChange);
            rBody.AddForce(-Physics.gravity, ForceMode.Acceleration);
            rBody.AddForce(jumpMove, ForceMode.VelocityChange);
        }

        //GROUND CHECK
        else if (Physics.CheckSphere(groundCheck.transform.position, 0.1f, groundMask))
        {
            isGrounded = true;
            //rBody.drag = groundDrag;
        }
        else
            isGrounded = false;

        //Velocity CAP
        /*
        if (rBody.velocity.x > maxVelocity)
            rBody.velocity = new Vector3(maxVelocity, rBody.velocity.y, rBody.velocity.z);
        else if (rBody.velocity.x < -maxVelocity)
            rBody.velocity = new Vector3(-maxVelocity, rBody.velocity.y, rBody.velocity.z);
        */

        oldInputX = inputX;

        //calcolo forza vento applicata
        if (!isJumping)
            totalWindForce = windForce;
        else
            totalWindForce = windForce / windForceJumpReduction;

        if (move.x * rBody.velocity.x < 0f) 
            isOpposingDirection = true;
        else
            isOpposingDirection = false;

        //applico movimento orizzontale finale
        if ((rBody.velocity.x < maxVelocity) && (rBody.velocity.x > -maxVelocity) || isOpposingDirection){ //CAP di velocità
            Vector3 totalMove = move * moveSpeed + totalWindForce;
            rBody.AddForce(totalMove, ForceMode.Acceleration);
        }
    }

    public void AddWindForce(Vector3 force)
    {
        windForce += force;
    }
}
