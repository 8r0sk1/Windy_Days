using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

namespace GameLib
{
    public enum playerObj { bottle, shield, necklace, shoulderPads}
}

public class Collectable : Interactable
{


    public playerObj obj;
    public AudioSource Player_Audio;
    public AudioClip Loot_Audio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller3D = player.GetComponent<CC3D>();
        controller2D = player.GetComponent<CC2D>();
        playerManager = player.GetComponent<PlayerManager>();
        hasInputUse = false;

        UI_buttonA = GameObject.FindGameObjectWithTag("UI_buttonA").GetComponent<SpriteRenderer>();
        UI_buttonA.enabled = false;

        if (GameData.objFlags[(int)obj])
            this.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        Player_Audio.Stop();
        Player_Audio.clip = Loot_Audio;
        Player_Audio.pitch = 1;
        Player_Audio.volume = 0.4f;
        Player_Audio.Play();

        Debug.Log(obj);
        Debug.Log((int)obj);
        GameData.objFlags[(int)obj] = true;
        playerManager.objFlags[(int)obj] = true;
        playerManager.Wear(obj);
        controller3D.isRollDisabled = false;
        controller2D.isJumpDisabled = false;

        UI_buttonA.enabled = false;

        this.gameObject.SetActive(false);
    }
}
