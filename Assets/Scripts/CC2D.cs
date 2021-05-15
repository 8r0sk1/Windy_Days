﻿using System.Collections;
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
    public float bottleJumpHeight;

    public GameObject groundCheck;
    public LayerMask groundMask;

    private Vector3 move;

    private float maxJumpTime;
    private float elapsedJumpTime;
    private float jumpVelocity, bottleJumpVelocity;
    private bool bottlingEnabled;
    private bool isGrounded;
    public bool isJumping;
    private bool isBottling;
    private bool isOpposingDirection;
    private Vector3 windForce;
    private Vector3 totalWindForce;
    public float windForceJumpReduction;

    private Vector3 yVel;
    private Vector3 totalMove;
    private Vector3 playerVelocity;

    public AnimationClip windIdleClip, windWalkClip, idleClip, runningClip;
    private AnimatorOverrideController windAnimatorController;

    //animator
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        windForce = Vector3.zero;
        totalWindForce = Vector3.zero;
        move = Vector3.zero;
        yVel = Vector3.zero;

        isGrounded = false;
        bottlingEnabled = true;

        rBody = this.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();

        windAnimatorController = new AnimatorOverrideController(anim.runtimeAnimatorController);

        rBody.freezeRotation = false;
        rBody.constraints = RigidbodyConstraints.FreezePositionZ;

        //calcolo massimo tempo di jump
        jumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * minJumpHeight);
        bottleJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * bottleJumpHeight);
        maxJumpTime = (maxJumpHeight - minJumpHeight)/jumpVelocity; //moto rettilineo uniforme finchè si tiene premuto spazio

        rBody.useGravity = false; ////////////////
    }

    /*
    void OnEnable()
    {
        rBody.useGravity = false;
    } */

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxis("Horizontal");

        //update animation condition
        if (Mathf.Abs(inputX) > 0.1) anim.SetBool("isRunning", true);
        else anim.SetBool("isRunning", false);
        anim.SetFloat("runSpeed", Mathf.Abs(inputX));

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
        if (Input.GetButtonUp("Crouch"))
        {
            if (bottlingEnabled)
            {
                isBottling = true;
                bottlingEnabled = false;
            }
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
        //reset velocità a 0
        rBody.velocity = Vector3.zero;

        //controllo gravità
        if (!isGrounded) yVel += Physics.gravity * Time.fixedDeltaTime;
        else yVel = new Vector3(0, 0, 0);

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
            /*
            rBody.AddForce(new Vector3(0f, -rBody.velocity.y, 0f), ForceMode.VelocityChange);
            rBody.AddForce(-Physics.gravity, ForceMode.Acceleration);
            rBody.AddForce(jumpMove, ForceMode.VelocityChange);
            */
            yVel = jumpMove;
        }

        if (isBottling)
        {
            isGrounded = false;
            isJumping = false;
            /*
            rBody.AddForce(new Vector3(0f, -rBody.velocity.y, 0f), ForceMode.VelocityChange);
            rBody.AddForce(new Vector3(0f, bottleJumpVelocity, 0f), ForceMode.VelocityChange);
            */
            yVel = new Vector3(0, bottleJumpVelocity, 0);
            isBottling = false;
        }

        //GROUND CHECK
        else if (Physics.CheckSphere(groundCheck.transform.position, 0.1f, groundMask))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
            bottlingEnabled = true;
            //rBody.drag = groundDrag;
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }

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

        /*
        if (move.x * rBody.velocity.x < 0f) 
            isOpposingDirection = true;
        else
            isOpposingDirection = false;
        */
        //applico movimento orizzontale finale
        //if ((rBody.velocity.x < maxVelocity) && (rBody.velocity.x > -maxVelocity) || isOpposingDirection){ //CAP di velocità
            //Vector3 totalMove = move * moveSpeed + totalWindForce;
            //rBody.AddForce(totalMove, ForceMode.Acceleration);

            totalMove = move * moveSpeed / 200 + (totalWindForce/4) * Time.fixedDeltaTime + yVel * Time.fixedDeltaTime;
            rBody.MovePosition(rBody.position + totalMove);
            playerVelocity = rBody.velocity;
        //}
    }

    public void AddWindForce(Vector3 force)
    {
        windForce += force;

        int[] layerIndex = new int[2];
        layerIndex[0] = anim.GetLayerIndex("Normal");
        layerIndex[1] = anim.GetLayerIndex("Winded");

        if (windForce.magnitude > 0.1f)
        {
            anim.SetLayerWeight(layerIndex[0], 0);
            anim.SetLayerWeight(layerIndex[1], 1);
        }

        else
        {
            anim.SetLayerWeight(layerIndex[0], 1);
            anim.SetLayerWeight(layerIndex[1], 0);
        }

        /*///////////////////TO FIX///////////////////////////////////
        //wind animation change
        if (totalWindForce.magnitude != 0)
        {
            windAnimatorController["Idle"] = windIdleClip;
            windAnimatorController["Running"] = windWalkClip;
        }
        else
        {
            windAnimatorController["Idle"] = idleClip;
            windAnimatorController["Running"] = runningClip;
        }

        anim.runtimeAnimatorController = windAnimatorController;

        ////////////////////////////////////////////////////////////////*/
    }
}
