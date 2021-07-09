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
    private Potions_UI potions_ui;

    public GameObject shield;
    public GameObject bodyMesh;
    public GameObject cloud;
    public GameObject necklace;
    public GameObject bottle;
    public GameObject shoulderPads_left;
    public GameObject shoulderPads_right;

    public bool[] objFlags = new bool[4]; //flag per oggetti sbloccabili

    private bool isInvincible = false;
    private float timer;

    //healing data
    

    private bool isParrying;

    void Start()
    {
        if (debugMode)
            for (int i = 0; i < objFlags.Length; i++)
                objFlags[i] = true;
        else
            objFlags = GameData.objFlags;

        //UI REFERENCES
        healthBar = GameObject.FindObjectOfType<HealthBar>();
        potions_ui = GameObject.FindObjectOfType<Potions_UI>();

        //COMPONENT REFERENCES
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

        //SET UI VALUES
        healthBar.SetHP(hp);
        potions_ui.SetPotions(GameData.current_potions);
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
        if (Input.GetButtonDown("Heal") && GameData.current_potions > 0)
        {
            if (hp < GameData.hp_max)
            {
                GameData.current_potions -= 1;
                HPsum(2);
                potions_ui.SetPotions(GameData.current_potions);
            }
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
    public void RestoreHP()
    {
        hp = GameData.hp_max;
        healthBar.SetHP(hp);
    }

    public void Respawn()
    {
        GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>().SetTrigger("_fadeOUTsameLvl");
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
            case playerObj.shoulderPads:
                shoulderPads_left.SetActive(true);
                shoulderPads_right.SetActive(true);
                GameData.hp_max = GameData.hp_max_armoured;
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
