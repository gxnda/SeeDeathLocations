using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.SeeDeathLocations {
    [Tracked]
    [CustomEntity($"{nameof(SeeDeathLocations)}/DeathPointer")]
    public class DeathPointer : Entity {

        public DeathPointer(EntityData data, Vector2 offset)
            : base(data.Position + offset) {

        }
    }
}