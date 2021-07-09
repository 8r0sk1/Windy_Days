using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnd : DialogueManager
{
    override public void EndDialogue()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(12);
    }
}
