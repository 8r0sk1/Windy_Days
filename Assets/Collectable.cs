using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

namespace GameLib
{
    public enum playerObj { bottle, shield, necklace }
}

public class Collectable : Interactable
{

    public playerObj obj;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CC3D>();
        playerManager = player.GetComponent<PlayerManager>();
        hasInputUse = false;

        if (GameData.objFlags[(int)obj])
            this.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        playerManager.objFlags[(int)obj] = true;
        playerManager.Wear(obj);
        controller.isRollDisabled = false;
        this.gameObject.SetActive(false);
    }
}
