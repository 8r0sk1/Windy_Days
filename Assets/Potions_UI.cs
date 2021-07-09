using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potions_UI : MonoBehaviour
{

    private TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = this.GetComponent<TextMeshProUGUI>();
    }

    public void SetPotions(int value)
    {
        textComponent.text = "potions: " + value; 
    }
}
