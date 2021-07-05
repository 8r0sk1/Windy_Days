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

        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        if (GameData.objFlags[(int)obj])
            this.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        playerManager.objFlags[(int)obj] = true;
        playerManager.Wear(obj);
    }
}
