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

    public override void Interact()
    {
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        playerManager.objFlags[(int)obj] = true;
    }
}
