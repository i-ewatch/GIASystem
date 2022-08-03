using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIASystem.Configuration
{
    public class GateWaySetting
    {
        /// <summary>
        /// 模式選擇
        /// </summary>
        public int ModeIndex { get; set; }
        /// <summary>
        /// 通訊旗標
        /// <para>True = 使用通訊</para>
        /// <para>False = 不使用通訊</para>
        /// </summary>
        public bool ControlFlag { get; set; }
        /// <summary>
        /// 紀錄旗標
        /// <para>True = 使用紀錄</para>
        /// <para>False = 不使用紀錄</para>
        /// </summary>
        public bool RecordFlag { get; set; }
        /// <summary>
        /// 通訊通道
        /// </summary>
        public List<GateWay> GateWays { get; set; } = new List<GateWay>();
    }
    /// <summary>
    /// 通訊通道
    /// </summary>
    public class GateWay
    {
        /// <summary>
        /// Gateway編號
        /// </summary>
        public int GatewayIndex { get; set; }
        /// <summary>
        /// RTU COM位址
        /// </summary>
        public string ModbusRTULocation { get; set; }
        /// <summary>
        /// RTU Rate
        /// </summary>
        public int ModbusRTURate { get; set; }
        /// <summary>
        /// TCP IP位址
        /// </summary>
        public string ModbusTCPLocation { get; set; }
        /// <summary>
        /// TCP Port號
        /// </summary>
        public int ModbusTCPRate { get; set; }
        /// <summary>
        /// GIA API網址
        /// </summary>
        public string GIAAPILocation { get; set; }
        /// <summary>
        /// 0 = 新茂氣象資訊API
        /// 1 = 欣寶氣象資訊API
        /// </summary>
        public int WeatherAPIEnumType { get; set; }
        /// <summary>
        /// 氣象API網址
        /// </summary>
        public string WeatherAPILocation { get; set; }
        /// <summary>
        /// 臺灣各縣市名稱
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// 地區名稱
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// GIA設備通訊類型
        /// <para>0 = Modbus RTU</para>
        /// <para>1 = Modbus TCP</para>
        /// <para>2 = API</para>
        /// </summary>
        public int GIAGatewayEnumType { get; set; }
        /// <summary>
        /// 電表設備通訊類型
        /// <para>0 = Modbus RTU</para>
        /// <para>1 = Modbus TCP</para>
        /// <para>2 = API</para>
        /// </summary>
        public int ElectricGatewayEnumType { get; set; }
        /// <summary>
        /// 環境感測器ID
        /// </summary>
        public List<GateWaySenserID> GateWaySenserIDs { get; set; } = new List<GateWaySenserID>();
        /// <summary>
        /// 電表設備ID
        /// </summary>
        public List<GateWayElectricID> GateWayElectricIDs { get; set; } = new List<GateWayElectricID>();
        /// <summary>
        /// API資訊
        /// </summary>
        public List<GateWayAPI> GateWayAPIs { get; set; } = new List<GateWayAPI>();
        /// <summary>
        /// 通道名稱
        /// </summary>
        public string GatewayName { get; set; }
    }
    /// <summary>
    /// 環境感測器ID
    /// </summary>
    public class GateWaySenserID
    {
        /// <summary>
        /// 設備編號
        /// </summary>
        public int DeviceIndex { get; set; }
        /// <summary>
        /// 設備ID
        /// </summary>
        public byte DeviceID { get; set; }
        /// <summary>
        /// 設備類型
        /// <para> 0 = BlackSenser </para>
        /// <para> 1 = WhiteSenser </para>
        /// <para> 2 = GAISenser  </para>
        /// </summary>
        public int SenserEnumType { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DeviceName { get; set; }
    }
    /// <summary>
    /// 電表設備ID
    /// </summary>
    public class GateWayElectricID
    {
        /// <summary>
        /// 設備ID
        /// </summary>
        public byte DeviceID { get; set; }
        /// <summary>
        /// 設備類型
        /// <para> 0 = PA310電表 </para>
        /// <para> 1 = HC6600電表 </para>
        /// <para> 2 = SPM6電表 </para>
        /// <para> 3 = PA60多迴路電表 </para>
        /// <para> 4 = ABBM2M電表 </para>
        /// </summary>
        public int ElectricEnumType { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DeviceName { get; set; }
    }

    public class GateWayAPI
    {
        /// <summary>
        /// 設備編號
        /// </summary>
        public int DeviceIndex { get; set; }
        /// <summary>
        /// API類型
        /// <para> 0 = 氣象局API </para>
        /// <para> 1 = GAISenser API </para>
        /// </summary>
        public int APIEnumType { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DeviceName { get; set; }
    }
}
