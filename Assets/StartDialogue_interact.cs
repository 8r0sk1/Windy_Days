using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue_interact : Interactable
{
    public DialogueTrigger trigger;
    public DialogueManager dialogueManager;
    private bool _hasToStart = true;

    override public void Interact()
    {
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

    private void OnTriggerExit(Collider other)
    {
        dialogueManager.EndDialogue();
        _hasToStart = true;
        controller3D.isRollDisabled = false;
        controller2D.isJumpDisabled = false;
        isColliding = false;
    }
}