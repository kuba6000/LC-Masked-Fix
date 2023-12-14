using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_MIMICFIX.Patches
{
    [HarmonyPatch(typeof(MaskedPlayerEnemy))]
    internal class MaskedPlayerEnemyPatch
    {
        [HarmonyPatch(nameof(MaskedPlayerEnemy.CancelSpecialAnimationWithPlayer))]
        [HarmonyPrefix]
        static bool CancelSpecialAnimationWithPlayerPatch(MaskedPlayerEnemy __instance)
        {
            if (__instance.inSpecialAnimationWithPlayer == GameNetworkManager.Instance.localPlayerController)
            {
                LC_MimicFixMod.instance.log.LogInfo("Removing biohazardDamage animation");
                HUDManager.Instance.HUDAnimator.SetBool("biohazardDamage", value: false);
                HUDManager.Instance.HideHUD(true);
                HUDManager.Instance.HideHUD(false);
            }
            LC_MimicFixMod.instance.log.LogInfo("Directly finishing kill animation");
            __instance.FinishKillAnimation();
            return false; // Do not execute original code
        }

    }
}
