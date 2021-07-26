using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class Engage_state : StateMachineBehaviour
{
    private Robot_SearchMechanic robot_sight_script;
    private Rigidbody body;
    public float rotSpeed = 30;
    public float moveSpeed = 1;
    private AudioSource Engage_Audio;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DEBUG
        Debug.Log("Entered in " + this.name);

        Engage_Audio = GameObject.FindGameObjectWithTag("RobotEngageAudio").GetComponent<AudioSource>();

        body = animator.GetComponent<Rigidbody>();
        robot_sight_script = animator.GetComponentInChildren<Robot_SearchMechanic>();
        Engage_Audio.Play();

        if(!GameData.isRobotRoboting)
            GameData.isRobotRoboting = true;
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

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Engage_Audio.Stop();
    }
}
