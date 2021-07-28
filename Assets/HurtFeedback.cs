using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtFeedback : MonoBehaviour
{
    private float timer;
    private bool triggered;
    private RawImage ScreenCorners;
    public float alpha_time;
    private Color starting_color;



    public void TriggerHurtFeedback()
    {
        timer = alpha_time;
        ScreenCorners.color = starting_color;
    }


    // Start is called before the first frame update
    void Start()
    {
        ScreenCorners = this.GetComponent<RawImage>();
        starting_color = ScreenCorners.color;
        ScreenCorners.color = new Color(starting_color.r, starting_color.g, starting_color.b, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            ScreenCorners.color = new Color(starting_color.r, starting_color.g, starting_color.b, Mathf.Lerp(0, 1, timer));
        }
        
    }
}