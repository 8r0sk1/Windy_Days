using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class Manager2D3D : MonoBehaviour
{
    public Transform[] entryPoints = new Transform[3];

    public static Manager2D3D instance;

    public string tag_3d = "3d_object";
    public string tag_2d = "2d_object";

    public Camera camera;
    public GameObject player;

    private CC2D characterController2D_script;
    private CC3D characterController3D_script;

    private Rigidbody rbody;

    private FollowPlayer2D followPlayer2D_script;
    private FollowPlayer3D followPlayer3D_script;

    private Animator anim;

    public GameObject gear3D;
    public GameObject gear2D;

    private int[] layerIndex = new int[3];

    private bool is2D;
    public bool dimChange;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //Position player
        player.transform.position = entryPoints[GameData.entryPoint].position;
        player.transform.rotation = entryPoints[GameData.entryPoint].rotation;

        //Get obj components

        rbody = player.GetComponent<Rigidbody>();
        anim = player.GetComponent<Animator>();

        layerIndex[0] = anim.GetLayerIndex("LR_Normal");
        layerIndex[1] = anim.GetLayerIndex("LR_Winded");
        layerIndex[2] = anim.GetLayerIndex("TD");

        characterController2D_script = player.GetComponent<CC2D>();
        characterController3D_script = player.GetComponent<CC3D>();

        followPlayer2D_script = camera.GetComponent<FollowPlayer2D>();
        followPlayer3D_script = camera.GetComponent<FollowPlayer3D>();

        ///////////////////////////////////
        //2D setup
        is2D = true;

        characterController2D_script.enabled = true;
        characterController3D_script.enabled = false;

        //RigidBody setup
        //Blocco rotazione su X e Z, blocco posizione su Z
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

        //Camera setup
        followPlayer3D_script.enabled = false;
        followPlayer2D_script.enabled = true;

        //Activate and deactivate 3d/2d objects
        foreach (Transform obj in player.GetComponentsInChildren<Transform>())
        {
            if (obj.CompareTag(tag_3d))
            {
                if (is2D) obj.gameObject.SetActive(false);
                else obj.gameObject.SetActive(true);
            }
            else if (obj.CompareTag(tag_2d))
            {
                if (is2D) obj.gameObject.SetActive(true);
                else obj.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dimChange)
        {
            is2D = !is2D;

            //Activate and deactivate 3d/2d objects
            foreach(Transform obj in player.GetComponentsInChildren<Transform>())
            {
                if (obj.CompareTag(tag_3d))
                {
                    if (is2D) obj.gameObject.SetActive(false);
                    else obj.gameObject.SetActive(true);
                }
                else if (obj.CompareTag(tag_2d))
                {
                    if (is2D) obj.gameObject.SetActive(true);
                    else obj.gameObject.SetActive(false);
                }
            }

            if (is2D) //2D setup
            {
                //Models setup
                gear3D.SetActive(false);
                gear2D.SetActive(true);

                //Anim controller switch
                anim.SetLayerWeight(layerIndex[0], 1);
                anim.SetLayerWeight(layerIndex[1], 0);
                anim.SetLayerWeight(layerIndex[2], 0);

                //Disabilito 3D features e abilito 2D
                characterController3D_script.enabled = false;
                characterController2D_script.enabled = true;

                //RigidBody setup

                //Blocco rotazione su X e Z, blocco posizione su Z
                rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

                //Camera setup
                followPlayer3D_script.enabled = false;
                followPlayer2D_script.enabled = true;
            }
            else //3D setup
            {
                //Models setup
                gear2D.SetActive(false);
                gear3D.SetActive(true);

                //Anim controller switch
                anim.SetLayerWeight(layerIndex[0], 0);
                anim.SetLayerWeight(layerIndex[1], 0);
                anim.SetLayerWeight(layerIndex[2], 1);

                //Disabilito 2D features e abilito 3D
                characterController2D_script.enabled = false;
                characterController3D_script.enabled = true;

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
