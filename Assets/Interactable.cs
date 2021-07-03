using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected PlayerManager playerManager;

    abstract public void Interact();

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Use"))
            {
                Interact();
            }
        }
    }
}
