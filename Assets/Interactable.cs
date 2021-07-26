using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject player;
    protected PlayerManager playerManager;
    protected CC3D controller3D;
    protected CC2D controller2D;

    protected bool hasInputUse;
    protected bool isColliding;

    abstract public void Interact();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller3D = player.GetComponent<CC3D>();
        controller2D = player.GetComponent<CC2D>();
        playerManager = player.GetComponent<PlayerManager>();
        hasInputUse = false;
        isColliding = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isColliding)
            hasInputUse = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //controller3D.isRollDisabled = true;
            //controller2D.isJumpDisabled = true;
            isColliding = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasInputUse)
            {
                hasInputUse = false;
                Interact();
            }
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        //controller3D.isRollDisabled = false;
        //controller2D.isJumpDisabled = false;
        isColliding = false;
    }
}
