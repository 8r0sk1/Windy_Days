using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2D3D : MonoBehaviour
{
    public Camera camera;
    public GameObject player;

    private CharacterController2D characterController2D_script;
    private PlayerMovement playerMovement_script;
    private CharacterController controller;
    private Rigidbody rbody;

    private FollowPlayer2D followPlayer2D_script;
    private FollowPlayer3D followPlayer3D_script;

    public bool is2D;

    // Start is called before the first frame update
    void Start()
    {
        characterController2D_script = player.GetComponent<CharacterController2D>();
        playerMovement_script = player.GetComponent<PlayerMovement>();
        controller = player.GetComponent<CharacterController>();

        rbody = player.GetComponent<Rigidbody>();

        followPlayer2D_script = camera.GetComponent<FollowPlayer2D>();
        followPlayer3D_script = camera.GetComponent<FollowPlayer3D>();

        if (is2D) //2D setup
        {
            //Disabilito 3D features e abilito 2D
            //controller.enabled = false;
            characterController2D_script.enabled = true;
            playerMovement_script.enabled = true;

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
            playerMovement_script.enabled = false;
            //controller.enabled = true;

            //RigidBody setup
            rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            //Camera setup
            followPlayer2D_script.enabled = false;
            followPlayer3D_script.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //////CONTROLLO TRANSIZIONE 2D-3D
    }
}
