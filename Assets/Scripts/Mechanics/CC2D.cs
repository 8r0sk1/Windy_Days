using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC2D : MonoBehaviour
{
    private Rigidbody rBody;

    private float oldInputX = 0f;
    private float inputX, inputY;
    public float moveSpeed = 10;
    public float maxVelocity;
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
    public bool isJumping, onLadder, isGrabbing;
    private bool isBottling;
    private bool isOpposingDirection;
    private Vector3 windForce;
    private Vector3 totalWindForce;
    public float windForceJumpReduction;

    private Vector3 yVel;
    private Vector3 totalMove;
    //private Vector3 playerVelocity;

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

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        //update animation condition
        if (Mathf.Abs(inputX) > 0.1) anim.SetBool("isRunning", true);
        else anim.SetBool("isRunning", false);
        anim.SetFloat("runSpeed", Mathf.Abs(inputX));

        //inputY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && (isGrounded || onLadder))
        {
            elapsedJumpTime = 0;
            isJumping = true;
            isGrounded = onLadder = isGrabbing = false;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            if (isGrabbing)
                isGrabbing = false;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            if (bottlingEnabled)
            {
                isBottling = true;
                bottlingEnabled = false;
            }
        }

        //Gestione rotazione
        
        
        if (inputX < 0f)
        {
            this.transform.forward = Vector3.left;
        }
        if(inputX > 0f)
        {
            this.transform.forward = Vector3.right;
        }  

        oldInputX = inputX;

    }

    private void FixedUpdate()
    {
        //reset velocità a 0
        rBody.velocity = Vector3.zero;

        //controllo gravità
        if (!isGrounded && !isGrabbing) yVel += Physics.gravity * Time.fixedDeltaTime;
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
            yVel = jumpMove;
        }

        if (isBottling)
        {
            isGrounded = false;
            isJumping = false;
            yVel = new Vector3(0, bottleJumpVelocity, 0);
            isBottling = false;
        }

        //GROUND CHECK
        else if (Physics.CheckSphere(groundCheck.transform.position, 0.1f, groundMask))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
            bottlingEnabled = true;
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }

        oldInputX = inputX;

        //calcolo forza vento applicata
        if (!isJumping)
            totalWindForce = windForce;
        else
            totalWindForce = windForce / windForceJumpReduction;

        if (onLadder && isGrabbing)
        {
            totalMove = (move + new Vector3(0,inputY,0)) * moveSpeed / 400;
            rBody.MovePosition(rBody.position + totalMove);
            //playerVelocity = rBody.velocity;
        }

        else {
            totalMove = move * moveSpeed / 200 + (totalWindForce / 4) * Time.fixedDeltaTime + yVel * Time.fixedDeltaTime;
            rBody.MovePosition(rBody.position + totalMove);
            //playerVelocity = rBody.velocity;
        }
    }

    public void AddWindForce(Vector3 force)
    {
        windForce += force;

        int[] layerIndex = new int[2];
        layerIndex[0] = anim.GetLayerIndex("LR_Normal");
        layerIndex[1] = anim.GetLayerIndex("LR_Winded");

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
    }

    public void Reset()
    {
        //operazioni automatiche quando esce da wind
        //windForce = Vector3.zero;
        //totalWindForce = Vector3.zero;
        move = Vector3.zero;
        yVel = Vector3.zero;

        isGrounded = false;
        bottlingEnabled = true;
    }
}
