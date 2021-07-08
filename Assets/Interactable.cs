using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject player;
    protected PlayerManager playerManager;
    protected CC3D controller;

    protected bool hasInputUse;
    protected bool isColliding;

    abstract public void Interact();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CC3D>();
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
        controller.isRollDisabled = true;
        isColliding = true;
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
        controller.isRollDisabled = false;
        isColliding = false;
    }
}
