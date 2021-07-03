using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameLib;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        slider = this.GetComponent<Slider>();

        slider.maxValue = GameData.hp_max;
        slider.value = GameData.hp;
    }

    public void SetHP(int current_hp)
    {
        slider.value = current_hp;
    }
}
