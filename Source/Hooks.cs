using Microsoft.Xna.Framework;

namespace Celeste.Mod.SeeDeathLocations {
    public class Hooks {
        internal static void Load() {
            On.Celeste.Player.Die += ModSaveAndDisplayDeathPosition;
        }

        private static PlayerDeadBody ModSaveAndDisplayDeathPosition(
            On.Celeste.Player.orig_Die orig,
            Player self,
            Vector2 direction,
            bool evenIfInvincible = false,
            bool registerDeathInStats = true
        ) {
            DisplayDeathPosition(self);
            SaveDeathPosition(self);

            // Do original behaviour afterwards
            return orig(self, direction, evenIfInvincible, registerDeathInStats);
        }

        private static void SaveDeathPosition(Player self) {
            Logger.Log(nameof(SeeDeathLocations), "Has not been created yet!");
        }

        private static void DisplayDeathPosition(Player self) {
            Logger.Log(nameof(SeeDeathLocations), $"Death at: {self.Position}");
        }
    }
}