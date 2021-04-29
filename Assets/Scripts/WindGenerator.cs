using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGenerator : MonoBehaviour
{

    public float windForce = 5;
    public float forceJumpReduction;
    public ForceMode forceMode = ForceMode.Acceleration;
    private Rigidbody rBody;
    private bool isWinded;

    // Start is called before the first frame update
    void Start()
    {
        rBody = null;
        isWinded = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
            rBody = col.GetComponent<Rigidbody>();
        isWinded = true;

        //DEBUG
        Debug.Log("Wind colpisce");
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (rBody != null && isWinded)
        {
            rBody.AddForce(this.transform.forward * windForce, ForceMode.Acceleration);

            //DEBUG
            Debug.Log("Wind continua a colpire");
        }
    }*/

    
    private void OnTriggerExit()
    {
        rBody = null;
        //isWinded = false;

        //DEBUG
        Debug.Log("Wind non colpisce");
    } 

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (rBody != null && isWinded) {
            if(! rBody.GetComponent<CC2D>().isJumping)
                rBody.AddForce(this.transform.forward * windForce, forceMode);
                //rBody.MovePosition(rBody.transform.position + this.transform.forward * windForce * Time.fixedDeltaTime);
            else
                rBody.AddForce(this.transform.forward * windForce / forceJumpReduction, forceMode);
        }
    }
}
