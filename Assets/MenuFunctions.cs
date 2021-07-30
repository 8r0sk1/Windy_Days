using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MenuFunctions : MonoBehaviour
    // MAIN MENU functions

{

    public AudioMixerGroup OST_mixer;
    public AudioMixerGroup SFX_mixer;
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
