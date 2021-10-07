using HarmonyLib;
using Nick;
using System.Linq;
using UnityEngine;

namespace TophIsBlind.Patches
{
    [HarmonyPatch(typeof(GameAgent), "UpdatePost")]
    class GameAgent_UpdateDT
    {
        static void Postfix(GameAgent __instance)
        {
            if (__instance.GameUniqueIdentifier == "char_clay")
            {
                Plugin.playersVisible[__instance.playerIndex] = true;
                return;
            }

            if (!Plugin.runThisFrame)
            {
                Plugin.gameAgents ??= Resources.FindObjectsOfTypeAll<GameAgent>();
                for (int i = 0; i < 4; i++)
                {
                    if (Plugin.gameAgents != null && Plugin.gameAgents.Any(x => x.GameUniqueIdentifier == "char_clay"))
                    {
                        Plugin.isTophHere = true;
                        break;
                    }
                }
                Plugin.runThisFrame = true;
            }

            if (Plugin.isTophHere)
            {
                var renderProxy = __instance.GetComponentInChildren<RendererActiveProxy>();
                if (renderProxy) renderProxy.enabled = __instance.Grounded;
                if (__instance.playerIndex >= 0  && __instance.playerIndex < 4)
                {
                    Plugin.playersVisible[__instance.playerIndex] = __instance.Grounded;
                }
            }
        }
    }
}
