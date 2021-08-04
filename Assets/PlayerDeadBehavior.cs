using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadBehavior : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AudioSource>().Stop();
        FindObjectOfType<AudioManager>().PauseSource();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerManager>().FountainRespawn();
    }
}
