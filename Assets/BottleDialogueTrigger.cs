using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class BottleDialogueTrigger : MonoBehaviour
{
    private BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = this.GetComponent<BoxCollider>();

        if (GameData.objFlags[(int)playerObj.bottle] == false)
            collider.enabled = false;
    }
}
