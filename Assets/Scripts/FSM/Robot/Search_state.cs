using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_state : StateMachineBehaviour
{
    private Robot_SearchMechanic robot_sight_script;
    public float rotSpeed = 20;
    private AudioSource Robot_Idle;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DEBUG
        Debug.Log("Entered in " + this.name);
        Robot_Idle = GameObject.FindGameObjectWithTag("RobotIdleAudio").GetComponent<AudioSource>();

        robot_sight_script = animator.GetComponentInChildren<Robot_SearchMechanic>();
        Robot_Idle.Stop();
        Robot_Idle.Play();
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
}
