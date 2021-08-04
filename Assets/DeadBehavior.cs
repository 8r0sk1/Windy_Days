using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBehavior : StateMachineBehaviour
{

    public AudioClip clip;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInChildren<MeleeWeapon>().DisableHitbox();
        animator.GetComponent<Rigidbody>().isKinematic = true;
        animator.GetComponent<CapsuleCollider>().enabled = false;
        animator.GetComponentInChildren<WarperLock>().Unlock();

        AudioSource source = GameObject.FindGameObjectWithTag("AdditionalAudioSource").GetComponent<AudioSource>();
        source.Stop();
        source.volume = 1f;
        source.pitch = 1f;
        source.Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
