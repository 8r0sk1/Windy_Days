using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
    // MAIN MENU functions
{
    public void StartGame()
    {
        SceneManager.LoadScene(6);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    //OPTIONS functions

    public void ToggleDebug()
    {

    }
    public void SetVolume()
    {

    }
    public void SetBlur(){

    }

    //ENDSCREEN functions
    public void BackToMenu()
    {

    }

}
