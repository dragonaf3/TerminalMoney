using HarmonyLib;

namespace TerminalMoney.Patches
{
    [HarmonyPatch(typeof(Terminal), nameof(Terminal.RunTerminalEvents))]
    public static class TerminalPatches
    {
        [HarmonyPostfix]
        static void TerminalMoney(ref int ___groupCredits)
        {
            if (Plugin.MoneyCommandActivated)
            {
                ___groupCredits = 1000000;
                Plugin.MoneyCommandActivated = false;
            }
        }
    }
}