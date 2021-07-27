using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class HealFountainSound : MonoBehaviour
{
    private AudioSource Fountain_Audio;
    private PlayerManager player_manager;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        Fountain_Audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       // player_manager = other.GetComponent<PlayerManager>();

        if (other.CompareTag("Player"))
        {
            //if (player_manager.hp != player_manager.max_hp || GameData.current_potions != GameData.max_potions )
            if (flag == true)
            {
                Fountain_Audio.Play();
                flag = false;
            }
        }

        
    }
}
