using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AliveEntity
{
    public int saved_hp;

    public GameObject checkPoint;
    private CC2D controller2d;
    private CC3D controller3d;

    public void Respawn()
    {
        rBody.position = checkPoint.transform.position;
        rBody.rotation = checkPoint.transform.rotation;

        hp = saved_hp;

        controller2d.Reset();
    }

    void Start()
    {
        controller2d = this.GetComponent<CC2D>();
        rBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            //DEBUG
            Debug.Log("HAI PERSO STRONZO");

            this.Respawn();
        }
    }
    public void SaveHP()
    {
        saved_hp = hp;
    }
}
