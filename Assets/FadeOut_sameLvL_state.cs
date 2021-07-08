using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class FadeOut_sameLvL_state : StateMachineBehaviour
{
    private GameObject player;
    private CC2D controller2d;
    private PlayerManager playerManager;
    private Rigidbody rBody;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller2d = player.GetComponent<CC2D>();
        rBody = player.GetComponent<Rigidbody>();
        playerManager = player.GetComponent<PlayerManager>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!GameData.haveToFountainRespawn)
        {
            rBody.position = playerManager.checkPoint.transform.position;
            rBody.rotation = playerManager.checkPoint.transform.rotation;
        }

        controller2d.Reset();
    }
}
