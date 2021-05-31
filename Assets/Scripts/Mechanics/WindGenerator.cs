using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGenerator : MonoBehaviour
{

    public float windForce = 5;
    private CC2D controller;
    private bool toAddForwardForce, toAddBackwardForce;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CC2D>();
        toAddBackwardForce = toAddForwardForce = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == controller.gameObject)
            toAddForwardForce = true;

        //DEBUG
        Debug.Log("Wind colpisce");
    }
    
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == controller.gameObject)
            toAddBackwardForce = true;

        //DEBUG
        Debug.Log("Wind non colpisce");
    }

    private void FixedUpdate()
    {
        if (toAddForwardForce)
        {
            controller.AddWindForce(windForce * this.transform.forward);
            toAddForwardForce = false;
        }
        if (toAddBackwardForce)
        {
            controller.AddWindForce(-windForce * this.transform.forward);
            toAddBackwardForce = false;
        }
    }
}
