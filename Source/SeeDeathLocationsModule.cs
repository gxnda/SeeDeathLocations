using System;

namespace Celeste.Mod.SeeDeathLocations;

public class SeeDeathLocationsModule : EverestModule {
    public SeeDeathLocationsModule() {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(SeeDeathLocationsModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(SeeDeathLocationsModule), LogLevel.Info);
#endif
    }

    public static SeeDeathLocationsModule Instance { get; private set; }

    public override Type SettingsType => typeof(SeeDeathLocationsModuleSettings);
    public static SeeDeathLocationsModuleSettings Settings => (SeeDeathLocationsModuleSettings)Instance._Settings;

    public override Type SessionType => typeof(SeeDeathLocationsModuleSession);
    public static SeeDeathLocationsModuleSession Session => (SeeDeathLocationsModuleSession)Instance._Session;

    public override Type SaveDataType => typeof(SeeDeathLocationsModuleSaveData);
    public static SeeDeathLocationsModuleSaveData SaveData => (SeeDeathLocationsModuleSaveData)Instance._SaveData;

    public override void Load() {
        Logger.SetLogLevel(nameof(SeeDeathLocationsModule), LogLevel.Verbose);
        Logger.Log(LogLevel.Info, nameof(SeeDeathLocationsModule), "Loading hooks.");
        Hooks.Load();
    }

    public override void Unload() {
        // TODO: unapply any hooks applied in Load()
    }

    public static void SaveAndDisplayCoordinatesThenDie() {
    }
}