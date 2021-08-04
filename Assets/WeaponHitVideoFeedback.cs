using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitVideoFeedback : MonoBehaviour
{

    public GameObject particleSystem;

    private void OnCollisionEnter(Collision col)
    {
        //DEBUG
        Debug.Log("In OnCollisionEnter chiamata da " + col.gameObject);

        if (col.gameObject.GetComponent<CustomTag>().HasTag("PlayerWeapon"))
        {
            GameObject newParticles = Instantiate(particleSystem, null);
            newParticles.transform.position = col.GetContact(0).point;
            newParticles.transform.forward = col.GetContact(0).normal;
        }
    }
}
