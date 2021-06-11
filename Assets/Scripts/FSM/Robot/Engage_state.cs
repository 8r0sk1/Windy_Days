using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engage_state : StateMachineBehaviour
{
    private Robot_SearchMechanic robot_sight_script;
    private Rigidbody body;
    public float rotSpeed = 30;
    public float moveSpeed = 1;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DEBUG
        Debug.Log("Entered in " + this.name);

        body = animator.GetComponent<Rigidbody>();
        robot_sight_script = animator.GetComponentInChildren<Robot_SearchMechanic>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isOutOfRange", robot_sight_script.isOutOfRange);

        //Rotate towards the player
        Vector3 targetDirection = (robot_sight_script.player.transform.position - animator.transform.position);
        targetDirection = new Vector3(targetDirection.x, 0, targetDirection.z).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        body.MoveRotation(Quaternion.RotateTowards(body.rotation, targetRotation, Time.deltaTime * rotSpeed));

        //Move towards the player
        body.MovePosition(animator.transform.position + moveSpeed * animator.transform.forward * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
