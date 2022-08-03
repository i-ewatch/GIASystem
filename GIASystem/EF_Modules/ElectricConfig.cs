﻿namespace GIASystem.EF_Modules
{
    public partial class ElectricConfig
    {
        public bool TotalMeterFlag { get; set; }
        public int GatewayIndex { get; set; }
        public int DeviceIndex { get; set; }
        public int DeviceID { get; set; }
        public int ElectricEnumType { get; set; }
        public int LoopEnumType { get; set; }
        public int PhaseEnumType { get; set; }
        public int PhaseAngleEnumType { get; set; }
        public string DeviceName { get; set; }

    }
}
