using DevExpress.Utils;
using DevExpress.XtraEditors;
using GIASystem.Components;
using GIASystem.Configuration;
using GIASystem.Enums;
using GIASystem.Methods;
using GIASystem.Protocols;
using GIASystem.Views;
using GIASystem.Views.ElectricViews;
using GIASystem.Views.GIAViews;
using GIASystem.Views.Setting;
using GIASystem.Views.WeathreViews;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GIASystem
{
    public partial class Horizontal_ElectricForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        public string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        #region 泡泡視窗
        /// <summary>
        /// 設定泡泡視窗
        /// </summary>
        public FlyoutPanel SettingflyoutPanel;
        /// <summary>
        /// 錯誤泡泡視窗
        /// </summary>
        public FlyoutPanel ErrorflyoutPanel;
        #endregion
        #region JSON資訊
        public GIA_DistricsSetting GIA_DistricsSetting { get; set; }
        /// <summary>
        /// 群組資訊
        /// </summary>
        public GroupSetting GroupSetting { get; set; }
        /// <summary>
        /// 設備通訊設定
        /// </summary>
        public GateWaySetting GateWaySetting { get; set; }
        /// <summary>
        /// 跑馬燈設定
        /// </summary>
        public MarqueeSetting MarqueeSetting { get; set; }
        /// <summary>
        /// 台灣縣市區設定
        /// </summary>
        public List<Taiwan_DistricsSetting> Taiwan_DistricsSetting { get; set; } = new List<Taiwan_DistricsSetting>();
        /// <summary>
        /// 資料庫連接設定
        /// </summary>
        public SqlDBSetting SqlDBSetting { get; set; }
        /// <summary>
        /// 畫面資訊
        /// </summary>
        public GIAScreenMediaSetting ScreenMediaSetting { get; set; }
        /// <summary>
        /// 影片資訊
        /// </summary>
        public MediaPlaySetting MediaPlaySetting { get; set; }
        #endregion
        #region 方法
        /// <summary>
        /// 資料庫方法
        /// </summary>
        private SqlMethod SqlMethod { get; set; }
        #endregion
        #region 通訊
        /// <summary>
        /// 通訊類型
        /// </summary>
        private GatewayEnumType GatewayEnumType { get; set; }
        /// <summary>
        /// 總通訊數值
        /// </summary>
        private List<AbsProtocol> AbsProtocols { get; set; } = new List<AbsProtocol>();
        /// <summary>
        /// 總通訊物件
        /// </summary>
        private List<Field4Component> Field4Components { get; set; } = new List<Field4Component>();

        /// <summary>
        /// 紀錄物件
        /// </summary>
        private List<Field4Component> RecordComponents { get; set; } = new List<Field4Component>();
        #endregion
        #region 畫面
        /// <summary>
        /// 跑馬燈
        /// </summary>
        public MarqueeControl MarqueeControl { get; set; }
        /// <summary>
        /// 影片
        /// </summary>
        public VideoControl VideoControl { get; set; }
        /// <summary>
        /// 天氣資訊
        /// </summary>
        public Horizontal_WeatherControl Horizontal_WeatherControl { get; set; }
        /// <summary>
        /// 感測器畫面
        /// </summary>
        public Horizontal_GIAScreenControl Horizontal_GIAScreenControl { get; set; }
        /// <summary>
        /// 電力資訊化面
        /// </summary>
        public Horizontal_ElectricScreenControl Horizontal_ElectricScreenControl { get; set; }
        /// <summary>
        /// GIA電力資訊化面
        /// </summary>
        public Horizontal_GIAElectricScreenControl Horizontal_GIAElectricScreenControl { get; set; }
        /// <summary>
        /// 設定按鈕
        /// </summary>
        public SettingButtonControl SettingButtonControl { get; set; }
        #endregion
        public Horizontal_ElectricForm()
        {
            InitializeComponent();
            #region serialog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\log-.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();        //宣告Serilog初始化
            #endregion
            #region Configuration
            GateWaySetting = InitialMethod.GateWayLoad();
            MarqueeSetting = InitialMethod.MarqueeLoad();
            Taiwan_DistricsSetting = InitialMethod.Taiwan_DistricsLoad();
            SqlDBSetting = InitialMethod.SqlDBLoad();
            ScreenMediaSetting = InitialMethod.ScreenMediaLoad();
            GroupSetting = InitialMethod.GroupLoad();
            MediaPlaySetting = InitialMethod.MediaPlayLoad();
            GIA_DistricsSetting = InitialMethod.GIA_DistricsLoad();
            #endregion
            #region Component
            if (GateWaySetting.ControlFlag)//使用通訊
            {
                foreach (var Gateitem in GateWaySetting.GateWays)
                {
                    GatewayEnumType = (GatewayEnumType)Gateitem.ElectricGatewayEnumType; // GIA環境監測器使用
                    switch (GatewayEnumType)
                    {
                        case GatewayEnumType.ModbusRTU:
                            {
                                SerialportComponent component = new SerialportComponent(GateWaySetting, Gateitem, SqlMethod, Taiwan_DistricsSetting, GIA_DistricsSetting);
                                component.MyWorkState = GateWaySetting.ControlFlag;
                                Field4Components.Add(component);
                                AbsProtocols.AddRange(component.AbsProtocols);

                                APIComponent apicomponent = new APIComponent(GateWaySetting, Gateitem, SqlMethod, Taiwan_DistricsSetting, GIA_DistricsSetting);
                                apicomponent.MyWorkState = GateWaySetting.ControlFlag;
                                Field4Components.Add(apicomponent);
                                AbsProtocols.AddRange(apicomponent.AbsProtocols);
                            }
                            break;
                        case GatewayEnumType.ModbusTCP:
                            {
                                TCPComponent component = new TCPComponent(GateWaySetting, Gateitem, SqlMethod, Taiwan_DistricsSetting, GIA_DistricsSetting);
                                component.MyWorkState = GateWaySetting.ControlFlag;
                                Field4Components.Add(component);
                                AbsProtocols.AddRange(component.AbsProtocols);

                                APIComponent apicomponent = new APIComponent(GateWaySetting, Gateitem, SqlMethod, Taiwan_DistricsSetting, GIA_DistricsSetting);
                                apicomponent.MyWorkState = GateWaySetting.ControlFlag;
                                Field4Components.Add(apicomponent);
                                AbsProtocols.AddRange(apicomponent.AbsProtocols);
                            }
                            break;
                        case GatewayEnumType.API:
                            {
                                APIComponent component = new APIComponent(GateWaySetting, Gateitem, SqlMethod, Taiwan_DistricsSetting, GIA_DistricsSetting);
                                component.MyWorkState = GateWaySetting.ControlFlag;
                                Field4Components.Add(component);
                                AbsProtocols.AddRange(component.AbsProtocols);
                            }
                            break;
                    }
                }
            }
            #endregion
            #region 資料庫
            if (GateWaySetting.RecordFlag & GateWaySetting.ControlFlag & GateWaySetting.ModeIndex == 1 & GateWaySetting.GateWays[0].ElectricGatewayEnumType != 2)//使用紀錄
            {
                SqlMethod = new SqlMethod() { setting = SqlDBSetting };
                SqlMethod.SQLConnect();
                SqlMethod.Insert_ElectricConfig(GroupSetting, GateWaySetting.GateWays);//電表基本資訊
                SqlMethod.Insert_SenserConfig(GateWaySetting.GateWays);//感測器基本資訊
                if (SqlMethod.Check_Datebase())
                {
                    RecordComponent component = new RecordComponent(AbsProtocols, GroupSetting) { SqlMethod = SqlMethod };
                    component.MyWorkState = GateWaySetting.RecordFlag;
                    RecordComponents.Add(component);
                }
            }
            #endregion
            Change_BackgroundImage();
            #region Views
            MarqueeControl = new MarqueeControl(MarqueeSetting, ScreenMediaSetting, new Point(1921, 13)) { Dock = DockStyle.Fill, Parent = MarqueepanelControl };
            VideoControl = new VideoControl(MediaPlaySetting) { Dock = DockStyle.Fill, Parent = PicturepanelControl };
            WeatherpanelControl.Parent = pictureEdit1;
            foreach (var GateWay in GateWaySetting.GateWays)
            {
                foreach (var item in GateWay.GateWaySenserIDs)
                {
                    SenserEnumType SenserEnumType = (SenserEnumType)item.SenserEnumType;
                    switch (SenserEnumType)
                    {
                        case Enums.SenserEnumType.BlackSenser:
                            break;
                        case Enums.SenserEnumType.WhiteSenser:
                            break;
                        case Enums.SenserEnumType.GIA:
                            {
                                if (GateWay.GIAGatewayEnumType != 2)
                                {
                                    Horizontal_GIAScreenControl = new Horizontal_GIAScreenControl(GateWay, Taiwan_DistricsSetting, ScreenMediaSetting, AbsProtocols) { Dock = DockStyle.Fill, Parent = SenserpanelControl };
                                }
                            }
                            break;
                    }
                }
                foreach (var item in GateWay.GateWayAPIs)
                {
                    APIEnumType APIEnumType = (APIEnumType)item.APIEnumType;
                    switch (APIEnumType)
                    {
                        case Enums.APIEnumType.WeatherAPI:
                            {
                                Horizontal_WeatherControl = new Horizontal_WeatherControl(GateWay, Taiwan_DistricsSetting, item, AbsProtocols, GIA_DistricsSetting) { Dock = DockStyle.Fill, Parent = WeatherpanelControl };
                            }
                            break;
                        case Enums.APIEnumType.GIAAPI:
                            {
                                if (GateWay.GIAGatewayEnumType == 2)
                                {
                                    Horizontal_GIAScreenControl = new Horizontal_GIAScreenControl(GateWay, Taiwan_DistricsSetting, ScreenMediaSetting, AbsProtocols) { Dock = DockStyle.Fill, Parent = SenserpanelControl };
                                }
                            }
                            break;
                    }
                }
                if (GateWay.ElectricGatewayEnumType == 2)
                {
                    Horizontal_GIAElectricScreenControl = new Horizontal_GIAElectricScreenControl(AbsProtocols, GroupSetting) { Dock = DockStyle.Fill, Parent = OtherpanelControl };
                }
                else
                {
                    Horizontal_ElectricScreenControl = new Horizontal_ElectricScreenControl(SqlMethod, GroupSetting, GateWaySetting) { Dock = DockStyle.Fill, Parent = OtherpanelControl };
                }
            }
            OtherpanelControl.Parent = pictureEdit1;
            OtherpanelControl.Location = new Point(163, 840);
            SettingButtonControl = new SettingButtonControl(null, this, null);
            #endregion
            #region 設定按鈕顯示
            SettingpanelControl.MouseHover += (s, e) =>
            {
                SettingflyoutPanel = new FlyoutPanel()
                {
                    OwnerControl = this,
                    Size = new Size(1920, 62)
                };
                SettingflyoutPanel.Controls.Add(SettingButtonControl);
                SettingflyoutPanel.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Top;
                SettingflyoutPanel.Options.CloseOnOuterClick = true;
                SettingflyoutPanel.OptionsButtonPanel.ShowButtonPanel = true;
                SettingflyoutPanel.ShowPopup();
            };
            #endregion
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
        #region 背景切換
        /// <summary>
        /// 背景切換
        /// </summary>
        public void Change_BackgroundImage()
        {
            if (File.Exists($"{ScreenMediaSetting.LogoPath}"))
            {
                pictureEdit1.Image = Image.FromFile($"{ScreenMediaSetting.LogoPath}");
            }
        }
        #endregion

        #region 通訊錯誤泡泡視窗
        /// <summary>
        /// 通訊錯誤泡泡視窗
        /// </summary>
        public void ComponentFail()
        {
            foreach (var Componentitem in Field4Components)
            {
                foreach (var item in Componentitem.AbsProtocols)
                {
                    if (!item.ConnectFlag)
                    {
                        if (ErrorflyoutPanel == null)
                        {
                            ErrorflyoutPanel = new FlyoutPanel()
                            {
                                OwnerControl = this,
                                Size = new Size(1920, 20)
                            };
                            LabelControl label = new LabelControl() { Size = new Size(1920, 20) };
                            label.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                            label.Appearance.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                            label.Appearance.ForeColor = Color.White;
                            label.Appearance.BackColor = Color.Red;
                            label.AutoSizeMode = LabelAutoSizeMode.None;
                            label.Text = "設備通訊失敗";
                            ErrorflyoutPanel.Controls.Add(label);
                            ErrorflyoutPanel.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Bottom;
                            ErrorflyoutPanel.ShowPopup();
                        }
                        return;
                    }
                }

            }
            if (ErrorflyoutPanel != null)
            {
                ErrorflyoutPanel.HidePopup();
                ErrorflyoutPanel = null;
            }
        }
        #endregion

        #region 畫面變更執行緒
        /// <summary>
        /// 畫面變更執行緒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (VideoControl != null)
            {
                VideoControl.TextChange();
            }
            if (Horizontal_WeatherControl != null)
            {
                Horizontal_WeatherControl.TextChange();
            }
            if (Horizontal_GIAScreenControl != null)
            {
                Horizontal_GIAScreenControl.TextChange();
            }
            if (Horizontal_ElectricScreenControl != null)
            {
                Horizontal_ElectricScreenControl.TextChange();
            }
            if (Horizontal_GIAElectricScreenControl != null)
            {
                Horizontal_GIAElectricScreenControl.TextChange();
            }
            ComponentFail();
        }
        #endregion

        #region 視窗建置後初始位址
        private void Horizontal_ElectricForm_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
        }
        #endregion

        #region 關閉視窗
        public void Horizontal_ElectricForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var Componentitem in Field4Components)
            {
                Componentitem.MyWorkState = false;
            }
            foreach (var item in RecordComponents)
            {
                item.MyWorkState = false;
            }
            MarqueeControl.timer1.Enabled = false;
            timer1.Enabled = false;
            this.Dispose();
        }
        #endregion

        #region 重新啟動
        public void Restart()
        {
            foreach (var Componentitem in Field4Components)
            {
                Componentitem.MyWorkState = false;
            }
            foreach (var item in RecordComponents)
            {
                item.MyWorkState = false;
            }
            MarqueeControl.timer1.Enabled = false;
            timer1.Enabled = false;
            this.Dispose();
        }
        #endregion
    }
}