using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using GameLib;
public class MenuFunctions : MonoBehaviour
    // MAIN MENU functions

{

    //public AudioMixerGroup OST_mixer;
    //public AudioMixerGroup SFX_mixer;
    public AudioMixer mixer;
    public Slider OST_slider;
    public Slider SFX_slider;
    public Slider MB_slider;
    public Toggle DM_toggle;

    private void Start()
    {
        mixer.SetFloat("OST_Volume", Mathf.Log(OST_slider.value) * 20);
        mixer.SetFloat("SFX_Volume", Mathf.Log(SFX_slider.value) * 20);
    }
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
        GameData.DM_toggle = DM_toggle.isOn;
    }
    public void SetVolume()
    {
        mixer.SetFloat("OST_Volume", Mathf.Log(OST_slider.value) * 20);
        mixer.SetFloat("SFX_Volume", Mathf.Log(SFX_slider.value) * 20);
    }
    public void SetBlur()
    {
        GameData.blur_strength = MB_slider.value;
    }

    //ENDSCREEN functions
    public void BackToMenu()
    {

    }

}
