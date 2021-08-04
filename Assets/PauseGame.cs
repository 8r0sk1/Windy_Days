using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;
    public GameObject[] objects_ui = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            //DEBUG
            Debug.Log("START BUTTON PRESSED");

            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        //DEBUG
        Debug.Log("PAUSE");

        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;

        for (int i = 0; i < 4; i++)
        {
            if (GameData.objFlags[i])
            {
                objects_ui[i].SetActive(true);
            }
            else
                objects_ui[i].SetActive(false);
        }

        FindObjectOfType<CC2D>().isMovementDisabled = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;

        FindObjectOfType<CC2D>().isMovementDisabled = false;
    }
}
