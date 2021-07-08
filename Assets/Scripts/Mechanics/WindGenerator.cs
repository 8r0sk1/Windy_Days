using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    public bool withRubble = false;
    public float windForce = 5;
    private CC2D controller;
    private float elapsedTime;
    private float damageTime = 1;
    private int damage = 3;
    private bool toAddForwardForce, toAddBackwardForce;
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CC2D>();
        playerManager = controller.GetComponent<PlayerManager>();
        toAddBackwardForce = toAddForwardForce = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == controller.gameObject)
        {
            toAddForwardForce = true;
            elapsedTime = 0;
        }

        //DEBUG
        Debug.Log("Wind colpisce");
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject == controller.gameObject && withRubble)
        {
            if (elapsedTime > damageTime && !controller.isShielded)
            {
                playerManager.HPsum(-damage);
                elapsedTime = 0;
            }
            else 
                elapsedTime += Time.deltaTime;
        }
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
