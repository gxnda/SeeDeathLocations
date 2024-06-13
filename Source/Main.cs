using Microsoft.Xna.Framework;

namespace Celeste.Mod.SeeDeathLocations {
    public class Main {
        public static PlayerDeadBody SaveAndDisplayDeathPosition(On.Celeste.Player.orig_Die orig,
            Player self,
            Vector2 direction,
            bool evenIfInvincible = false,
            bool registerDeathInStats = true
        ) {

            DeathPosition deathPosition = GetDeathPosition(self);
            SaveDeathPosition(deathPosition);
            DisplayDeathPositions(self);

            // Do original behaviour afterwards
            return orig(self, direction, evenIfInvincible, registerDeathInStats);
        }

        private static DeathPosition GetDeathPosition(Player self) {

            string chapterId = self.level.Session.Area.SID;
            Vector2 position = self.Position;
            return new DeathPosition(chapterId, position);

        }

        private static void SaveDeathPosition(DeathPosition deathPosition) {
            Logger.Log(LogLevel.Info, nameof(SeeDeathLocations), $"Saving death position: {deathPosition.Position}, in chapter: {deathPosition.ChapterId}");
            // Save to save data
            SeeDeathLocationsModule.SaveData.DeathPositions.Add(deathPosition);  // Does save data automatically get saved?

        }

        private static void DisplayDeathPositions(Player self) {
            SeeDeathLocationsModuleSaveData saveData = SeeDeathLocationsModule.SaveData;
            string currentChapterId = self.level.Session.Area.SID;
            // TODO: Display the death position on screen using a sprite
            foreach (DeathPosition deathPosition in saveData.DeathPositions) {
                if ((deathPosition.ChapterId == currentChapterId) & (deathPosition.Position != Vector2.Zero)) {
                    Logger.Log(nameof(SeeDeathLocations),
                        $"Displaying death position: {deathPosition.Position}, in chapter: {deathPosition.ChapterId}");
                }
            }
        }
    }
}