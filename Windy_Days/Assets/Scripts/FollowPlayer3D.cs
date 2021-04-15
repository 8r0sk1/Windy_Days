using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer3D : MonoBehaviour
{
    public Transform player;

    public Vector3 relativePosition;

    public Vector3 offSet = new Vector3(5,5,5);
    public float slowFactor = 1;


    // Start is called before the first frame update
    public void Start()
    {

    }

    //Quando viene abilitato lo script
    public void OnEnable()
    {
        this.transform.position = player.position + offSet + relativePosition;
        this.transform.rotation = Quaternion.FromToRotation(this.transform.forward, player.transform.position - this.transform.position) * this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = (player.transform.position + relativePosition) - this.transform.position;
        this.transform.position = this.transform.position + move / (slowFactor * Time.deltaTime * 1000);

        this.transform.rotation = Quaternion.FromToRotation(this.transform.forward, (player.transform.position + offSet) - this.transform.position) * this.transform.rotation;
    }
}
