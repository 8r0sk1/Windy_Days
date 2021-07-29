using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFeedback : MonoBehaviour
{
    private float timer;
    private bool triggered;
    private Light light;
    public float light_time;
    public float light_intensity;

    public void TriggerHealFeedback()
    {
        timer = light_time;
        light.intensity = light_intensity;

    }


    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            light.intensity = Mathf.Lerp(0, light_intensity, timer);
        }
        else
            light.intensity = 0;
    }
}
