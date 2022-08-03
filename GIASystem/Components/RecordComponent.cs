using GIASystem.Configuration;
using GIASystem.Enums;
using GIASystem.Protocols;
using GIASystem.Protocols.ElectricMeter;
using GIASystem.Protocols.Senser;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace GIASystem.Components
{
    public partial class RecordComponent : Field4Component
    {
        protected GroupSetting GroupSetting { get; set; }
        public RecordComponent(List<AbsProtocol> absProtocols, GroupSetting groupSetting)
        {
            InitializeComponent();
            AbsProtocols = absProtocols;
            GroupSetting = groupSetting;
        }

        public RecordComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                ReadThread = new Thread(SqlRecord);
                ReadThread.Priority = ThreadPriority.Lowest;
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
        public void SqlRecord()
        {
            while (myWorkState)
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                if (timeSpan.TotalSeconds >= 30)
                {
                    try
                    {
                        foreach (var Electricitem in GroupSetting.ElectricDevices)
                        {
                            var item = AbsProtocols.SingleOrDefault(g => g.GatewayIndex == Electricitem.GatewayIndex && g.ID == Electricitem.DeviceID);
                            if (item != null)
                            {
                                if (item.ElectricEnumType != -1)
                                {
                                    if (item.ConnectFlag)
                                    {
                                        ElectricEnumType = (ElectricEnumType)item.ElectricEnumType;
                                        switch (ElectricEnumType)
                                        {
                                            case ElectricEnumType.PA310:
                                                {
                                                    PA310Protocol protocol = new PA310Protocol();
                                                    protocol = (PA310Protocol)item;
                                                    PhaseEnumType PhaseEnumType = (PhaseEnumType)Electricitem.PhaseEnumType;
                                                    switch (PhaseEnumType)
                                                    {
                                                        case Enums.PhaseEnumType.ThreePhase:
                                                            SqlMethod.Insert_ThreePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                        case Enums.PhaseEnumType.SinglePhase:
                                                            SqlMethod.Insert_SinglePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case ElectricEnumType.HC660:
                                                {
                                                    HC6600Protocol protocol = new HC6600Protocol();
                                                    protocol = (HC6600Protocol)item;
                                                    PhaseEnumType PhaseEnumType = (PhaseEnumType)Electricitem.PhaseEnumType;
                                                    switch (PhaseEnumType)
                                                    {
                                                        case Enums.PhaseEnumType.ThreePhase:
                                                            SqlMethod.Insert_ThreePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                        case Enums.PhaseEnumType.SinglePhase:
                                                            SqlMethod.Insert_SinglePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case ElectricEnumType.CPM6:
                                                {
                                                    CPM6Protocol protocol = new CPM6Protocol();
                                                    protocol = (CPM6Protocol)item;
                                                    PhaseEnumType PhaseEnumType = (PhaseEnumType)Electricitem.PhaseEnumType;
                                                    switch (PhaseEnumType)
                                                    {
                                                        case Enums.PhaseEnumType.ThreePhase:
                                                            SqlMethod.Insert_ThreePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                        case Enums.PhaseEnumType.SinglePhase:
                                                            SqlMethod.Insert_SinglePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case ElectricEnumType.PA60:
                                                {
                                                    PA60Protocol protocol = new PA60Protocol();
                                                    protocol = (PA60Protocol)item;
                                                    PhaseEnumType PhaseEnumType = (PhaseEnumType)Electricitem.PhaseEnumType;
                                                    switch (PhaseEnumType)
                                                    {
                                                        case Enums.PhaseEnumType.ThreePhase:
                                                            SqlMethod.Insert_ThreePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                        case Enums.PhaseEnumType.SinglePhase:
                                                            SqlMethod.Insert_SinglePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case ElectricEnumType.ABBM2M:
                                                {
                                                    ABBM2MProtocol protocol = new ABBM2MProtocol();
                                                    protocol = (ABBM2MProtocol)item;
                                                    PhaseEnumType PhaseEnumType = (PhaseEnumType)Electricitem.PhaseEnumType;
                                                    switch (PhaseEnumType)
                                                    {
                                                        case Enums.PhaseEnumType.ThreePhase:
                                                            SqlMethod.Insert_ThreePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                        case Enums.PhaseEnumType.SinglePhase:
                                                            SqlMethod.Insert_SinglePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case ElectricEnumType.PM200:
                                                {
                                                    PM200Protocol protocol = new PM200Protocol();
                                                    protocol = (PM200Protocol)item;
                                                    PhaseEnumType PhaseEnumType = (PhaseEnumType)Electricitem.PhaseEnumType;
                                                    switch (PhaseEnumType)
                                                    {
                                                        case Enums.PhaseEnumType.ThreePhase:
                                                            SqlMethod.Insert_ThreePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                        case Enums.PhaseEnumType.SinglePhase:
                                                            SqlMethod.Insert_SinglePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case ElectricEnumType.TWCPM4:
                                                {
                                                    TWCPM4Protocol protocol = new TWCPM4Protocol();
                                                    protocol = (TWCPM4Protocol)item;
                                                    PhaseEnumType PhaseEnumType = (PhaseEnumType)Electricitem.PhaseEnumType;
                                                    switch (PhaseEnumType)
                                                    {
                                                        case Enums.PhaseEnumType.ThreePhase:
                                                            SqlMethod.Insert_ThreePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                        case Enums.PhaseEnumType.SinglePhase:
                                                            SqlMethod.Insert_SinglePhaseElectricMeter(protocol, Electricitem);
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var item in AbsProtocols)
                        {
                            if (item.ConnectFlag)
                            {
                                if (item.SenserEnumType != -1)
                                {
                                    SenserEnumType = (SenserEnumType)item.SenserEnumType;
                                    switch (SenserEnumType)
                                    {
                                        case SenserEnumType.BlackSenser:
                                        case SenserEnumType.WhiteSenser:
                                            {
                                                SenserData data = (SenserData)item;
                                                SqlMethod.Insert_Senser(data);
                                            }
                                            break;
                                        case SenserEnumType.GIA:
                                            break;
                                    }
                                }
                                else if (item.APIEnumType != -1)
                                {
                                    APIEnumType aPIEnumType = (APIEnumType)item.APIEnumType;
                                    switch (aPIEnumType)
                                    {
                                        case APIEnumType.WeatherAPI:
                                            break;
                                        case APIEnumType.GIAAPI:
                                            break;
                                    }
                                }
                            }
                        }
                        ReadTime = DateTime.Now;
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex) { Log.Error(ex, "資料庫紀錄失敗"); }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
