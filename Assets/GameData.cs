using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib
{
    public static class GameData
    {
        public static int hp_max = 15;
        public static int hp = 15;
        public static int max_potions = 3;
        public static int current_potions = 3;

        public static bool haveToFountainRespawn;
        public static int fountainCheckpointSceneIndex;
        public static Vector3 fountainCheckpointPosition;
        public static Quaternion fountainCheckpointRotation;

        public static bool[] objFlags = new bool[3];

        public static int entryPoint;
    }
}
