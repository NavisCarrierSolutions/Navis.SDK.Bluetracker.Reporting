using System;

namespace Navis.SDK.Bluetracker.Reporting.Enums
{
    [Flags]
    public enum PortActivity
    {
        Undefined = 0,
        Bunkering = 1,
        Loading = 2,
        Unloading = 4,
        EmbarkPassengers = 8,
        DisembarkPassengers = 16,
        CrewChange = 32,
        IdleUnemployed = 64,
        Transit = 128,
        DryDock = 256,
    }
}