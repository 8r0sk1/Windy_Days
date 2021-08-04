using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using GameLib;
public class MenuFunctions : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider OST_slider;
    public Slider SFX_slider;
    public Slider MB_slider;
    public Toggle DM_toggle;

    private void Start()
    {
        MB_slider.value = GameData.blur_strength;
        DM_toggle.isOn = GameData.DM_toggle;

        OST_slider.value = GameData.OST_volume;
        SFX_slider.value = GameData.SFX_volume;

        mixer.SetFloat("OST_Volume", Mathf.Log(OST_slider.value) * 20);
        mixer.SetFloat("SFX_Volume", Mathf.Log(SFX_slider.value) * 20);
    }

    // MAIN MENU functions

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

    public void SetVolume(bool isMusic)
    {
        if (isMusic)
        {
            mixer.SetFloat("OST_Volume", Mathf.Log(OST_slider.value) * 20);
            GameData.OST_volume = OST_slider.value;
        }
        else
        {
            mixer.SetFloat("SFX_Volume", Mathf.Log(SFX_slider.value) * 20);
            GameData.SFX_volume = SFX_slider.value;
        }
    }

    public void SetBlur()
    {
        GameData.blur_strength = MB_slider.value;
    }

    //ENDSCREEN functions
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
