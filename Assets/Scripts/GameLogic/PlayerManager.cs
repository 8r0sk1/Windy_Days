﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameLib;

public class PlayerManager : AliveEntity
{
    public bool debugMode;

    public Transform checkPoint;

    private CC2D controller2d;
    private CC3D controller3d;
    private HealthBar healthBar;

    public GameObject shield;
    public GameObject bodyMesh;
    public GameObject cloud;
    public GameObject necklace;
    public GameObject bottle;

    public bool[] objFlags = new bool[3]; //flag per oggetti sbloccabili

    private bool isInvincible = false;
    private float timer;

    private bool isParrying;

    void Start()
    {
        if (debugMode)
            for (int i = 0; i < objFlags.Length; i++)
                objFlags[i] = true;
        else
            objFlags = GameData.objFlags;

        healthBar = GameObject.FindObjectOfType<HealthBar>();
        controller3d = this.GetComponent<CC3D>();
        controller2d = this.GetComponent<CC2D>();
        rBody = this.GetComponent<Rigidbody>();

        for(int i = 0; i < objFlags.Length; i++)
        {
            if (objFlags[i])
                Wear((playerObj)i);
        }

        max_hp = GameData.hp_max;

        //FOUNTAIN RESPAWN
        if (GameData.haveToFountainRespawn)
        {
            this.gameObject.transform.position = GameData.fountainCheckpointPosition;
            this.gameObject.transform.rotation = GameData.fountainCheckpointRotation;
            GameData.haveToFountainRespawn = false;

            hp = max_hp;
            healthBar.SetHP(hp);
        }
        else
        {
            hp = GameData.hp;
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            //DEBUG
            Debug.Log("YOU DIED");
            this.FountainRespawn();
        }

        if (timer > 0)
            timer -= Time.deltaTime;
        else if (isInvincible && isParrying)
        {
            SetInvincible(0);
            isParrying = false;
        }
    }

    public void SetInvincible(int flag)
    {
        isInvincible = flag != 0 ? true : false;

        //DEBUG
        Debug.Log("Invincible " + isInvincible);
    }

    public void SetInvincibleTimer(float invincibleTime)
    {
        SetInvincible(1);
        timer = invincibleTime;
        isParrying = true;
    }

    override public void HPsum(int sum)
    {
        if (!isInvincible)
        {
            hp += sum;
            healthBar.SetHP(hp);
        }
    }

    public void Respawn()
    {
        if (!GameData.haveToFountainRespawn)
        {
            rBody.position = checkPoint.transform.position;
            rBody.rotation = checkPoint.transform.rotation;
        }

        controller2d.Reset();
    }

    public void FountainRespawn()
    {
        if(controller2d.isActiveAndEnabled)
            controller2d.Reset();

        GameData.entryPoint = 0; //reset dell'entry point
        GameData.haveToFountainRespawn = true;
        SceneManager.LoadScene(GameData.fountainCheckpointSceneIndex,LoadSceneMode.Single);
    }

    public void Wear(playerObj obj)
    {
        switch (obj)
        {
            case playerObj.bottle:
                bottle.SetActive(true);
                break;
            case playerObj.shield:
                shield.SetActive(true);
                break;
            case playerObj.necklace:
                necklace.SetActive(true);
                break;
        }
    }

    public void OnDestroy()
    {
        //aggiorno tutti i dati da mantenere tra le scene
        if (!GameData.haveToFountainRespawn)
        {
            GameData.objFlags = objFlags;
            GameData.hp = hp;
        }
    }
}
