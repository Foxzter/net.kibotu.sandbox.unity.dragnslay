﻿using Assets.Src.net.kibotu.sandbox.unity.dragnslay.components.data;
using Assets.Src.net.kibotu.sandbox.unity.dragnslay.game;
using Assets.Src.net.kibotu.sandbox.unity.dragnslay.utility;
using SimpleJson;

namespace Assets.Src.net.kibotu.sandbox.unity.dragnslay.States
{
    class PackageFactory
    {
        // static 
        private PackageFactory()
        {
        }

        private static long packageId = 0;

        public static JsonObject CreateHelloWorldMessage()
        {
            return new JsonObject
            {
                {"message",     "hallo welt"},
                {"username",    "android"},
                {"name",        "message"}
            };
        }

        /// <summary>Sending Units from all sources to target destination.</summary>
        /// 
        /// <param name="ships">All send ships.</param>
        /// <param name="target">Target destination.</param>
        /// <param name="packetId">package id - must be executed in correct order</param>
        /// <param name="scheduleId">Target destination.</param>
        /// 
        /// <returns>Generated JsonObject.</returns>
        public static JsonObject CreateSendUnitsMessage(int target, int[] ships)
        {
            return new JsonObject{
                {"message",     "move-units"},
                {"ships",       ships},
                {"target",      target},
                {"packageId",   ++PackageFactory.packageId},
                {"scheduleId",  Game.ScheduleId()}
            };
        }

        public static JsonObject CreateSpawnMessage(Spawn[] spawns)
        {
            return new JsonObject{
                {"message",     "spawn-units"},
                {"spawns",      spawns},
                {"packageId",   ++PackageFactory.packageId},
                {"scheduleId",  Game.ScheduleId()}
            };
        }

        public static JsonObject CreateJoinQueueMessage(string uid)
        {
            return new JsonObject{
                {"message",     uid},
                {"uid",         uid},
                {"packageId",   ++PackageFactory.packageId},
                {"scheduleId",  Game.ScheduleId()}
            };
        }

        public static JsonObject CreateGameTypeGameMessage(string name, string gameType)
        {
            return new JsonObject{
                {"message",     name},
                {"game-type",   gameType},
                {"packageId",   ++PackageFactory.packageId},
                {"scheduleId",  Game.ScheduleId()}
            };
        }

        public static JsonObject CreateRequestGameData()
        {
            return new JsonObject{
                {"message",     "game-data"},
                {"packageId",   ++PackageFactory.packageId},
                {"scheduleId",  Game.ScheduleId()}
            };
        }
    }
}