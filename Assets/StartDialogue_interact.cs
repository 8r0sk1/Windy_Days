using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue_interact : Interactable
{
    public DialogueTrigger trigger;
    public DialogueManager dialogueManager;
    public bool _hasToStart = true;

    override public void Interact()
    {
        dialogueManager.current_dialogue = this;

        if (_hasToStart == true)
        {
            trigger.TriggerDialogue();
            _hasToStart = false;
        }
        //Debug.Log("next sentence");
        else
        {
            dialogueManager.DisplayNextSentence();

        }
    }

    new private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_buttonA.enabled = false;

            dialogueManager.EndDialogue();
            _hasToStart = true;
            controller3D.isRollDisabled = false;
            //controller2D.isJumpDisabled = false;
            isColliding = false;
        }
    }
}