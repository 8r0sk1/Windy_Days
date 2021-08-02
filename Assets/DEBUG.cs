using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;
public class DEBUG : MonoBehaviour
{

    private bool DEBUG_MODE;

    // Start is called before the first frame update
    void Update()
    {
        if(DEBUG_MODE != GameData.DM_toggle)
        {
            DEBUG_MODE = GameData.DM_toggle;
        }
        
        if (DEBUG_MODE)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Debug"))
            {
                Debug.Log(obj.name);
                foreach (MeshRenderer renderer in obj.GetComponentsInChildren<MeshRenderer>())
                {
                    Debug.Log(renderer);
                    if (renderer.enabled == false)
                        renderer.enabled = true;
                }
            }

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EnemyWeapon"))
            {
                Debug.Log(obj.name);
                foreach (MeshRenderer renderer in obj.GetComponentsInChildren<MeshRenderer>())
                {
                    Debug.Log(renderer);
                    if (renderer.enabled == false)
                        renderer.enabled = true;
                }
            }
        }
    }
}
