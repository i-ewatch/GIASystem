using GIASystem.Configuration;
using GIASystem.Enums;
using GIASystem.Methods;
using GIASystem.Protocols.API;
using GIASystem.Protocols.Senser;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GIASystem.Views.GIAViews
{
    public partial class Straight_GIASmallControl : Field4UserControl
    {
        /// <summary>
        /// 感測器類型
        /// </summary>
        private GIASenserEnumType GIASenserEnumType { get; set; }
        /// <summary>
        /// senser通訊類型與設備編號
        /// </summary>
        private GateWaySenserID GateWaySenserID { get; set; }
        /// <summary>
        /// API senser通訊類型與設備編號
        /// </summary>
        private GateWayAPI GateWayAPI { get; set; }
        /// <summary>
        /// 顏色改變
        /// </summary>
        private Color NewColor { get; set; }
        public Straight_GIASmallControl(int senserTypeEnum, GateWay gateWay, GateWaySenserID gateWaySenserID, GateWayAPI gateWayAPI, GIAScreenMediaSetting screenMediaSetting, bool screenTransition)
        {
            InitializeComponent();
            GateWay = gateWay;
            GateWaySenserID = gateWaySenserID;
            GateWayAPI = gateWayAPI;
            if (gateWaySenserID != null)
            {
                SenserEnumType = (SenserEnumType)gateWaySenserID.SenserEnumType;
            }
            else if (gateWayAPI != null)
            {
                APIEnumType = (APIEnumType)GateWayAPI.APIEnumType;
            }
            ScreenMediaSetting = screenMediaSetting;
            Change_ScreenColor();//改變畫面顏色
            #region 感測器類型初始化
            SenserNameSetting senserNameSetting = InitialMethod.SenserNameLoad();
            GIASenserEnumType = (GIASenserEnumType)senserTypeEnum;
            switch (GIASenserEnumType)
            {
                case GIASenserEnumType.AirQuality:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示-12.png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示-12.png");
                        }
                        SenserNamelabelControl.Text = $"IAQ Index \r{senserNameSetting.AirQuality}";
                        UnitlabelControl.Visible = false;
                    }
                    break;
                case GIASenserEnumType.PM25:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (4).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (4).png");
                        }
                        SenserNamelabelControl.Text = $"PM2.5 \r{senserNameSetting.PM25}";
                        UnitlabelControl.Text = "µg/m" + "\xb3";
                    }
                    break;
                case GIASenserEnumType.PM10:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (6).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (6).png");
                        }
                        SenserNamelabelControl.Text = $"PM10 \r{senserNameSetting.PM10}";
                        UnitlabelControl.Text = "µg/m" + "\xb3";
                    }
                    break;
                case GIASenserEnumType.CO2:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (3).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (3).png");
                        }
                        SenserNamelabelControl.Text = "CO" + $"\xb2 \r{senserNameSetting.CO2}";
                        UnitlabelControl.Text = "PPM";
                    }
                    break;
                case GIASenserEnumType.TVOC:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (9).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (9).png");
                        }
                        SenserNamelabelControl.Text = $"TVOC \r{senserNameSetting.TVOC}";
                        UnitlabelControl.Text = "PPM";
                    }
                    break;
                case GIASenserEnumType.Humidity:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (2).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (2).png");
                        }
                        SenserNamelabelControl.Text = $"HUMI \r{senserNameSetting.Humidity}";
                        UnitlabelControl.Text = "%";
                    }
                    break;
                case GIASenserEnumType.Temperature:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (1).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (1).png");
                        }
                        SenserNamelabelControl.Text = $"TEMP \r{senserNameSetting.Temperature}";
                        UnitlabelControl.Text = "\xb0" + "C";
                    }
                    break;
                case GIASenserEnumType.HCHO:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (8).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (8).png");
                        }
                        SenserNamelabelControl.Text = $"HCHO \r{senserNameSetting.HCHO}";
                        UnitlabelControl.Text = "PPM";
                    }
                    break;
                case GIASenserEnumType.O3:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示-10.png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示-10.png");
                        }
                        SenserNamelabelControl.Text = "O" + $"\xb3 \r{senserNameSetting.O3}";
                        UnitlabelControl.Text = "PPM";
                    }
                    break;
                case GIASenserEnumType.CO:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (5).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (5).png");
                        }
                        SenserNamelabelControl.Text = $"CO \r{senserNameSetting.CO}";
                        UnitlabelControl.Text = "PPM";
                    }
                    break;
                case GIASenserEnumType.Mold:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示 (7).png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示 (7).png");
                        }
                        SenserNamelabelControl.Text = $"FUNGI \r{senserNameSetting.Mold}";
                        UnitlabelControl.Text = "";
                    }
                    break;
                case GIASenserEnumType.PM1:
                    {
                        if (File.Exists($"{MyWorkPath}\\Images\\Sensor 圖示-11.png"))
                        {
                            pictureEdit1.Image = Image.FromFile($"{MyWorkPath}\\Images\\Sensor 圖示-11.png");
                        }
                        SenserNamelabelControl.Text = $"PM1 \r{senserNameSetting.PM1}";
                        UnitlabelControl.Text = "µg/m" + "\xb3";
                    }
                    break;
            }
            #endregion
        }
        #region 改變畫面顏色
        /// <summary>
        /// 改變畫面顏色
        /// </summary>
        public void Change_ScreenColor()
        {
            Rpanel = Convert.ToInt32(ScreenMediaSetting.SmallSenserPanelRGB.Split(',')[0]);
            Gpanel = Convert.ToInt32(ScreenMediaSetting.SmallSenserPanelRGB.Split(',')[1]);
            Bpanel = Convert.ToInt32(ScreenMediaSetting.SmallSenserPanelRGB.Split(',')[2]);
            RFore = Convert.ToInt32(ScreenMediaSetting.SmallSenserForeRGB.Split(',')[0]);
            GFore = Convert.ToInt32(ScreenMediaSetting.SmallSenserForeRGB.Split(',')[1]);
            BFore = Convert.ToInt32(ScreenMediaSetting.SmallSenserForeRGB.Split(',')[2]);
            ScreenpanelControl.Appearance.BackColor = Color.FromArgb(Rpanel, Gpanel, Bpanel);
            SenserNamelabelControl.Appearance.ForeColor = Color.FromArgb(RFore, GFore, BFore);
            ValuelabelControl.Appearance.ForeColor = Color.FromArgb(RFore, GFore, BFore);
            UnitlabelControl.Appearance.ForeColor = Color.FromArgb(RFore, GFore, BFore);
            NewColor = Color.FromArgb(Rpanel, Gpanel, Bpanel);
            LeftpictureBox.Refresh();
            RightpictureBox.Refresh();
        }
        #endregion

        #region 圖片顏色變更
        private void LeftpictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //using (Bitmap bmp = new Bitmap($"{MyWorkPath}\\Images\\8x266_左.png"))
            Bitmap bmp = (Bitmap)imageCollection1.Images["8x266_左.png"];
            {
                ColorMap[] colorMaps = new ColorMap[1];
                colorMaps[0] = new ColorMap();
                colorMaps[0].OldColor = Color.FromArgb(30, 180, 145);
                colorMaps[0].NewColor = NewColor;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetRemapTable(colorMaps);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attributes);
            }
        }

        private void RightpictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //using (Bitmap bmp = new Bitmap($"{MyWorkPath}\\Images\\8x266_右.png"))
            Bitmap bmp = (Bitmap)imageCollection1.Images["8x266_右.png"];
            {
                ColorMap[] colorMaps = new ColorMap[1];
                colorMaps[0] = new ColorMap();
                colorMaps[0].OldColor = Color.FromArgb(30, 180, 145);
                colorMaps[0].NewColor = NewColor;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetRemapTable(colorMaps);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attributes);
            }
        }
        #endregion

        #region 顯示變更
        public override void TextChange()
        {
            switch ((GatewayEnumType)GateWay.GIAGatewayEnumType)
            {
                case GatewayEnumType.ModbusRTU:
                case GatewayEnumType.ModbusTCP:
                    {
                        if (GateWay.GateWaySenserIDs.Count > 0)
                        {
                            var senser = GateWay.GateWaySenserIDs.SingleOrDefault(g => g.SenserEnumType == 2);
                            if (senser != null && GateWaySenserID != null)
                            {
                                var absProtocol = AbsProtocols.SingleOrDefault(g => g.GatewayIndex == GateWay.GatewayIndex & g.DeviceIndex == GateWaySenserID.DeviceIndex);
                                if (absProtocol != null)
                                {
                                    GIAData data = (GIAData)absProtocol;
                                    Serch_Value(data);
                                }
                            }
                        }
                    }
                    break;
                case GatewayEnumType.API:
                    {
                        if (GateWay.GateWayAPIs.Count > 0)
                        {
                            var senser = GateWay.GateWayAPIs.SingleOrDefault(g => g.APIEnumType == 1);
                            if (senser != null && GateWayAPI != null)
                            {
                                var absProtocol = AbsProtocols.SingleOrDefault(g => g.GatewayIndex == GateWay.GatewayIndex & g.DeviceIndex == GateWayAPI.DeviceIndex);
                                if (absProtocol != null)
                                {
                                    GIAAPIData data = (GIAAPIData)absProtocol;
                                    Serch_APIValue(data);
                                }
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

        #region API數值
        /// <summary>
        /// API數值
        /// </summary>
        /// <param name="data">API數值</param>
        private void Serch_APIValue(GIAAPIData data)
        {
            if (data.GIAAPIValue != null)
            {
                if (!ScreenMediaSetting.AlarmFlag)
                {
                    switch (GIASenserEnumType)
                    {
                        case GIASenserEnumType.AirQuality:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.iaq.ToString();
                            }
                            break;
                        case GIASenserEnumType.PM25:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.pm25.ToString();
                            }
                            break;
                        case GIASenserEnumType.PM10:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.pm10.ToString();
                            }
                            break;
                        case GIASenserEnumType.CO2:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.co2.ToString();
                            }
                            break;
                        case GIASenserEnumType.TVOC:
                            {
                                ValuelabelControl.Text = (data.GIAAPIValue.tvoc / 1000).ToString("F2");
                            }
                            break;
                        case GIASenserEnumType.Humidity:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.humidity.ToString("F1");
                            }
                            break;
                        case GIASenserEnumType.Temperature:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.temperature.ToString("F1");
                            }
                            break;
                        case GIASenserEnumType.HCHO:
                            {
                                ValuelabelControl.Text = (data.GIAAPIValue.hcho / 1000).ToString("F2");
                            }
                            break;
                        case GIASenserEnumType.O3:
                            {
                                ValuelabelControl.Text = (data.GIAAPIValue.o3 / 1000).ToString("F2");
                            }
                            break;
                        case GIASenserEnumType.CO:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.co.ToString();
                            }
                            break;
                        case GIASenserEnumType.Mold:
                            {
                                ValuelabelControl.Text = Convert.ToInt32(data.GIAAPIValue.mold).ToString();
                            }
                            break;
                        case GIASenserEnumType.PM1:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.pm1.ToString("F1");
                            }
                            break;
                    }
                }
                else
                {
                    switch (GIASenserEnumType)
                    {
                        case GIASenserEnumType.AirQuality:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.iaq.ToString();
                            }
                            break;
                        case GIASenserEnumType.PM25:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.pm25.ToString();
                            }
                            break;
                        case GIASenserEnumType.PM10:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.pm10.ToString();
                            }
                            break;
                        case GIASenserEnumType.CO2:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.co2.ToString();
                            }
                            break;
                        case GIASenserEnumType.TVOC:
                            {
                                ValuelabelControl.Text = (data.GIAAPIValue.tvoc / 1000).ToString("F2");
                            }
                            break;
                        case GIASenserEnumType.Humidity:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.humidity.ToString("F1");
                            }
                            break;
                        case GIASenserEnumType.Temperature:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.temperature.ToString("F1");
                            }
                            break;
                        case GIASenserEnumType.HCHO:
                            {
                                ValuelabelControl.Text = (data.GIAAPIValue.hcho / 1000).ToString("F2");
                            }
                            break;
                        case GIASenserEnumType.O3:
                            {
                                ValuelabelControl.Text = (data.GIAAPIValue.o3 / 1000).ToString("F2");
                            }
                            break;
                        case GIASenserEnumType.CO:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.co.ToString();
                            }
                            break;
                        case GIASenserEnumType.Mold:
                            {
                                ValuelabelControl.Text = Convert.ToInt32(data.GIAAPIValue.mold).ToString();
                            }
                            break;
                        case GIASenserEnumType.PM1:
                            {
                                ValuelabelControl.Text = data.GIAAPIValue.pm1.ToString("F1");
                            }
                            break;
                    }
                    int AlarmRFore = Convert.ToInt32(ScreenMediaSetting.AlarmForeRGB[Convert.ToInt32(GIASenserEnumType)].Split(',')[0]);
                    int AlarmGFore = Convert.ToInt32(ScreenMediaSetting.AlarmForeRGB[Convert.ToInt32(GIASenserEnumType)].Split(',')[1]);
                    int AlarmBFore = Convert.ToInt32(ScreenMediaSetting.AlarmForeRGB[Convert.ToInt32(GIASenserEnumType)].Split(',')[2]);
                    if (Convert.ToDouble(ValuelabelControl.Text) > ScreenMediaSetting.AlarmValue[Convert.ToInt32(GIASenserEnumType)])
                    {
                        ValuelabelControl.Appearance.ForeColor = Color.FromArgb(AlarmRFore, AlarmGFore, AlarmBFore);
                    }
                    else
                    {
                        ValuelabelControl.Appearance.ForeColor = Color.FromArgb(RFore, GFore, BFore);
                    }
                }
            }
        }
        #endregion

        #region Modbus數值
        /// <summary>
        /// Modbus數值
        /// </summary>
        /// <param name="data">Modbus數值</param>
        private void Serch_Value(GIAData data)
        {
            if (!ScreenMediaSetting.AlarmFlag)
            {
                switch (GIASenserEnumType)
                {
                    case GIASenserEnumType.AirQuality:
                        {
                            ValuelabelControl.Text = Convert.ToInt32(data.IAQ).ToString();
                        }
                        break;
                    case GIASenserEnumType.PM25:
                        {
                            ValuelabelControl.Text = data.PM25.ToString();
                        }
                        break;
                    case GIASenserEnumType.PM10:
                        {
                            ValuelabelControl.Text = data.PM10.ToString();
                        }
                        break;
                    case GIASenserEnumType.CO2:
                        {
                            ValuelabelControl.Text = data.CO2.ToString();
                        }
                        break;
                    case GIASenserEnumType.TVOC:
                        {
                            ValuelabelControl.Text = data.TVOC.ToString("F2");
                        }
                        break;
                    case GIASenserEnumType.Humidity:
                        {
                            ValuelabelControl.Text = data.HumidityEstimation.ToString("F1");
                        }
                        break;
                    case GIASenserEnumType.Temperature:
                        {
                            ValuelabelControl.Text = data.Temperature.ToString("F1");
                        }
                        break;
                    case GIASenserEnumType.HCHO:
                        {
                            ValuelabelControl.Text = data.HCHO.ToString("F2");
                        }
                        break;
                    case GIASenserEnumType.O3:
                        {
                            ValuelabelControl.Text = data.O3.ToString("F2");
                        }
                        break;
                    case GIASenserEnumType.CO:
                        {
                            ValuelabelControl.Text = data.CO.ToString();
                        }
                        break;
                    case GIASenserEnumType.Mold:
                        {
                            ValuelabelControl.Text = data.Mold.ToString();
                        }
                        break;
                    case GIASenserEnumType.PM1:
                        {
                            ValuelabelControl.Text = data.PM1.ToString("F1");
                        }
                        break;
                }
            }
            else
            {
                switch (GIASenserEnumType)
                {
                    case GIASenserEnumType.AirQuality:
                        {
                            ValuelabelControl.Text = Convert.ToInt32(data.IAQ).ToString();
                        }
                        break;
                    case GIASenserEnumType.PM25:
                        {
                            ValuelabelControl.Text = data.PM25.ToString();
                        }
                        break;
                    case GIASenserEnumType.PM10:
                        {
                            ValuelabelControl.Text = data.PM10.ToString();
                        }
                        break;
                    case GIASenserEnumType.CO2:
                        {
                            ValuelabelControl.Text = data.CO2.ToString();
                        }
                        break;
                    case GIASenserEnumType.TVOC:
                        {
                            ValuelabelControl.Text = data.TVOC.ToString("F2");
                        }
                        break;
                    case GIASenserEnumType.Humidity:
                        {
                            ValuelabelControl.Text = data.HumidityEstimation.ToString("F1");
                        }
                        break;
                    case GIASenserEnumType.Temperature:
                        {
                            ValuelabelControl.Text = data.Temperature.ToString("F1");
                        }
                        break;
                    case GIASenserEnumType.HCHO:
                        {
                            ValuelabelControl.Text = data.HCHO.ToString("F2");
                        }
                        break;
                    case GIASenserEnumType.O3:
                        {
                            ValuelabelControl.Text = data.O3.ToString("F2");
                        }
                        break;
                    case GIASenserEnumType.CO:
                        {
                            ValuelabelControl.Text = data.CO.ToString();
                        }
                        break;
                    case GIASenserEnumType.Mold:
                        {
                            ValuelabelControl.Text = data.Mold.ToString();
                        }
                        break;
                    case GIASenserEnumType.PM1:
                        {
                            ValuelabelControl.Text = data.PM1.ToString("F1");
                        }
                        break;
                }
                int AlarmRFore = Convert.ToInt32(ScreenMediaSetting.AlarmForeRGB[Convert.ToInt32(GIASenserEnumType)].Split(',')[0]);
                int AlarmGFore = Convert.ToInt32(ScreenMediaSetting.AlarmForeRGB[Convert.ToInt32(GIASenserEnumType)].Split(',')[1]);
                int AlarmBFore = Convert.ToInt32(ScreenMediaSetting.AlarmForeRGB[Convert.ToInt32(GIASenserEnumType)].Split(',')[2]);
                if (Convert.ToDouble(ValuelabelControl.Text) > ScreenMediaSetting.AlarmValue[Convert.ToInt32(GIASenserEnumType)])
                {
                    ValuelabelControl.Appearance.ForeColor = Color.FromArgb(AlarmRFore, AlarmGFore, AlarmBFore);
                }
                else
                {
                    ValuelabelControl.Appearance.ForeColor = Color.FromArgb(RFore, GFore, BFore);
                }
            }
        }
        #endregion
    }
}
