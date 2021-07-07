using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib
{
    public static class GameData
    {
        public static int hp_max = 15;
        public static int hp = 15;

        public static bool haveToFountainRespawn;
        public static int fountainCheckpointSceneIndex;
        public static Transform fountainCheckpoint;

        public static bool[] objFlags = new bool[3];

        public static int entryPoint;
    }
}
