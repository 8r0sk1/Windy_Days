using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public float invincibleTime = 0.5f;
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeapon"))
        {
            playerManager.SetInvincibleTimer(invincibleTime);
        }
    }
}
