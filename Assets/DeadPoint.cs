using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeadPoint : MonoBehaviour
{
    public bool deadly;
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
        if (other.gameObject == player)
            if (deadly) {
                playerManager.HPsum(-playerManager.max_hp);
            }
            else{
                playerManager.HPsum(-hp_loss);
                elapsedTime = 0f;
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
