using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGenerator : MonoBehaviour
{

    public float windForce = 5;
    private CC2D controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CC2D>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
            controller.AddWindForce(windForce * this.transform.forward);

        //DEBUG
        Debug.Log("Wind colpisce");
    }
    
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            controller.AddWindForce(-windForce * this.transform.forward);

        //DEBUG
        Debug.Log("Wind non colpisce");
    } 
}
