using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameLib;

public class TriggerNewScene : MonoBehaviour
{
    public int sceneIndex;
    public int nextEntryPoint;
    public bool isBackground;

    private void OnTriggerEnter(Collider other)
    {
        if (!isBackground)
        {
            if (other.CompareTag("Player"))
            {
                //DEBUG
                Debug.Log("new scene loading: " + sceneIndex);
                GameData.entryPoint = nextEntryPoint;
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isBackground && Input.GetAxis("Vertical") > 0.1f)
        {
            if (other.CompareTag("Player"))
            {
                //DEBUG
                Debug.Log("new scene loading: " + sceneIndex);
                GameData.entryPoint = nextEntryPoint;
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
            }
        }
    }
}
