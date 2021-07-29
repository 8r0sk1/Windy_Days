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
    private SpriteRenderer UI_stickUp;

    private void Start()
    {
        Fade_anim = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
        UI_stickUp = GameObject.FindGameObjectWithTag("UI_stickUp").GetComponent<SpriteRenderer>();
        foreach(SpriteRenderer renderer in UI_stickUp.GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.enabled = false;
        }
    }

    /*private void Awake()
    {
        Fade_anim = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
        UI_stickUp = GameObject.FindGameObjectWithTag("UI_stickUp");
        UI_stickUp.SetActive(false);
    }*/

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
        //UI STICK UP
        else
        {
            foreach (SpriteRenderer renderer in UI_stickUp.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isBackground && (Input.GetAxis("Vertical") > 0.95f || Input.GetKeyDown(KeyCode.W)))
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

    private void OnTriggerExit(Collider other)
    {
        if (isBackground)
        {
            foreach (SpriteRenderer renderer in UI_stickUp.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.enabled = false;
            }
        }
    }
}
