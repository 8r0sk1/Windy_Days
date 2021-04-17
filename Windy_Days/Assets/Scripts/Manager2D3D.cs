using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2D3D : MonoBehaviour
{
    public static Manager2D3D instance;

    public Camera camera;
    public GameObject player;

    private CharacterController2D characterController2D_script;
    private TPCController characterController3D_script;

    private PlayerMovement playerMovement2D_script;
    private ThirdPersonUserControl playerMovement3D_script;
    //private CharacterController controller;

    private Rigidbody rbody;

    private FollowPlayer2D followPlayer2D_script;
    private FollowPlayer3D followPlayer3D_script;

    private bool is2D;
    public bool dimChange;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //Get obj components
        characterController2D_script = player.GetComponent<CharacterController2D>();
        characterController3D_script = player.GetComponent<TPCController>();
        playerMovement2D_script = player.GetComponent<PlayerMovement>();
        playerMovement3D_script = player.GetComponent<ThirdPersonUserControl>();
        //controller = player.GetComponent<CharacterController>();

        rbody = player.GetComponent<Rigidbody>();

        followPlayer2D_script = camera.GetComponent<FollowPlayer2D>();
        followPlayer3D_script = camera.GetComponent<FollowPlayer3D>();

        ///////////////////////////////////
        //2D setup
        is2D = true;

        //Disabilito 3D features e abilito 2D
        //controller.enabled = false;
        characterController2D_script.enabled = true;
        playerMovement2D_script.enabled = true;

        //RigidBody setup

        //Blocco rotazione su X e Z, blocco posizione su Z
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

        //Camera setup
        followPlayer3D_script.enabled = false;
        followPlayer2D_script.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dimChange)
        {
            is2D = !is2D;

            if (is2D) //2D setup
            {
                //Disabilito 3D features e abilito 2D
                //controller.enabled = false;
                characterController2D_script.enabled = true;
                playerMovement2D_script.enabled = true;

                //RigidBody setup

                //Blocco rotazione su X e Z, blocco posizione su Z
                rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

                //Camera setup
                followPlayer3D_script.enabled = false;
                followPlayer2D_script.enabled = true;
            }
            else //3D setup
            {
                //Disabilito 2D features e abilito 3D
                characterController2D_script.enabled = false;
                characterController3D_script.enabled = true;
                playerMovement2D_script.enabled = false;
                playerMovement3D_script.enabled = true;
                //controller.enabled = true;

                //RigidBody setup
                rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

                //Camera setup
                followPlayer2D_script.enabled = false;
                followPlayer3D_script.enabled = true;
            }

            dimChange = false;
        }
        //////CONTROLLO TRANSIZIONE 2D-3D
    }
}
