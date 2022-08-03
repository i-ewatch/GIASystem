using DevExpress.XtraEditors;
using GIASystem.Configuration;
using GIASystem.Enums;
using GIASystem.Methods;
using GIASystem.Protocols.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NModbus;
using NModbus.Serial;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;

namespace GIASystem.Views.Setting
{
    public partial class ProtocolSettingControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 0 = 新茂天氣資訊
        /// 1 = GIA天氣資訊
        /// </summary>
        private int WeatherIndex = 0;
        /// <summary>
        /// 設定按鈕視窗
        /// </summary>
        private SettingButtonControl SettingButtonControl { get; set; }
        private SerialPort SerialPort = new SerialPort();
        private GateWaySetting GateWaySetting;
        private IModbusMaster master;
        private ModbusFactory Factory = new ModbusFactory();
        private GateWaySenserID SenserData;
        private GateWayAPI GateWayAPI;
        private List<Taiwan_DistricsSetting> Taiwan_DistricsSetting = new List<Taiwan_DistricsSetting>();
        private List<Data> datas { get; set; } = new List<Data>();
        private GIA_DistricsSetting GIA_DistricsSetting { get; set; }
        public ProtocolSettingControl(SettingButtonControl settingButtonControl, GateWaySetting gateWaySetting, List<Taiwan_DistricsSetting> taiwan_DistricsSetting, GIA_DistricsSetting gIA_DistricsSetting)
        {
            InitializeComponent();
            SettingButtonControl = settingButtonControl;
            GateWaySetting = gateWaySetting;
            Taiwan_DistricsSetting = taiwan_DistricsSetting;
            GIA_DistricsSetting = gIA_DistricsSetting;
            WeatherIndex = GateWaySetting.GateWays[0].WeatherAPIEnumType;
            SenserData = GateWaySetting.GateWays[0].GateWaySenserIDs.SingleOrDefault(g => g.SenserEnumType == 2);
            GateWayAPI = GateWaySetting.GateWays[0].GateWayAPIs.SingleOrDefault(g => g.APIEnumType == 1);
            switch ((GatewayEnumType)GateWaySetting.GateWays[0].GIAGatewayEnumType)
            {
                case GatewayEnumType.ModbusRTU:
                case GatewayEnumType.ModbusTCP:
                    {
                        Protocol_TypecomboBoxEdit.SelectedIndex = GateWaySetting.GateWays[0].GIAGatewayEnumType;
                        ProtocolTabControl.SelectedTabPageIndex = GateWaySetting.GateWays[0].GIAGatewayEnumType;
                    }
                    break;
                case GatewayEnumType.API:
                    {
                        Protocol_TypecomboBoxEdit.SelectedIndex = 2;
                        ProtocolTabControl.SelectedTabPageIndex = 2;
                    }
                    break;
            }
            RS485_COMcomboBoxEdit.Text = GateWaySetting.GateWays[0].ModbusRTULocation;
            TCP_IPtextEdit.Text = GateWaySetting.GateWays[0].ModbusTCPLocation;
            if (SenserData != null)
            {
                RS485_IDtextEdit.Text = SenserData.DeviceID.ToString();
                TCP_IDtextEdit.Text = SenserData.DeviceID.ToString();
            }
            URLtextEdit.Text = GateWaySetting.GateWays[0].GIAAPILocation;
            WeatherItem(WeathercomboBoxEdit);
            WeathercomboBoxEdit.Text = GateWaySetting.GateWays[0].LocationName;
            switch (WeatherIndex)
            {
                case 0:
                    {
                        #region 新茂天氣資訊
                        var DistrictsLoad = Taiwan_DistricsSetting.Where(g => g.CityName == WeathercomboBoxEdit.Text).Select(v => v.AreaList).Single();
                        foreach (var item in DistrictsLoad)
                        {
                            DistrictscomboBoxEdit.Properties.Items.Add(item.AreaName);
                        }
                        #endregion
                    }
                    break;
                case 1:
                    {
                        #region GIA天氣資訊
                        datas = GIA_DistricsSetting.data.Where(g => g.County == WeathercomboBoxEdit.Text).ToList();
                        foreach (var item in datas)
                        {
                            DistrictscomboBoxEdit.Properties.Items.Add(item.alias);
                        }
                        #endregion
                    }
                    break;
            }
            DistrictscomboBoxEdit.Text = null;
            DistrictscomboBoxEdit.Text = GateWaySetting.GateWays[0].DistrictName;
            #region RS485 COM下拉選單
            RS485_COMcomboBoxEdit.ButtonClick += (s, e) =>
            {
                if (RS485_COMcomboBoxEdit.Properties.Items.Count > 0)
                {
                    RS485_COMcomboBoxEdit.Properties.Items.Clear();
                }
                string[] myPorts = SerialPort.GetPortNames(); //取得所有port的名字的方法
                foreach (var Portitem in myPorts)
                {
                    RS485_COMcomboBoxEdit.Properties.Items.Add(Portitem);
                }
                RS485_COMcomboBoxEdit.ShowPopup();
            };
            #endregion
            #region 天氣地區下拉選單
            WeathercomboBoxEdit.SelectedIndexChanged += (s, e) =>
            {
                if (DistrictscomboBoxEdit.Properties.Items.Count > 0)
                {
                    DistrictscomboBoxEdit.Properties.Items.Clear();
                }
                switch (WeatherIndex)
                {
                    case 0:
                        {
                            #region 新茂天氣資訊
                            var Districts = Taiwan_DistricsSetting.Where(g => g.CityName == WeathercomboBoxEdit.Text).Select(v => v.AreaList).Single();
                            foreach (var item in Districts)
                            {
                                DistrictscomboBoxEdit.Properties.Items.Add(item.AreaName);
                            }
                            #endregion
                        }
                        break;
                    case 1:
                        {
                            #region GIA天氣資訊
                            datas = GIA_DistricsSetting.data.Where(g => g.County == WeathercomboBoxEdit.Text).ToList();
                            foreach (var item in datas)
                            {
                                DistrictscomboBoxEdit.Properties.Items.Add(item.alias);
                            }
                            #endregion
                        }
                        break;
                }
                DistrictscomboBoxEdit.Text = null;
            };
            #endregion
            #region 通訊下拉選單
            Protocol_TypecomboBoxEdit.SelectedIndexChanged += (s, e) =>
            {
                ProtocolTabControl.SelectedTabPageIndex = Protocol_TypecomboBoxEdit.SelectedIndex;
            };
            #endregion
            #region 確認按鈕
            btn_OK.Click += (s, e) =>
            {
                switch (Protocol_TypecomboBoxEdit.SelectedIndex)
                {
                    case 0:
                        {
                            if (SenserData == null)
                            {
                                SenserData = new GateWaySenserID();
                                GateWaySetting.GateWays[0].GateWaySenserIDs.Add(SenserData);
                            }
                            GateWaySetting.GateWays[0].GIAGatewayEnumType = 0;
                            GateWaySetting.GateWays[0].ModbusRTULocation = RS485_COMcomboBoxEdit.Text;
                            GateWaySetting.GateWays[0].ModbusRTURate = 9600;
                            SenserData.DeviceID = Convert.ToByte(RS485_IDtextEdit.Text);
                            SenserData.DeviceIndex = 30;
                            SenserData.SenserEnumType = 2;
                        }
                        break;
                    case 1:
                        {
                            if (SenserData == null)
                            {
                                SenserData = new GateWaySenserID();
                                GateWaySetting.GateWays[0].GateWaySenserIDs.Add(SenserData);
                            }
                            GateWaySetting.GateWays[0].GIAGatewayEnumType = 1;
                            GateWaySetting.GateWays[0].ModbusTCPLocation = TCP_IPtextEdit.Text;
                            GateWaySetting.GateWays[0].ModbusTCPRate = 502;
                            SenserData.DeviceID = Convert.ToByte(TCP_IDtextEdit.Text);
                            SenserData.DeviceIndex = 30;
                            SenserData.SenserEnumType = 2;
                        }
                        break;
                    case 2:
                        {
                            if (GateWayAPI == null)
                            {
                                GateWayAPI = new GateWayAPI();
                                GateWaySetting.GateWays[0].GateWayAPIs.Add(GateWayAPI);
                            }
                            GateWaySetting.GateWays[0].GIAGatewayEnumType = 2;
                            GateWaySetting.GateWays[0].GIAAPILocation = URLtextEdit.Text;
                            GateWayAPI.DeviceIndex = 30;
                            GateWayAPI.APIEnumType = 1;
                        }
                        break;
                }
                GateWaySetting.GateWays[0].LocationName = WeathercomboBoxEdit.Text;
                GateWaySetting.GateWays[0].DistrictName = DistrictscomboBoxEdit.Text;
                InitialMethod.Save_GateWay(GateWaySetting);
                SettingButtonControl.FlyoutFlag = false;
                SettingButtonControl.flyout.Close();
                SettingButtonControl.Restart();
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                SettingButtonControl.FlyoutFlag = false;
                SettingButtonControl.flyout.Close();
            };
            #endregion
            #region 通訊測試按鈕
            ProtocolsimpleButton.Click += (s, e) =>
            {
                stateIndicatorComponent1.StateIndex = 0;
                ProtocollabelControl.Text = "-";
                switch (Protocol_TypecomboBoxEdit.SelectedIndex)
                {
                    case 0:
                        {
                            try
                            {
                                #region Rs485通訊功能初始化
                                try
                                {
                                    if (SerialPort == null)
                                    {
                                        SerialPort = new SerialPort();
                                    }
                                    if (!SerialPort.IsOpen)
                                    {
                                        SerialPort.PortName = RS485_COMcomboBoxEdit.Text;
                                        SerialPort.BaudRate = 9600;
                                        SerialPort.DataBits = 8;
                                        SerialPort.StopBits = StopBits.One;
                                        SerialPort.Parity = Parity.None;
                                        SerialPort.Open();
                                    }
                                }
                                catch (ArgumentException)
                                {
                                    Log.Error("通訊埠設定有誤");
                                    stateIndicatorComponent1.StateIndex = 1;
                                    ProtocollabelControl.Text = "通訊失敗";
                                }
                                catch (InvalidOperationException)
                                {
                                    Log.Error("通訊埠被占用");
                                    stateIndicatorComponent1.StateIndex = 1;
                                    ProtocollabelControl.Text = "通訊失敗";
                                }
                                catch (IOException)
                                {
                                    Log.Error("通訊埠無效");
                                    stateIndicatorComponent1.StateIndex = 1;
                                    ProtocollabelControl.Text = "通訊失敗";
                                }
                                catch (Exception ex)
                                {
                                    Log.Error(ex, "通訊埠發生不可預期的錯誤。");
                                    stateIndicatorComponent1.StateIndex = 1;
                                    ProtocollabelControl.Text = "通訊失敗";
                                }
                                master = ModbusFactoryExtensions.CreateRtuMaster(Factory, SerialPort);//建立RTU通訊
                                master.Transport.Retries = 3;
                                master.Transport.ReadTimeout = 500;
                                master.Transport.WriteTimeout = 500;
                                ushort[] value = master.ReadInputRegisters(Convert.ToByte(RS485_IDtextEdit.Text), 0, 17);
                                stateIndicatorComponent1.StateIndex = 3;
                                ProtocollabelControl.Text = "通訊成功";
                                #endregion
                            }
                            catch (Exception)
                            {
                                stateIndicatorComponent1.StateIndex = 1;
                                ProtocollabelControl.Text = "通訊失敗";
                            }
                            SerialPort.Close();
                        }
                        break;
                    case 1:
                        {
                            try
                            {
                                using (TcpClient client = new TcpClient(TCP_IPtextEdit.Text, 502))
                                {
                                    master = Factory.CreateMaster(client);//建立TCP通訊
                                    master.Transport.Retries = 3;
                                    master.Transport.ReadTimeout = 500;
                                    master.Transport.WriteTimeout = 500;
                                    ushort[] value = master.ReadInputRegisters(Convert.ToByte(TCP_IDtextEdit.Text), 0, 17);
                                    stateIndicatorComponent1.StateIndex = 3;
                                    ProtocollabelControl.Text = "通訊成功";
                                }
                            }
                            catch (Exception)
                            {
                                stateIndicatorComponent1.StateIndex = 1;
                                ProtocollabelControl.Text = "通訊失敗";
                            }
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                var option = new RestClientOptions($"{URLtextEdit.Text.Trim()}")
                                {
                                    MaxTimeout = 3000
                                };
                                using (RestClient clinet = new RestClient(option))
                                {
                                    var requsest = new RestRequest("", Method.Get);
                                    var response = clinet.ExecuteGetAsync<GIAAPIValue>(requsest);
                                    response.Wait();
                                    if (response != null)
                                    {
                                        JObject jsondata = JsonConvert.DeserializeObject<JObject>(response.Result.Content);
                                        if (jsondata != null)
                                        {
                                            JArray jsonArraydata = JsonConvert.DeserializeObject<JArray>(jsondata["data"].ToString());
                                            GIAAPIValue Value = JsonConvert.DeserializeObject<GIAAPIValue>(jsonArraydata[0]["sensors"].ToString());
                                            stateIndicatorComponent1.StateIndex = 3;
                                            ProtocollabelControl.Text = "通訊成功";
                                        }
                                        else
                                        {
                                            stateIndicatorComponent1.StateIndex = 1;
                                            ProtocollabelControl.Text = "通訊失敗";
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                stateIndicatorComponent1.StateIndex = 1;
                                ProtocollabelControl.Text = "通訊失敗";
                            }
                        }
                        break;
                }
            };
            #endregion
        }
        #region 天氣項目
        /// <summary>
        /// 天氣項目
        /// </summary>
        /// <param name="comboBox"></param>
        private void WeatherItem(ComboBoxEdit comboBox)
        {
            comboBox.Properties.Items.Add("基隆市");
            comboBox.Properties.Items.Add("臺北市");
            comboBox.Properties.Items.Add("新北市");
            comboBox.Properties.Items.Add("桃園市");
            comboBox.Properties.Items.Add("新竹市");
            comboBox.Properties.Items.Add("新竹縣");
            comboBox.Properties.Items.Add("苗栗縣");
            comboBox.Properties.Items.Add("臺中市");
            comboBox.Properties.Items.Add("彰化縣");
            comboBox.Properties.Items.Add("南投縣");
            comboBox.Properties.Items.Add("雲林縣");
            comboBox.Properties.Items.Add("嘉義市");
            comboBox.Properties.Items.Add("嘉義縣");
            comboBox.Properties.Items.Add("臺南市");
            comboBox.Properties.Items.Add("高雄市");
            comboBox.Properties.Items.Add("屏東縣");
            comboBox.Properties.Items.Add("臺東縣");
            comboBox.Properties.Items.Add("花蓮縣");
            comboBox.Properties.Items.Add("宜蘭縣");
            comboBox.Properties.Items.Add("澎湖縣");
            comboBox.Properties.Items.Add("金門縣");
            comboBox.Properties.Items.Add("連江縣");
        }
        #endregion
    }
}
