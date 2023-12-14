using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LC_MIMICFIX.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LC_MIMICFIX
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class LC_MimicFixMod : BaseUnityPlugin
    {
        private const string ModGUID = "kuba6000.LC_MimicFixMod";
        private const string ModName = "LC_Masked_Fix";
        private const string ModVersion = "0.0.1";
        private readonly Harmony harmony = new Harmony(ModGUID);

        public static LC_MimicFixMod instance;
        internal ManualLogSource log;

        void Awake()
        {
            instance = this;
            log = BepInEx.Logging.Logger.CreateLogSource(ModGUID);

            log.LogInfo("Mimic Fix Awaken!");
            log.LogInfo("Patching MaskedPlayerEnemy");

            harmony.PatchAll(typeof(LC_MimicFixMod));
            harmony.PatchAll(typeof(MaskedPlayerEnemyPatch));
        }
    }
}
