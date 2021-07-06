using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_search_mechanic : MonoBehaviour
{
    public bool isOutOfRange { private set; get; }

    public GameObject player { private set; get; }
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isOutOfRange = true;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //DEBUG
            Debug.Log("Collide with " + other.gameObject);

            isOutOfRange = false;
            anim.SetBool("isOutOfRange", isOutOfRange);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //DEBUG
            Debug.Log("Collide with " + other.gameObject);

            isOutOfRange = true;
            anim.SetBool("isOutOfRange", isOutOfRange);
        }
    }
}
