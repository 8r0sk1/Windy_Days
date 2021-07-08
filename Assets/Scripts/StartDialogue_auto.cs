using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue_auto : Interactable
{
    public DialogueTrigger trigger;
    public DialogueManager dialogueManager;
    //private bool _dialogueStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        controller.isRollDisabled = true;
        isColliding = true;

        if (other.gameObject == player)
        {
            trigger.TriggerDialogue();
            //_dialogueStarted = true;
        }
    }

    public override void Interact()
    {
        Debug.Log("next sentence");
        dialogueManager.DisplayNextSentence();
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueManager.EndDialogue();
        controller.isRollDisabled = false;
        isColliding = false;
    }
}
