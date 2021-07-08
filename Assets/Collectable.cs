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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller3D = player.GetComponent<CC3D>();
        controller2D = player.GetComponent<CC2D>();
        playerManager = player.GetComponent<PlayerManager>();
        hasInputUse = false;

        if (GameData.objFlags[(int)obj])
            this.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        Debug.Log(obj);
        Debug.Log((int)obj);
        playerManager.objFlags[(int)obj] = true;
        playerManager.Wear(obj);
        controller3D.isRollDisabled = false;
        controller2D.isJumpDisabled = false;
        this.gameObject.SetActive(false);
    }
}
