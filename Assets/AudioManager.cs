using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameLib;

public class AudioManager : MonoBehaviour
{
    public AudioClip menu, dungeon, exploration, boss, robot, fountain;
    private AudioSource source;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        source.Stop();
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                source.clip = menu;
                break;
            case 1:
                source.clip = dungeon;
                break;
            case 2:
                source.clip = fountain;
                break;
            case 3:
                source.clip = dungeon;
                break;
            case 4:
                //BOSS
                source.clip = boss;
                break;
            case 5:
                source.clip = dungeon;
                break;
            case 6:
                source.clip = exploration;
                break;
            case 7:
                source.clip = exploration;
                break;
            case 8:
                source.clip = exploration;
                break;
            case 9:
                source.clip = fountain;
                break;
            case 10:
                //ROBOT
                source.clip = dungeon;
                break;
            case 11:
                source.clip = dungeon;
                break;
        }
        source.Play();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            if (GameData.isRobotRoboting && source.clip != robot)
            {
                source.Stop();
                source.clip = robot;
                source.Play();
            }
            if (GameData.isRobotDead && source.clip != dungeon)
            {
                source.Stop();
                source.clip = dungeon;
                source.Play();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            if (GameData.isTrollDead && source.clip != dungeon)
            {
                source.Stop();
                source.clip = dungeon;
                source.Play();
            }
        }
    }
}
