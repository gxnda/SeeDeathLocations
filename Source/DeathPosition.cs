using Microsoft.Xna.Framework;

namespace Celeste.Mod.SeeDeathLocations {
    public struct DeathPosition {
        public string ChapterId { get; }
        public Vector2 Position { get; }

        public DeathPosition(string chapterId, Vector2 position) {
            ChapterId = chapterId;
            Position = position;
        }

        public void Log() {
            Logger.Log(nameof(SeeDeathLocations), $"Death at: {Position}, in chapter: {ChapterId}");
        }

    }
}