﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib
{
    public static class GameData
    {
        public static int hp_max = 12;
        public static int hp = 12;
        public static int hp_max_armoured = 15;
        public static int max_potions = 3;
        public static int current_potions = 3;

        public static bool haveToFountainRespawn;
        public static int fountainCheckpointSceneIndex;
        public static Vector3 fountainCheckpointPosition;
        public static Quaternion fountainCheckpointRotation;

        public static bool[] objFlags = new bool[4];

        // :( public static bool isTrollTrolling = false;
        public static bool isTrollDead = false;

        public static bool isRobotRoboting = false;
        public static bool isRobotDead_A = false;
        public static bool isRobotDead_B = false;

        public static int entryPoint;

        public static float SFX_volume = 0.5f;
        public static float OST_volume = 0.5f;

        public static float blur_strength = 0.5f;
        public static bool DM_toggle = false; //DA SETTARE FALSE!

        public static void Reset()
        {
             hp_max = 12;
             hp = 12;
             hp_max_armoured = 15;
             max_potions = 3;
             current_potions = 3;

             objFlags = new bool[4];

             isTrollDead = false;

             isRobotRoboting = false;
             isRobotDead_A = false;
             isRobotDead_B = false;

             DM_toggle = false; 
        }
    }
}
