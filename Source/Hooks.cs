using System;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.SeeDeathLocations {
    public class Hooks {
        internal static void Load() {
            On.Celeste.Player.Die += ModSaveAndDisplayDeathCoordinates;
        }

        private static PlayerDeadBody ModSaveAndDisplayDeathCoordinates(Celeste.Player.Die orig,
            Vector2 direction, bool evenIfInvincible = false, bool registerDeathInStats = true) {
            // Do original behaviour afterwards
            float x = self.X;
            float y = self.Y;
            Tuple<float, float> position = new Tuple<float, float>(x, y);
            Logger.Log(position);
            return orig(direction, evenIfInvincible, registerDeathInStats);
        }
    }
}