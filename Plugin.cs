using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using TerminalApi.Classes;
using static TerminalApi.TerminalApi;

namespace TerminalMoney
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("atomic.terminalapi", MinimumDependencyVersion: "1.5.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static bool MoneyCommandActivated = false;
        
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            AddCommand("rich",
                new CommandInfo
                {
                    Title = "Rich",
                    Category = "other",
                    Description = "Adds 1.000.000 Money :D",
                    DisplayTextSupplier = OnMoneyCommand
                });
        }

        private String OnMoneyCommand()
        {
            MoneyCommandActivated = true;
            return "1.000.000 money added \n";
        }
    }
}