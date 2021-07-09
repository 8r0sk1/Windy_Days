using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{

    public bool DEBUG_MODE;

    // Start is called before the first frame update
    void Start()
    {
        if (!DEBUG_MODE)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Debug"))
            {
                obj.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
