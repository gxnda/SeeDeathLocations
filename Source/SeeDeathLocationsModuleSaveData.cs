using System.Collections.Generic;

namespace Celeste.Mod.SeeDeathLocations {
    public class SeeDeathLocationsModuleSaveData : EverestModuleSaveData {
        public List<DeathPosition> DeathPositions { get; set; } = new List<DeathPosition>();

    }
}

