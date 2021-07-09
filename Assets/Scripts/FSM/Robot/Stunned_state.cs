using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned_state : StateMachineBehaviour
{
    public float stunnedTime;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = stunnedTime;
        Debug.Log("I DO BE STUNNED SPONGEBOB");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            animator.SetBool("isStunned", false);
    }
}
