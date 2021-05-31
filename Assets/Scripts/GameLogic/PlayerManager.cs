using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int max_hp;
    public int hp;
    public int saved_hp;

    public GameObject checkPoint;
    private Rigidbody rBody;
    private CC2D controller2d;
    private CC3D controller3d;

    public void HPsum(int sum)
    {
        hp += sum;
    }

    public void Respawn()
    {
        rBody.position = checkPoint.transform.position;
        rBody.rotation = checkPoint.transform.rotation;

        hp = saved_hp;

        controller2d.Reset();
    }

    void Start()
    {
        hp = max_hp;
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
}
