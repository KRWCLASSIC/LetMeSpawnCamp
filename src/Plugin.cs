using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace LetMeSpawnCamp
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            // Initialize Harmony patching
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            Logger.LogInfo("Harmony patches applied.");
        }
    }

    public static class PluginInfo
    {
        public const string PLUGIN_GUID = "krw.mods.letmespawncamp";
        public const string PLUGIN_NAME = "LetMeSpawnCamp";
        public const string PLUGIN_VERSION = "1.0.0";
    }
}
