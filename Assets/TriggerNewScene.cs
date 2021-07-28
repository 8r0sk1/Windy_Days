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
    private Animator Fade_anim;

    private void Awake()
    {
        Fade_anim = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isBackground)
        {
            if (other.CompareTag("Player"))
            {
                //DEBUG
                Debug.Log("new scene loading: " + sceneIndex);
                GameData.entryPoint = nextEntryPoint;
                FadeOut_state.SetSceneIndex(sceneIndex);
                Fade_anim.SetTrigger("_fadeOUT");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isBackground && Input.GetAxis("Vertical") > 0.95f)
        {
            if (other.CompareTag("Player"))
            {
                //DEBUG
                Debug.Log("new scene loading: " + sceneIndex);
                GameData.entryPoint = nextEntryPoint;
                FadeOut_state.SetSceneIndex(sceneIndex);
                Fade_anim.SetTrigger("_fadeOUT"); 
            }
        }
    }
}
