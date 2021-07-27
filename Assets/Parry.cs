using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public float invincibleTime = 0.5f;
    private PlayerManager playerManager;
    public AudioSource Player_Audio2;
    public AudioClip Parry_Clang;

    private void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeapon"))
        {
            Player_Audio2.Stop();
            Player_Audio2.pitch = 1;
            Player_Audio2.volume = 1;
            Player_Audio2.clip = Parry_Clang;
            Player_Audio2.Play();
            playerManager.SetInvincibleTimer(invincibleTime);
        }
    }
}
