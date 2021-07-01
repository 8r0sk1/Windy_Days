using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AliveEntity
{
    public GameObject checkPoint;
    public GameObject fountainCheckPoint;
    private CC2D controller2d;
    private CC3D controller3d;
    private HealthBar healthBar;

    void Start()
    {
        hp = max_hp;
        healthBar = GameObject.FindObjectOfType<HealthBar>();
        controller3d = this.GetComponent<CC3D>();
        controller2d = this.GetComponent<CC2D>();
        rBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            //DEBUG
            Debug.Log("YOU DIED");
            this.FountainRespawn();
        }
    }

    override public void HPsum(int sum)
    {
        hp += sum;
        healthBar.SetHP(hp);
    }

    public void Respawn()
    {
        rBody.position = checkPoint.transform.position;
        rBody.rotation = checkPoint.transform.rotation;

        controller2d.Reset();
    }

    public void FountainRespawn()
    {
        /* 
        rBody.position = fountainCheckPoint.transform.position;
        rBody.rotation = fountainCheckPoint.transform.rotation;

        hp = saved_hp;
        healthBar.SetHP(hp);

        controller2d.Reset(); */
    }
}
