using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNewScene : MonoBehaviour
{

    public int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //DEBUG
            Debug.Log("new scene loading: "+ sceneIndex);
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
