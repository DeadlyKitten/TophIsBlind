using HarmonyLib;
using Nick;

namespace TophIsBlind.Patches
{
    [HarmonyPatch(typeof(PlayerIndicatorUI), "SetVisible")]
    class PlayerIndicatorUI_SetVisible
    {
        static void Prefix(PlayerIndicatorUI __instance, int ___id, ref bool v)
        {
            if (!v) return;

            if (!Plugin.playersVisible[___id - 1]) v = false;
        }
    }
}
