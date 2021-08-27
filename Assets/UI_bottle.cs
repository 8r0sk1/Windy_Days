using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_bottle : MonoBehaviour
{

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = this.GetComponentInChildren<SpriteRenderer>();
        renderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !this.GetComponentInParent<SandMassBehavior>().blown)
        {
            renderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.enabled = false;
        }
    }
}
