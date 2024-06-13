using Microsoft.Xna.Framework;

namespace Celeste.Mod.SeeDeathLocations {
    public class Hooks {
        internal static void Load() {
            On.Celeste.Player.Die += Main.SaveAndDisplayDeathPosition;
        }

        internal static void Unload() {
            On.Celeste.Player.Die -= Main.SaveAndDisplayDeathPosition;
        }



    }
}