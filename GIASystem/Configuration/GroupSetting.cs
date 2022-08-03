using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIASystem.Configuration
{
    /// <summary>
    /// 群組資訊
    /// </summary>
    public class GroupSetting
    {
        /// <summary>
        /// 群組定義名稱
        /// </summary>
        public List<Group> Groups { get; set; } = new List<Group>();
        /// <summary>
        /// 設備群組定義
        /// </summary>
        public List<ElectricDevice> ElectricDevices { get; set; } = new List<ElectricDevice>();
    }
    /// <summary>
    /// 群組定義名稱
    /// </summary>
    public class Group
    {
        /// <summary>
        /// 群組編號
        /// </summary>
        public int GroupIndex { get; set; }
        /// <summary>
        /// 群組名稱
        /// </summary>
        public string GroupName { get; set; }
    }
    public class ElectricDevice
    {
        /// <summary>
        /// 總表旗標
        /// </summary>
        public bool TotalMeterFlag { get; set; }
        /// <summary>
        /// 通道編號
        /// </summary>
        public int GatewayIndex { get; set; }
        /// <summary>
        /// 設備編號
        /// </summary>
        public int DeviceIndex { get; set; }
        /// <summary>
        /// 設備ID
        /// </summary>
        public byte DeviceID { get; set; }
        /// <summary>
        /// 群組編號
        /// </summary>
        public int GroupIndex { get; set; }
        /// <summary>
        /// 迴路
        /// <para> 0 = 第一迴路 </para>
        /// <para> 1 = 第二迴路 </para>
        /// <para> 2 = 第三迴路 </para>
        /// <para> 3 = 第四迴路 </para>
        /// </summary>
        public int LoopEnumType { get; set; }
        /// <summary>
        /// 電表相位
        /// <para> 0 = 單相 </para>
        /// <para> 1 = 三相 </para>
        /// </summary>
        public int PhaseEnumType { get; set; }
        /// <summary>
        /// 電表相位角
        /// <para> 0 = R </para>
        /// <para> 1 = S </para>
        /// <para> 2 = T </para>
        /// </summary>
        public int PhaseAngleEnumType { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DeviceName { get; set; }
    }
}
