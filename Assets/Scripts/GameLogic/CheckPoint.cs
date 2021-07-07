using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameLib;

public class CheckPoint : MonoBehaviour
{
    GameObject player;
    PlayerManager playerManager;
    public bool isFountainCheckpoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (!isFountainCheckpoint)
                playerManager.checkPoint = this.transform;
            else //fountain checkpoint found
            {
                //DEBUG
                Debug.Log("Current scene index : " + SceneManager.GetActiveScene().buildIndex);
                GameData.current_potions = GameData.max_potions;
                playerManager.RestoreHP();
                GameData.fountainCheckpointSceneIndex = SceneManager.GetActiveScene().buildIndex;
                GameData.fountainCheckpointPosition = player.transform.position;
                GameData.fountainCheckpointRotation = player.transform.rotation;
            }
        }
    }
}
