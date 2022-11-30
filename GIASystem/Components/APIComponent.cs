using GIASystem.Configuration;
using GIASystem.Enums;
using GIASystem.Methods;
using GIASystem.Protocols.API;
using NModbus;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GIASystem.Components
{
    public partial class APIComponent : Field4Component
    {
        public APIComponent(GateWaySetting gateWaySetting, GateWay gateWay, SqlMethod sqlMethod, List<Taiwan_DistricsSetting> taiwan_DistricsSettings, GIA_DistricsSetting gIA_DistricsSetting)
        {
            InitializeComponent();
            Taiwan_DistricsSettings = taiwan_DistricsSettings;
            GateWaySetting = gateWaySetting;
            GateWay = gateWay;
            SqlMethod = sqlMethod;
            GIA_DistricsSetting = gIA_DistricsSetting;
        }

        public APIComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                foreach (var item in GateWay.GateWayAPIs)
                {
                    APIEnumType APIEnumType = (APIEnumType)item.APIEnumType;
                    switch (APIEnumType)
                    {
                        case APIEnumType.WeatherAPI:
                            {
                                WeatherProtocol protocol = new WeatherProtocol() { WeatherIndex = GateWay.WeatherAPIEnumType, GIA_DistricsSetting = GIA_DistricsSetting, Taiwan_DistricsSettings = Taiwan_DistricsSettings, GateWaySetting = GateWaySetting, GatewayIndex = GateWay.GatewayIndex, DeviceIndex = item.DeviceIndex, Tag = "WeatherAPI" };
                                AbsProtocols.Add(protocol);
                            }
                            break;
                        case APIEnumType.GIAAPI:
                            {
                                if (GateWay.GIAGatewayEnumType == 2)
                                {
                                    GIAAPIProtocol APIprotocol = new GIAAPIProtocol() { GateWaySetting = GateWaySetting, GatewayIndex = GateWay.GatewayIndex, DeviceIndex = item.DeviceIndex, APIEnumType = 1, GIALocation = GateWay.GIAAPILocation, Tag = "GIAAPI" };
                                    AbsProtocols.Add(APIprotocol);
                                }
                            }
                            break;
                        case APIEnumType.ElectricAPI:
                            {
                                if (GateWaySetting.ModeIndex == 1 && GateWay.ElectricGatewayEnumType == 2)
                                {
                                    GIAElectricProtocol APIprotocol = new GIAElectricProtocol() { GateWaySetting = GateWaySetting, GatewayIndex = GateWay.GatewayIndex, DeviceIndex = item.DeviceIndex, APIEnumType = 1, GIAElectricLocation = GateWay.GIAElectricLocation, Tag = "GIAElectricAPI" };
                                    AbsProtocols.Add(APIprotocol);
                                }
                            }
                            break;
                    }
                }
                ReadThread = new Thread(Analysis);
                ReadThread.Priority = ThreadPriority.Highest;
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                if (timeSpan.TotalSeconds >= 10)
                {
                    foreach (var item in AbsProtocols)
                    {
                        try
                        {
                            if (item.Tag.ToString() == "WeatherAPI")
                            {
                                TimeSpan Weatherspan = DateTime.Now.Subtract(WeatherReadTime);
                                if (Weatherspan.Hours >= 1)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        item.DataAPIReader();
                                        Thread.Sleep(10);
                                        if (item.ConnectFlag)
                                        {
                                            WeatherReadTime = DateTime.Now;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                item.DataAPIReader();
                            }
                            Thread.Sleep(10);
                            ReadTime = DateTime.Now;
                        }
                        catch (ThreadAbortException) { }
                        catch (Exception ex)
                        {
                            item.ConnectFlag = false;
                            ReadTime = DateTime.Now;
                            Log.Error(ex, $"通訊失敗");
                        }
                    }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
