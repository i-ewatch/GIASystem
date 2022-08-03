﻿using System;

namespace GIASystem.EF_Modules
{
    public partial class ElectricTotalPrice
    {
        public string ttime { get; set; }
        public DateTime ttimen { get; set; }
        public int GatewayIndex { get; set; }
        public int DeviceIndex { get; set; }
        public decimal KwhStart1 { get; set; }
        public decimal KwhEnd1 { get; set; }
        public decimal KwhStart2 { get; set; }
        public decimal KwhEnd2 { get; set; }
        public decimal KwhTotal { get; set; }
        public decimal Price { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
