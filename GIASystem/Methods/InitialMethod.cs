using GIASystem.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIASystem.Methods
{
    public class InitialMethod
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        #region 跑馬燈資訊
        /// <summary>
        /// 跑馬燈資訊
        /// </summary>
        /// <returns></returns>
        public static MarqueeSetting MarqueeLoad()
        {
            MarqueeSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Marquee.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<MarqueeSetting>(json);
                }
                else
                {
                    MarqueeSetting Setting = new MarqueeSetting()
                    {
                        MarqueeStr = "跑馬燈測試"
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 跑馬燈資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 跑馬燈資訊-儲存
        /// </summary>
        /// <param name="setting"></param>
        public static void Save_Marquee(MarqueeSetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Marquee.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
        #region 台灣縣市區資訊
        /// <summary>
        /// 台灣縣市區資訊
        /// </summary>
        /// <returns></returns>
        public static List<Taiwan_DistricsSetting> Taiwan_DistricsLoad()
        {
            List<Taiwan_DistricsSetting> setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Taiwan_Districts.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.Default);
                    setting = JsonConvert.DeserializeObject<List<Taiwan_DistricsSetting>>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 台灣縣市區資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 欣寶氣象資訊
        /// </summary>
        /// <returns></returns>
        public static GIA_DistricsSetting GIA_DistricsLoad()
        {
            GIA_DistricsSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\GIA_Districs.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<GIA_DistricsSetting>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GIA 台灣縣市區資訊設定載入錯誤");
            }
            return setting;
        }
        #endregion
        #region 畫面媒體資訊
        /// <summary>
        /// 畫面媒體資訊
        /// </summary>
        /// <returns></returns>
        public static GIAScreenMediaSetting ScreenMediaLoad()
        {
            GIAScreenMediaSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\GIAScreenMedia.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<GIAScreenMediaSetting>(json);
                }
                else
                {
                    List<ScreenSwitch> switches = new List<ScreenSwitch>();
                    for (int Index = 0; Index < 7; Index++)
                    {
                        ScreenSwitch screen = new ScreenSwitch()
                        {
                            ScreenIndex = Index,
                            VisibleFlag1 = false,
                            SenserTypeEnum1 = 0,
                            VisibleFlag2 = false,
                            SenserTypeEnum2 = 0
                        };
                        switches.Add(screen);
                    }
                    GIAScreenMediaSetting Setting = new GIAScreenMediaSetting()
                    {
                        BigSenserPanelRGB = "255,255,255",
                        BigSenserForeRGB = "0,0,0",
                        SmallSenserPanelRGB = "255,255,255",
                        SmallSenserForeRGB = "0,0,0",
                        MarqueePanelRGB = "255,255,255",
                        MarqueeForeRGB = "0,0,0",
                        ForeRGB = "0,0,0",
                        ChangePageSec = 5,
                        LogoPath = "",
                        ScreenSwitches = switches
                    };
                    for (int i = 0; i < 12; i++)
                    {
                        Setting.AlarmValue[i] = 0;
                        Setting.AlarmForeRGB[i] = "0,0,0";
                    }
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 畫面媒體資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 畫面媒體資訊-儲存
        /// </summary>
        /// <param name="setting"></param>
        public static void Save_ScreenMedia(GIAScreenMediaSetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\GIAScreenMedia.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
        #region 影片資訊
        /// <summary>
        /// 影片資訊
        /// </summary>
        /// <returns></returns>
        public static MediaPlaySetting MediaPlayLoad()
        {
            MediaPlaySetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\MediaPlay.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<MediaPlaySetting>(json);
                }
                else
                {
                    MediaPlaySetting Setting = new MediaPlaySetting()
                    {
                        VideoPath = "",
                        PicturePath = ""
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 影片資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 跑馬燈資訊-儲存
        /// </summary>
        /// <param name="setting"></param>
        public static void Save_MediaPlay(MediaPlaySetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\MediaPlay.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
        #region 感測器名稱資訊
        /// <summary>
        /// 感測器名稱資訊
        /// </summary>
        /// <returns></returns>
        public static SenserNameSetting SenserNameLoad()
        {
            SenserNameSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\SenserName.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<SenserNameSetting>(json);
                }
                else
                {
                    SenserNameSetting Setting = new SenserNameSetting()
                    {
                        AirQuality = "室內指數",
                        PM25 = "細懸浮微粒",
                        PM10 = "懸浮微粒",
                        CO2 = "二氧化碳",
                        TVOC = "揮發物質",
                        Humidity = "濕度",
                        Temperature = "溫度",
                        HCHO = "甲醛",
                        O3 = "臭氧",
                        CO = "一氧化碳",
                        Mold = "黴菌指數",
                        PM1 = "超細微粒",
                        PH = "氫離子",
                        Chlorine = "氯氣",
                        TEMP1 = "感測器溫度"
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 感測器名稱資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 感測器名稱資訊-儲存
        /// </summary>
        /// <param name="setting"></param>
        public static void Save_SenserName(SenserNameSetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\SenserName.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
        #region 資料庫資訊
        public static SqlDBSetting SqlDBLoad()
        {
            SqlDBSetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\SqlDB.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<SqlDBSetting>(json);
                }
                else
                {
                    SqlDBSetting Setting = new SqlDBSetting()
                    {
                        DataSource = "127.0.0.1",
                        InitialCatalog = "emsdb",
                        UserID = "root",
                        Password = "1234",
                        ElectricMeterPriceFlag = false
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " SQLDB資訊設定載入錯誤");
            }
            return setting;
        }
        #endregion
        #region 設備通訊資訊
        /// <summary>
        /// 設備通訊資訊
        /// </summary>
        /// <returns></returns>
        public static GateWaySetting GateWayLoad()
        {
            GateWaySetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\GateWay.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<GateWaySetting>(json);
                }
                else
                {
                    GateWayElectricID gateWayElectricID = new GateWayElectricID()
                    {
                        DeviceID = 1,
                        ElectricEnumType = 0,
                        DeviceName = "電表1"
                    };
                    GateWaySenserID gateWaySenserID = new GateWaySenserID()
                    {
                        DeviceIndex = 1,
                        DeviceID = 1,
                        SenserEnumType = 0,
                        DeviceName = "環境感測器1"
                    };
                    GateWayAPI gateWayAPI = new GateWayAPI()
                    {

                    };
                    GateWay gateWay = new GateWay()
                    {
                        GatewayIndex = 0,
                        ModbusRTULocation = "COM4",
                        ModbusRTURate = 9600,
                        ModbusTCPLocation = "127.0.0.1",
                        ModbusTCPRate = 502,
                        GIAAPILocation = "欣寶感測器網址",
                        WeatherAPIEnumType = 1,
                        WeatherAPILocation = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?",
                        LocationName = "臺北市",
                        DistrictName = "中正區",
                        GIAGatewayEnumType = 1,
                        ElectricGatewayEnumType = 0,
                        GatewayName = "通道名稱1"
                    };
                    gateWay.GateWaySenserIDs.Add(gateWaySenserID);
                    gateWay.GateWayElectricIDs.Add(gateWayElectricID);
                    gateWay.GateWayAPIs.Add(gateWayAPI);
                    GateWaySetting Setting = new GateWaySetting()
                    {
                        ModeIndex = 0,
                        ControlFlag = true,
                        RecordFlag = true,
                    };
                    Setting.GateWays.Add(gateWay);
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 設備通訊資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 設備通訊資訊-儲存
        /// </summary>
        /// <param name="setting"></param>
        public static void Save_GateWay(GateWaySetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\GateWay.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
        #region 群組資訊
        /// <summary>
        /// 群組資訊
        /// </summary>
        /// <returns></returns>
        public static GroupSetting GroupLoad()
        {
            GroupSetting setting = new GroupSetting();
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Group.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<GroupSetting>(json);
                }
                else
                {
                    GroupSetting Setting = new GroupSetting()
                    {
                        Groups =
                        {
                            new Group()
                            {
                                GroupIndex = 0,
                                GroupName = "不使用"
                            }
                        },
                        ElectricDevices =
                        {
                            new ElectricDevice()
                            {
                                TotalMeterFlag = false,
                                GatewayIndex = 0,
                                DeviceID = 1,
                                DeviceIndex= 0,
                                GroupIndex = 0,
                                PhaseEnumType=0,
                                LoopEnumType = 0,
                                PhaseAngleEnumType=0,
                                DeviceName="電表區域名稱"
                            }
                        }
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "群組資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 群組資訊-儲存
        /// </summary>
        /// <param name="setting"></param>
        public static void Save_Group(GroupSetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Group.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
        #endregion
    }
}
