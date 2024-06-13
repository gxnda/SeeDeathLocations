using System;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.SeeDeathLocations {
    public class Main {
        public static PlayerDeadBody SaveAndDisplayDeathPosition(On.Celeste.Player.orig_Die orig,
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

        private static DeathPosition GetDeathPosition(Player self) {
            string chapterId = self.level.Session.Area.SID;
            Vector2 position = self.Position;
            return new DeathPosition(chapterId, position);

        }

        private static void SaveDeathPosition(Player self) {
            DeathPosition deathPosition = GetDeathPosition(self);
            // Save to save data

        }

        private static void DisplayDeathPosition(Player self) {
            DeathPosition deathPosition = GetDeathPosition(self);

            Logger.Log(LogLevel.Info, nameof(SeeDeathLocationsModule), $"{deathPosition}");

            // TODO: Display the death position on screen.
        }
    }
}