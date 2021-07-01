using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_AttackMechanic : MonoBehaviour
{
    public bool isOutOfAtkRange { private set; get; }

    public GameObject player { private set; get; }

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isOutOfAtkRange = false;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //DEBUG
            Debug.Log(other.gameObject + "Is in atk range");

            if (other.CompareTag("Player"))
            {
                isOutOfAtkRange = false;
                anim.SetBool("isInAtkRange",true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //DEBUG
            Debug.Log(other.gameObject + "Is out of atk range");

            if (other.CompareTag("Player"))
            {
                isOutOfAtkRange = true;
                anim.SetBool("isInAtkRange", false);
            }
        }
    }
}
