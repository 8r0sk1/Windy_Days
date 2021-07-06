using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    private GameObject player;
    private PlayerManager playerManager;
    public DialogueTrigger trigger;
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            trigger.TriggerDialogue();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && Input.GetButtonDown("Use"))
        {
            Debug.Log("next sentence");
            dialogueManager.DisplayNextSentence();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
