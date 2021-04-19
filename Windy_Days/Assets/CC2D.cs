using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC2D : MonoBehaviour
{
    private Rigidbody rBody;

    private float inputX;
    //private float inputY
    public float airDrag, groundDrag;
    public float maxVelocity, jumpVelocity;

    public GameObject groundCheck;
    public LayerMask groundMask;

    private bool isGrounded, isJumping;
    private 

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();

        rBody.freezeRotation = false;
        rBody.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        //inputY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;
        if (Input.GetButtonUp("Jump"))
            isJumping = false;
    }

    private void FixedUpdate()
    {
        //spostamento orizzontale

        Vector3 move = new Vector3(inputX,0,0);
        //rBody.AddForce(move,ForceMode.Acceleration);
        //rBody.MovePosition(move + this.transform.position);
        rBody.AddForce(move, ForceMode.VelocityChange);

        //jump
        if (isJumping)
        {
            Vector3 jumpMove = new Vector3(0, jumpVelocity, 0);
            rBody.AddForce(jumpMove, ForceMode.VelocityChange);
        }

        rBody.velocity = new Vector3(Mathf.Clamp(rBody.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rBody.velocity.y, Mathf.NegativeInfinity,jumpVelocity), rBody.velocity.z);

        //GROUND CHECK
        if (Physics.CheckSphere(groundCheck.transform.position, 0.1f, groundMask) && !isJumping)
        {
            isGrounded = true;
            rBody.drag = groundDrag;
        }
    }
}
