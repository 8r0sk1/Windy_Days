using System.Collections;
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

    void Start()
    {
        if (debugMode)
            for (int i = 0; i < objFlags.Length; i++)
                objFlags[i] = true;
        else
            objFlags = GameData.objFlags;

        //FOUNTAIN RESPAWN
        if (GameData.haveToFountainRespawn)
        {
            this.gameObject.transform.position = GameData.fountainCheckpoint.position;
            this.gameObject.transform.rotation = GameData.fountainCheckpoint.rotation;
            GameData.haveToFountainRespawn = false;

            hp = max_hp;
            healthBar.SetHP(hp);
        }
        else
        {
            max_hp = GameData.hp_max;
            hp = GameData.hp;
        }

        healthBar = GameObject.FindObjectOfType<HealthBar>();
        controller3d = this.GetComponent<CC3D>();
        controller2d = this.GetComponent<CC2D>();
        rBody = this.GetComponent<Rigidbody>();

        for(int i = 0; i < objFlags.Length; i++)
        {
            if (objFlags[i])
                Wear((playerObj)i);
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
