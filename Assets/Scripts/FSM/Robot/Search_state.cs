using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_state : StateMachineBehaviour
{
    private Robot_SearchMechanic robot_sight_script;
    public float rotSpeed = 20;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DEBUG
        Debug.Log("Entered in " + this.name);

        robot_sight_script = animator.GetComponentInChildren<Robot_SearchMechanic>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        animator.SetBool("playerInSight", robot_sight_script.playerInSight);

        if (Random.value < 0.002f)
            rotSpeed = -rotSpeed;
        animator.transform.RotateAround(animator.transform.position,animator.transform.up, rotSpeed * Time.deltaTime);
        //animator.transform.rota
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
