using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameLib;

public class Potions_UI : MonoBehaviour
{

    private TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = this.GetComponent<TextMeshProUGUI>();
        SetPotions(GameData.current_potions);
    }

    public void SetPotions(int value)
    {
        textComponent.text = "x " + value; 
    }
}
