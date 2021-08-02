using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDeadBehavior : StateMachineBehaviour
{
    private Light light;
    private float light_intensity;
    public float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach(MeleeWeapon script in animator.GetComponentsInChildren<MeleeWeapon>())
            script.DisableHitbox();

        light = animator.GetComponentInChildren<Light>();

        light_intensity = light.intensity;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            light.intensity = Mathf.Lerp(0, light_intensity, timer);
        }
        else
            light.intensity = 0;
    }

}
