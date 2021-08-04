using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class EnemyManager : AliveEntity
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<CustomTag>().HasTag("Robot_A") && GameData.isRobotDead_A)
            this.gameObject.SetActive(false);
        if (this.GetComponent<CustomTag>().HasTag("Robot_B") && GameData.isRobotDead_B)
            this.gameObject.SetActive(false);
        if (this.GetComponent<CustomTag>().HasTag("Troll") && GameData.isTrollDead)
            this.gameObject.SetActive(false);
       

        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        //dead state
        if (hp <= 0)
        {
            //DEBUG
            Debug.Log(this.name+" is dead");

            if (this.GetComponent<CustomTag>().HasTag("Robot_A") && !GameData.isRobotDead_A)
            {
                if (GameData.isRobotDead_A == false)
                {
                    this.GetComponent<Animator>().SetTrigger("isDead");
                }
                GameData.isRobotDead_A = true;
            }
            if (this.GetComponent<CustomTag>().HasTag("Robot_B") && !GameData.isRobotDead_B)
            {
                if (GameData.isRobotDead_B == false)
                {
                    this.GetComponent<Animator>().SetTrigger("isDead");
                }
                GameData.isRobotDead_B = true;
            }
            if (this.GetComponent<CustomTag>().HasTag("Troll") && !GameData.isTrollDead)
            {
                if (GameData.isTrollDead == false)
                {
                    this.GetComponent<Animator>().SetTrigger("isDead");
                }
                GameData.isTrollDead = true;
            }
            //this.gameObject.SetActive(false); //de-enable


            //AGGIUNGERE DEAD ANIMATION
        }
    }
}
