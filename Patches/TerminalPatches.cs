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
                // Setzt die Credits nur, wenn der Befehl aktiviert wurde
                ___groupCredits = 1000000;
                // Optional: Zustand zurücksetzen, falls einmalige Anwendung gewünscht
                Plugin.MoneyCommandActivated = false;
            }
        }
    }
}