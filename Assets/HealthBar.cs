using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        slider = this.GetComponent<Slider>();

        slider.maxValue = playerManager.max_hp;
    }

    public void SetHP(int current_hp)
    {
        slider.value = current_hp;
    }
}
