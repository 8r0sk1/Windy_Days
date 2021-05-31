using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox_rotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotation_amount;
    void Start()
    {
        RenderSettings.skybox.SetFloat("_Rotation", rotation_amount);
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", rotation_amount);
    }
}
