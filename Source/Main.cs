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

        private static Tuple<string, Vector2> GetDeathPosition(Player self) {
            string chapterId = self.level.Session.Area.SID;
            Vector2 position = self.Position;
            return new Tuple<string, Vector2>(chapterId, position);

        }

        private static void SaveDeathPosition(Player self) {
            Tuple<string, Vector2> deathPosition = GetDeathPosition(self);
            string chapterId = deathPosition.Item1;
            Vector2 position = deathPosition.Item2;


        }

        private static void DisplayDeathPosition(Player self) {
            Tuple<string, Vector2> deathPosition = GetDeathPosition(self);
            string chapterId = deathPosition.Item1;
            Vector2 position = deathPosition.Item2;
            Logger.Log(LogLevel.Info, nameof(SeeDeathLocationsModule), $"Death at: {position}, in chapter: {chapterId}");
        }
    }
}