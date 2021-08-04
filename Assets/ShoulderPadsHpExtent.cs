using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameLib;

public class ShoulderPadsHpExtent : MonoBehaviour
{
    private Slider slider;
    private PlayerManager playerManager;
    private bool updated;

    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.maxValue = GameData.hp_max_armoured;
        slider.value = GameData.hp_max;
        updated = false;
    }

    private void Update()
    {
        if (!updated)
        {
            if (playerManager.objFlags[(int)playerObj.shoulderPads])
            {
                slider.value = GameData.hp_max_armoured;
                updated = true;
            }
        }
    }
}
