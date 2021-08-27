using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    public List<StartDialogue_auto> dialogueList;

    // Start is called before the first frame update
    void Start()
    {
        dialogueList = new List<StartDialogue_auto>();

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
