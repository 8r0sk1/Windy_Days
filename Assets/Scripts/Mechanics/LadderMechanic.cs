using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMechanic : MonoBehaviour
{
    CC2D player;
    public bool isVine = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CC2D>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.onLadder = player.isGrabbing = true;
            if (isVine)
            {
                //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                player.onVine = true;
                player.GetComponent<Animator>().SetBool("isShimming", true);
              

            }
            else
                player.GetComponent<Animator>().SetBool("isClimbing", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.onLadder = player.isGrabbing = false;
            if (isVine)
            {
                //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                player.onVine = false;
                player.GetComponent<Animator>().SetBool("isShimming", false);
              

            }
            else
                player.GetComponent<Animator>().SetBool("isClimbing", false);
        }
    }
}
