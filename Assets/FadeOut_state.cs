using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameLib;

public class FadeOut_state : StateMachineBehaviour
{
    private static int sceneIndex;
    public static void SetSceneIndex(int index)
    {
        sceneIndex = index;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
