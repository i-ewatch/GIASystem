using GIASystem.Configuration;
using MathLibrary;
using NModbus;
using RestSharp;
using System.Collections.Generic;

namespace GIASystem.Protocols
{
    public abstract class AbsProtocol
    {
        /// <summary>
        /// API延遲時間
        /// </summary>
        public int APItime = 3000;
        /// <summary>
        /// API連結物件
        /// </summary>
        public RestClient clinet { get; set; }
        /// <summary>
        /// 標註
        /// </summary>
        public object Tag { get; set; }
        /// <summary>
        /// 地區資訊
        /// </summary>
        public List<Taiwan_DistricsSetting> Taiwan_DistricsSettings { get; set; }
        /// <summary>
        /// 地區資訊
        /// </summary>
        public GIA_DistricsSetting GIA_DistricsSetting { get; set; }
        /// <summary>
        /// 通訊資訊
        /// </summary>
        public GateWaySetting GateWaySetting { get; set; }
        /// <summary>
        /// GIA網址
        /// </summary>
        public string GIALocation { get; set; }
        /// <summary>
        /// GIA電表網址
        /// </summary>
        public string GIAElectricLocation { get; set; }
        /// <summary>
        /// 電表類型
        /// </summary>
        public int ElectricEnumType { get; set; } = -1;
        /// <summary>
        /// 感測器類型
        /// </summary>
        public int SenserEnumType { get; set; } = -1;
        /// <summary>
        /// API類型
        /// </summary>
        public int APIEnumType { get; set; } = -1;
        /// <summary>
        /// 0 = 新茂天氣資訊
        /// 1 = GIA天氣資訊
        /// </summary>
        public int WeatherIndex = 0;
        /// <summary>
        /// 連線旗標
        /// </summary>
        public bool ConnectFlag { get; set; }
        /// <summary>
        /// 通訊編號
        /// </summary>
        public int GatewayIndex { get; set; }
        /// <summary>
        /// 設備編號
        /// </summary>
        public int DeviceIndex { get; set; }
        /// <summary>
        /// 數學公式方法
        /// </summary>
        public MathClass MathClass { get; set; } = new MathClass();
        /// <summary>
        /// 設備ID
        /// </summary>
        public byte ID { get; set; }
        /// <summary>
        /// 資料讀取(Modbus)
        /// </summary>
        /// <param name="master"></param>
        public abstract void DataReader(IModbusMaster master);
        /// <summary>
        /// 資料讀取(API)
        /// </summary>
        public abstract void DataAPIReader();
    }
}
