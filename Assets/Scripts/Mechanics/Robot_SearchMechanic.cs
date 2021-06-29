using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_SearchMechanic : MonoBehaviour
{
    public bool playerInSight { private set; get; }
    public bool isOutOfRange { private set; get; }

    public GameObject player { private set; get; }
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        playerInSight = false;
        isOutOfRange = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distance = (player.transform.position - this.transform.position).magnitude;

            if (distance > this.transform.localScale.x)
                isOutOfRange = true;
            else if (isOutOfRange)
                isOutOfRange = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //player = other.gameObject;

            //DEBUG
            Debug.Log("Collide with " + other.gameObject);

            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, (other.transform.position - this.transform.position).normalized, out hit, this.transform.localScale.x)) {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInSight = true;
                    isOutOfRange = false;

                    //DEBUG
                    Debug.DrawLine(this.transform.position, hit.collider.transform.position, Color.red, 5);
                    Debug.Log("Player in Sight ");
                }
                else
                    playerInSight = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //forse non necessario ?
        if (other.gameObject.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }
}
