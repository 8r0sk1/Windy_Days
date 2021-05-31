using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMechanic : MonoBehaviour
{
    CC2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CC2D>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            player.onLadder = player.isGrabbing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            player.onLadder = player.isGrabbing = false;
    }
}
