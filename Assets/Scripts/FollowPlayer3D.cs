using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer3D : MonoBehaviour
{
    public GameObject player;

    public Vector3 relativePosition;

    public Vector3 offSet = new Vector3(5,5,5);
    public float slowFactor = 1;

    private bool toMakeTransition;
    private float t;

    private Vector3 initPos, finalPos;
    private Quaternion initRot, finalRot;

    // Start is called before the first frame update
    public void Start()
    {

    }

    //Quando viene abilitato lo script
    public void OnEnable()
    {
        toMakeTransition = true;

        initPos = this.transform.position;
        finalPos = player.transform.position + offSet + relativePosition;
        initRot = this.transform.rotation;
        finalRot = Quaternion.FromToRotation(this.transform.forward, (player.transform.position + offSet) - finalPos) * initRot;
    }

    // Update is called once per frame
    void Update()
    {
        if (toMakeTransition)
        {
            t += Time.deltaTime / 2;

            //handle rotation
            this.transform.rotation = Quaternion.Lerp(initRot, finalRot, t) ;

            //handle traslation
            this.transform.position = Vector3.Lerp(initPos, finalPos, t);

            toMakeTransition = false;
        }
        else
        {
            Vector3 move = (player.transform.position + relativePosition + offSet) - this.transform.position;
            this.transform.position = this.transform.position + move / (slowFactor * Time.deltaTime * 1000);

            this.transform.rotation = Quaternion.FromToRotation(this.transform.forward, new Vector3(0, (player.transform.position.y + offSet.y) - this.transform.position.y, (player.transform.position.z + offSet.z) - this.transform.position.z)) * this.transform.rotation;
        }
    }
}
