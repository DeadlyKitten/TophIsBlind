using BepInEx;
using HarmonyLib;
using Nick;
using System.Reflection;

namespace TophIsBlind
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static bool runThisFrame;
        public static bool isTophHere;
        public static GameAgent[] gameAgents;
        public static bool[] playersVisible = new bool[4];

        void Awake()
        {
            var harmony = new Harmony("com.steven.nasb.bluepatrick");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        void LateUpdate()
        {
            runThisFrame = false;
            isTophHere = false;
            gameAgents = null;
            playersVisible = new bool[] { false, false, false, false };
        }
    }
}
