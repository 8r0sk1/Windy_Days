using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : AliveEntity
{
    // Start is called before the first frame update
    void Start()
    {
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

            this.gameObject.SetActive(false); //de-enable

            //AGGIUNGERE DEAD ANIMATION
        }
    }
}
