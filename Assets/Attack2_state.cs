using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2_state : StateMachineBehaviour
{
    private CCmecha controller;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<CCmecha>();
        controller.weaponB.EnableHitbox();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.weaponB.DisableHitbox(); ;
    }
}
