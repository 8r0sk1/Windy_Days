using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitSound : MonoBehaviour
{
    public AudioSource source;
    public GameObject bloodParticles;
    public GameObject sparkParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Enemy"))
        {
            source.Play();
        }

        if (col.gameObject.GetComponent<CustomTag>().HasTag("Troll"))
        {
            GameObject newParticles = Instantiate(bloodParticles, null);
            newParticles.transform.position = col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            //newParticles.transform.forward = col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        }
        
        if (col.gameObject.GetComponent<CustomTag>().HasTag("Robot_A") || col.gameObject.GetComponent<CustomTag>().HasTag("Robot_B"))
        {
            //DEBUG
            Debug.Log("SMAZZOLANDO IL ROBOT");

            GameObject newParticles = Instantiate(sparkParticles, null);
            newParticles.transform.position = col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            //newParticles.transform.forward = col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        }
    }
}
