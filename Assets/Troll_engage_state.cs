using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class Troll_engage_state : StateMachineBehaviour
{
    private Troll_search_mechanic troll_search_script;
    private Rigidbody body;
    public float rotSpeed = 30;
    public float moveSpeed = 1;
    private WarperLock warperlock;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DEBUG
        Debug.Log("Entered in " + this.name);

        body = animator.GetComponent<Rigidbody>();
        troll_search_script = animator.GetComponentInChildren<Troll_search_mechanic>();
        animator.GetComponent<MeleeWeapon>().hitBox.SetActive(false);

        warperlock = animator.GetComponent<WarperLock>();
        warperlock.Lock();

        //if (!GameData.isTrollTrolling)
          //  GameData.isTrollTrolling = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isOutOfRange", troll_search_script.isOutOfRange);

        //Rotate towards the player
        Vector3 targetDirection = (troll_search_script.player.transform.position - animator.transform.position);
        targetDirection = new Vector3(targetDirection.x, 0, targetDirection.z).normalized;
        
        //DEBUG
        //Debug.Log("targetDir: " + targetDirection);

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        //DEBUG
        //Debug.Log("targetRotation: " + targetRotation);

        body.MoveRotation(Quaternion.RotateTowards(body.rotation, targetRotation, Time.deltaTime * rotSpeed));

        //Move towards the player
        body.MovePosition(animator.transform.position + moveSpeed * animator.transform.forward * Time.deltaTime);
    }
}
