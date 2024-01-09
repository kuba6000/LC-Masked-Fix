using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LC_MIMICFIX.Patches;

namespace LC_MIMICFIX
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class LC_MimicFixMod : BaseUnityPlugin
    {
        private const string ModGUID = "kuba6000.LC_MimicFixMod";
        private const string ModName = "LC_Masked_Fix";
        private const string ModVersion = "0.0.2";
        private readonly Harmony harmony = new Harmony(ModGUID);

        public static LC_MimicFixMod instance;
        internal ManualLogSource log;

        void Awake()
        {
            instance = this;
            log = BepInEx.Logging.Logger.CreateLogSource(ModGUID);

            log.LogInfo("Mimic Fix Awaken!");
            log.LogInfo("V47/48/49 - Fixes red screen overlay / vomit screen after the kill is inturrupted");
            log.LogInfo("V45 - Fixes stuck screen after interrupting the kill animation");
            log.LogInfo("Patching MaskedPlayerEnemy");

            harmony.PatchAll(typeof(LC_MimicFixMod));
            harmony.PatchAll(typeof(MaskedPlayerEnemyPatch));
        }
    }
}
