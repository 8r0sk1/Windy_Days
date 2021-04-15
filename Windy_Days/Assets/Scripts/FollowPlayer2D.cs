using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2D : MonoBehaviour
{
    public Transform player;

    public Vector3 relativePosition;

    public Vector3 offSet = Vector3.zero;
    public float slowFactor = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    //Quando viene abilitato lo script
    private void OnEnable()
    {
        this.transform.position = player.position + relativePosition;
        this.transform.rotation = Quaternion.FromToRotation(this.transform.forward, player.transform.position - this.transform.position) * this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z) + offSet - this.transform.position;
        this.transform.position = this.transform.position + move / (slowFactor * Time.deltaTime * 1000);
    }
}
