using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeadPoint : MonoBehaviour
{
    public bool isPitfall;
    public int hp_loss;
    public float hurtTime = 1, elapsedTime;

    GameObject player;
    PlayerManager playerManager;

    void Start()
    {
        elapsedTime = 0f;

        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {

            playerManager.HPsum(-hp_loss);
            elapsedTime = 0f;

            if (isPitfall)
            {
                other.GetComponent<CC2D>().isMovementDisabled = true;
                if (playerManager.hp <= 0)
                    playerManager.FountainRespawn();
                else
                    playerManager.Respawn();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (elapsedTime >= hurtTime)
            {
                playerManager.HPsum(-hp_loss);
                elapsedTime = 0f;
            }
            else elapsedTime += Time.deltaTime;
        }
    }
}
