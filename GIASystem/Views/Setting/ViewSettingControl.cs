using DevExpress.XtraSplashScreen;
using GIASystem.Methods;
using System;
using System.Drawing;

namespace GIASystem.Views.Setting
{
    public partial class ViewSettingControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 設定按鈕視窗
        /// </summary>
        private SettingButtonControl SettingButtonControl { get; set; }
        /// <summary>
        /// Loading物件繼承
        /// </summary>
        private IOverlaySplashScreenHandle handle = null;
        /// 關閉Loading視窗
        /// </summary>
        /// <param name="handle"></param>
        private void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }
        public ViewSettingControl(SettingButtonControl settingButtonControl)
        {
            InitializeComponent();
            labelControl13.Text = "CO" + "\xb2";
            labelControl18.Text = "O" + "\xb3";
            SettingButtonControl = settingButtonControl;
            if (SettingButtonControl.Horizontal_SenserForm != null)
            {
                /*感測器底板顏色*/
                BigSenserPanelcolorEdit.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.BigSenserPanelRGB;
                /*感測器字體顏色*/
                BigSenserForecolorEdit.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.BigSenserForeRGB;
                /*感測器底板顏色*/
                SmallSenserPanelcolorEdit.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.SmallSenserPanelRGB;
                /*感測器字體顏色*/
                SmallSenserForecolorEdit.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.SmallSenserForeRGB;
                /*跑馬燈底板顏色*/
                MarqueePanelcolorEdit.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.MarqueePanelRGB;
                /*跑馬燈字體顏色*/
                MarqueeForecolorEdit.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.MarqueeForeRGB;

                AlarmtoggleSwitch.IsOn = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmFlag;

                AlarmtextEdit1.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[0].ToString();
                AlarmtextEdit2.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[1].ToString();
                AlarmtextEdit3.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[2].ToString();
                AlarmtextEdit4.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[3].ToString();
                AlarmtextEdit5.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[4].ToString();
                AlarmtextEdit6.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[5].ToString();
                AlarmtextEdit7.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[6].ToString();
                AlarmtextEdit8.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[7].ToString();
                AlarmtextEdit9.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[8].ToString();
                AlarmtextEdit10.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[9].ToString();
                AlarmtextEdit11.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[10].ToString();
                AlarmtextEdit12.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[11].ToString();

                AlarmcolorPickEdit1.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[0].ToString();
                AlarmcolorPickEdit2.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[1].ToString();
                AlarmcolorPickEdit3.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[2].ToString();
                AlarmcolorPickEdit4.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[3].ToString();
                AlarmcolorPickEdit5.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[4].ToString();
                AlarmcolorPickEdit6.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[5].ToString();
                AlarmcolorPickEdit7.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[6].ToString();
                AlarmcolorPickEdit8.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[7].ToString();
                AlarmcolorPickEdit9.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[8].ToString();
                AlarmcolorPickEdit10.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[9].ToString();
                AlarmcolorPickEdit11.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[10].ToString();
                AlarmcolorPickEdit12.Text = SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[11].ToString();
            }
            else if (SettingButtonControl.ElectricForm != null)
            {
                /*感測器底板顏色*/
                BigSenserPanelcolorEdit.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.BigSenserPanelRGB;
                /*感測器字體顏色*/
                BigSenserForecolorEdit.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.BigSenserForeRGB;
                /*感測器底板顏色*/
                SmallSenserPanelcolorEdit.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.SmallSenserPanelRGB;
                /*感測器字體顏色*/
                SmallSenserForecolorEdit.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.SmallSenserForeRGB;
                /*跑馬燈底板顏色*/
                MarqueePanelcolorEdit.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.MarqueePanelRGB;
                /*跑馬燈字體顏色*/
                MarqueeForecolorEdit.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.MarqueeForeRGB;

                AlarmtoggleSwitch.IsOn = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmFlag;

                AlarmtextEdit1.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[0].ToString();
                AlarmtextEdit2.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[1].ToString();
                AlarmtextEdit3.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[2].ToString();
                AlarmtextEdit4.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[3].ToString();
                AlarmtextEdit5.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[4].ToString();
                AlarmtextEdit6.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[5].ToString();
                AlarmtextEdit7.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[6].ToString();
                AlarmtextEdit8.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[7].ToString();
                AlarmtextEdit9.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[8].ToString();
                AlarmtextEdit10.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[9].ToString();
                AlarmtextEdit11.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[10].ToString();
                AlarmtextEdit12.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[11].ToString();

                AlarmcolorPickEdit1.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[0].ToString();
                AlarmcolorPickEdit2.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[1].ToString();
                AlarmcolorPickEdit3.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[2].ToString();
                AlarmcolorPickEdit4.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[3].ToString();
                AlarmcolorPickEdit5.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[4].ToString();
                AlarmcolorPickEdit6.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[5].ToString();
                AlarmcolorPickEdit7.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[6].ToString();
                AlarmcolorPickEdit8.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[7].ToString();
                AlarmcolorPickEdit9.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[8].ToString();
                AlarmcolorPickEdit10.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[9].ToString();
                AlarmcolorPickEdit11.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[10].ToString();
                AlarmcolorPickEdit12.Text = SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[11].ToString();
            }
            else if (SettingButtonControl.StraightSenserForm != null)
            {
                /*感測器底板顏色*/
                BigSenserPanelcolorEdit.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.BigSenserPanelRGB;
                /*感測器字體顏色*/
                BigSenserForecolorEdit.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.BigSenserForeRGB;
                /*感測器底板顏色*/
                SmallSenserPanelcolorEdit.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.SmallSenserPanelRGB;
                /*感測器字體顏色*/
                SmallSenserForecolorEdit.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.SmallSenserForeRGB;
                /*跑馬燈底板顏色*/
                MarqueePanelcolorEdit.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.MarqueePanelRGB;
                /*跑馬燈字體顏色*/
                MarqueeForecolorEdit.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.MarqueeForeRGB;

                AlarmtoggleSwitch.IsOn = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmFlag;

                AlarmtextEdit1.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[0].ToString();
                AlarmtextEdit2.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[1].ToString();
                AlarmtextEdit3.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[2].ToString();
                AlarmtextEdit4.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[3].ToString();
                AlarmtextEdit5.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[4].ToString();
                AlarmtextEdit6.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[5].ToString();
                AlarmtextEdit7.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[6].ToString();
                AlarmtextEdit8.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[7].ToString();
                AlarmtextEdit9.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[8].ToString();
                AlarmtextEdit10.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[9].ToString();
                AlarmtextEdit11.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[10].ToString();
                AlarmtextEdit12.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[11].ToString();

                AlarmcolorPickEdit1.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[0].ToString();
                AlarmcolorPickEdit2.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[1].ToString();
                AlarmcolorPickEdit3.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[2].ToString();
                AlarmcolorPickEdit4.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[3].ToString();
                AlarmcolorPickEdit5.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[4].ToString();
                AlarmcolorPickEdit6.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[5].ToString();
                AlarmcolorPickEdit7.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[6].ToString();
                AlarmcolorPickEdit8.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[7].ToString();
                AlarmcolorPickEdit9.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[8].ToString();
                AlarmcolorPickEdit10.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[9].ToString();
                AlarmcolorPickEdit11.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[10].ToString();
                AlarmcolorPickEdit12.Text = SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[11].ToString();
            }
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                if (SettingButtonControl.Horizontal_SenserForm != null)
                {
                    SettingButtonControl.Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                else if (SettingButtonControl.ElectricForm != null)
                {
                    SettingButtonControl.ElectricForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                else if (SettingButtonControl.StraightSenserForm != null)
                {
                    SettingButtonControl.StraightSenserForm.Straight_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                SettingButtonControl.FlyoutFlag = false;
                SettingButtonControl.flyout.Close();
            };
            #endregion
            #region 確定按鈕
            btn_OK.Click += (s, e) =>
            {
                handle = SplashScreenManager.ShowOverlayForm(FindForm());
                if (SettingButtonControl.Horizontal_SenserForm != null)
                {
                    /*感測器底板顏色(大)*/
                    Color BigsenserPanel = ColorTranslator.FromHtml(BigSenserPanelcolorEdit.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.BigSenserPanelRGB = $"{BigsenserPanel.R},{BigsenserPanel.G},{BigsenserPanel.B}";
                    /*感測器字體顏色(大)*/
                    Color BigsenserFore = ColorTranslator.FromHtml(BigSenserForecolorEdit.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.BigSenserForeRGB = $"{BigsenserFore.R},{BigsenserFore.G},{BigsenserFore.B}";
                    /*感測器底板顏色(大)*/
                    Color SmallsenserPanel = ColorTranslator.FromHtml(SmallSenserPanelcolorEdit.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.SmallSenserPanelRGB = $"{SmallsenserPanel.R},{SmallsenserPanel.G},{SmallsenserPanel.B}";
                    /*感測器字體顏色(大)*/
                    Color SmallsenserFore = ColorTranslator.FromHtml(SmallSenserForecolorEdit.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.SmallSenserForeRGB = $"{SmallsenserFore.R},{SmallsenserFore.G},{SmallsenserFore.B}";
                    /*跑馬燈底板顏色*/
                    Color marqueePanel = ColorTranslator.FromHtml(MarqueePanelcolorEdit.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.MarqueePanelRGB = $"{marqueePanel.R},{marqueePanel.G},{marqueePanel.B}";
                    /*跑馬燈字體顏色*/
                    Color marqueeFore = ColorTranslator.FromHtml(MarqueeForecolorEdit.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.MarqueeForeRGB = $"{marqueeFore.R},{marqueeFore.G},{marqueeFore.B}";

                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmFlag = AlarmtoggleSwitch.IsOn;

                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[0] = Convert.ToDouble(AlarmtextEdit1.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[1] = Convert.ToDouble(AlarmtextEdit2.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[2] = Convert.ToDouble(AlarmtextEdit3.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[3] = Convert.ToDouble(AlarmtextEdit4.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[4] = Convert.ToDouble(AlarmtextEdit5.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[5] = Convert.ToDouble(AlarmtextEdit6.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[6] = Convert.ToDouble(AlarmtextEdit7.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[7] = Convert.ToDouble(AlarmtextEdit8.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[8] = Convert.ToDouble(AlarmtextEdit9.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[9] = Convert.ToDouble(AlarmtextEdit10.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[10] = Convert.ToDouble(AlarmtextEdit11.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmValue[11] = Convert.ToDouble(AlarmtextEdit12.Text);

                    Color color1 = ColorTranslator.FromHtml(AlarmcolorPickEdit1.Text);
                    Color color2 = ColorTranslator.FromHtml(AlarmcolorPickEdit2.Text);
                    Color color3 = ColorTranslator.FromHtml(AlarmcolorPickEdit3.Text);
                    Color color4 = ColorTranslator.FromHtml(AlarmcolorPickEdit4.Text);
                    Color color5 = ColorTranslator.FromHtml(AlarmcolorPickEdit5.Text);
                    Color color6 = ColorTranslator.FromHtml(AlarmcolorPickEdit6.Text);
                    Color color7 = ColorTranslator.FromHtml(AlarmcolorPickEdit7.Text);
                    Color color8 = ColorTranslator.FromHtml(AlarmcolorPickEdit8.Text);
                    Color color9 = ColorTranslator.FromHtml(AlarmcolorPickEdit9.Text);
                    Color color10 = ColorTranslator.FromHtml(AlarmcolorPickEdit10.Text);
                    Color color11 = ColorTranslator.FromHtml(AlarmcolorPickEdit11.Text);
                    Color color12 = ColorTranslator.FromHtml(AlarmcolorPickEdit12.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[0] = $"{color1.R},{color1.G},{color1.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[1] = $"{color2.R},{color2.G},{color2.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[2] = $"{color3.R},{color3.G},{color3.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[3] = $"{color4.R},{color4.G},{color4.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[4] = $"{color5.R},{color5.G},{color5.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[5] = $"{color6.R},{color6.G},{color6.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[6] = $"{color7.R},{color7.G},{color7.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[7] = $"{color8.R},{color8.G},{color8.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[8] = $"{color9.R},{color9.G},{color9.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[9] = $"{color10.R},{color10.G},{color10.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[10] = $"{color11.R},{color11.G},{color11.B}";
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.AlarmForeRGB[11] = $"{color12.R},{color12.G},{color12.B}";

                    /*(整合過)顏色變更*/
                    SettingButtonControl.Horizontal_SenserForm.Horizontal_GIAScreenControl.Change_ScreenMedia(SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting);
                    SettingButtonControl.Horizontal_SenserForm.MarqueeControl.Change_MarqueeColor();
                    /*復原GIA切換畫面旗標*/
                    SettingButtonControl.Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                    /*存取修改後的畫面JSON*/
                    InitialMethod.Save_ScreenMedia(SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting);
                }
                else if (SettingButtonControl.ElectricForm != null)
                {
                    /*感測器底板顏色(大)*/
                    Color BigsenserPanel = ColorTranslator.FromHtml(BigSenserPanelcolorEdit.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.BigSenserPanelRGB = $"{BigsenserPanel.R},{BigsenserPanel.G},{BigsenserPanel.B}";
                    /*感測器字體顏色(大)*/
                    Color BigsenserFore = ColorTranslator.FromHtml(BigSenserForecolorEdit.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.BigSenserForeRGB = $"{BigsenserFore.R},{BigsenserFore.G},{BigsenserFore.B}";
                    /*感測器底板顏色(大)*/
                    Color SmallsenserPanel = ColorTranslator.FromHtml(SmallSenserPanelcolorEdit.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.SmallSenserPanelRGB = $"{SmallsenserPanel.R},{SmallsenserPanel.G},{SmallsenserPanel.B}";
                    /*感測器字體顏色(大)*/
                    Color SmallsenserFore = ColorTranslator.FromHtml(SmallSenserForecolorEdit.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.SmallSenserForeRGB = $"{SmallsenserFore.R},{SmallsenserFore.G},{SmallsenserFore.B}";
                    /*跑馬燈底板顏色*/
                    Color marqueePanel = ColorTranslator.FromHtml(MarqueePanelcolorEdit.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.MarqueePanelRGB = $"{marqueePanel.R},{marqueePanel.G},{marqueePanel.B}";
                    /*跑馬燈字體顏色*/
                    Color marqueeFore = ColorTranslator.FromHtml(MarqueeForecolorEdit.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.MarqueeForeRGB = $"{marqueeFore.R},{marqueeFore.G},{marqueeFore.B}";

                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmFlag = AlarmtoggleSwitch.IsOn;

                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[0] = Convert.ToDouble(AlarmtextEdit1.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[1] = Convert.ToDouble(AlarmtextEdit2.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[2] = Convert.ToDouble(AlarmtextEdit3.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[3] = Convert.ToDouble(AlarmtextEdit4.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[4] = Convert.ToDouble(AlarmtextEdit5.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[5] = Convert.ToDouble(AlarmtextEdit6.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[6] = Convert.ToDouble(AlarmtextEdit7.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[7] = Convert.ToDouble(AlarmtextEdit8.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[8] = Convert.ToDouble(AlarmtextEdit9.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[9] = Convert.ToDouble(AlarmtextEdit10.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[10] = Convert.ToDouble(AlarmtextEdit11.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmValue[11] = Convert.ToDouble(AlarmtextEdit12.Text);

                    Color color1 = ColorTranslator.FromHtml(AlarmcolorPickEdit1.Text);
                    Color color2 = ColorTranslator.FromHtml(AlarmcolorPickEdit2.Text);
                    Color color3 = ColorTranslator.FromHtml(AlarmcolorPickEdit3.Text);
                    Color color4 = ColorTranslator.FromHtml(AlarmcolorPickEdit4.Text);
                    Color color5 = ColorTranslator.FromHtml(AlarmcolorPickEdit5.Text);
                    Color color6 = ColorTranslator.FromHtml(AlarmcolorPickEdit6.Text);
                    Color color7 = ColorTranslator.FromHtml(AlarmcolorPickEdit7.Text);
                    Color color8 = ColorTranslator.FromHtml(AlarmcolorPickEdit8.Text);
                    Color color9 = ColorTranslator.FromHtml(AlarmcolorPickEdit9.Text);
                    Color color10 = ColorTranslator.FromHtml(AlarmcolorPickEdit10.Text);
                    Color color11 = ColorTranslator.FromHtml(AlarmcolorPickEdit11.Text);
                    Color color12 = ColorTranslator.FromHtml(AlarmcolorPickEdit12.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[0] = $"{color1.R},{color1.G},{color1.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[1] = $"{color2.R},{color2.G},{color2.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[2] = $"{color3.R},{color3.G},{color3.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[3] = $"{color4.R},{color4.G},{color4.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[4] = $"{color5.R},{color5.G},{color5.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[5] = $"{color6.R},{color6.G},{color6.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[6] = $"{color7.R},{color7.G},{color7.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[7] = $"{color8.R},{color8.G},{color8.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[8] = $"{color9.R},{color9.G},{color9.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[9] = $"{color10.R},{color10.G},{color10.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[10] = $"{color11.R},{color11.G},{color11.B}";
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.AlarmForeRGB[11] = $"{color12.R},{color12.G},{color12.B}";

                    /*(整合過)顏色變更*/
                    SettingButtonControl.ElectricForm.Horizontal_GIAScreenControl.Change_ScreenMedia(SettingButtonControl.ElectricForm.ScreenMediaSetting);
                    SettingButtonControl.ElectricForm.MarqueeControl.Change_MarqueeColor();
                    /*復原GIA切換畫面旗標*/
                    SettingButtonControl.ElectricForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                    /*存取修改後的畫面JSON*/
                    InitialMethod.Save_ScreenMedia(SettingButtonControl.ElectricForm.ScreenMediaSetting);
                }
                else if (SettingButtonControl.StraightSenserForm != null)
                {
                    /*感測器底板顏色(大)*/
                    Color BigsenserPanel = ColorTranslator.FromHtml(BigSenserPanelcolorEdit.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.BigSenserPanelRGB = $"{BigsenserPanel.R},{BigsenserPanel.G},{BigsenserPanel.B}";
                    /*感測器字體顏色(大)*/
                    Color BigsenserFore = ColorTranslator.FromHtml(BigSenserForecolorEdit.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.BigSenserForeRGB = $"{BigsenserFore.R},{BigsenserFore.G},{BigsenserFore.B}";
                    /*感測器底板顏色(大)*/
                    Color SmallsenserPanel = ColorTranslator.FromHtml(SmallSenserPanelcolorEdit.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.SmallSenserPanelRGB = $"{SmallsenserPanel.R},{SmallsenserPanel.G},{SmallsenserPanel.B}";
                    /*感測器字體顏色(大)*/
                    Color SmallsenserFore = ColorTranslator.FromHtml(SmallSenserForecolorEdit.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.SmallSenserForeRGB = $"{SmallsenserFore.R},{SmallsenserFore.G},{SmallsenserFore.B}";
                    /*跑馬燈底板顏色*/
                    Color marqueePanel = ColorTranslator.FromHtml(MarqueePanelcolorEdit.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.MarqueePanelRGB = $"{marqueePanel.R},{marqueePanel.G},{marqueePanel.B}";
                    /*跑馬燈字體顏色*/
                    Color marqueeFore = ColorTranslator.FromHtml(MarqueeForecolorEdit.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.MarqueeForeRGB = $"{marqueeFore.R},{marqueeFore.G},{marqueeFore.B}";

                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmFlag = AlarmtoggleSwitch.IsOn;

                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[0] = Convert.ToDouble(AlarmtextEdit1.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[1] = Convert.ToDouble(AlarmtextEdit2.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[2] = Convert.ToDouble(AlarmtextEdit3.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[3] = Convert.ToDouble(AlarmtextEdit4.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[4] = Convert.ToDouble(AlarmtextEdit5.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[5] = Convert.ToDouble(AlarmtextEdit6.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[6] = Convert.ToDouble(AlarmtextEdit7.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[7] = Convert.ToDouble(AlarmtextEdit8.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[8] = Convert.ToDouble(AlarmtextEdit9.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[9] = Convert.ToDouble(AlarmtextEdit10.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[10] = Convert.ToDouble(AlarmtextEdit11.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmValue[11] = Convert.ToDouble(AlarmtextEdit12.Text);

                    Color color1 = ColorTranslator.FromHtml(AlarmcolorPickEdit1.Text);
                    Color color2 = ColorTranslator.FromHtml(AlarmcolorPickEdit2.Text);
                    Color color3 = ColorTranslator.FromHtml(AlarmcolorPickEdit3.Text);
                    Color color4 = ColorTranslator.FromHtml(AlarmcolorPickEdit4.Text);
                    Color color5 = ColorTranslator.FromHtml(AlarmcolorPickEdit5.Text);
                    Color color6 = ColorTranslator.FromHtml(AlarmcolorPickEdit6.Text);
                    Color color7 = ColorTranslator.FromHtml(AlarmcolorPickEdit7.Text);
                    Color color8 = ColorTranslator.FromHtml(AlarmcolorPickEdit8.Text);
                    Color color9 = ColorTranslator.FromHtml(AlarmcolorPickEdit9.Text);
                    Color color10 = ColorTranslator.FromHtml(AlarmcolorPickEdit10.Text);
                    Color color11 = ColorTranslator.FromHtml(AlarmcolorPickEdit11.Text);
                    Color color12 = ColorTranslator.FromHtml(AlarmcolorPickEdit12.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[0] = $"{color1.R},{color1.G},{color1.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[1] = $"{color2.R},{color2.G},{color2.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[2] = $"{color3.R},{color3.G},{color3.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[3] = $"{color4.R},{color4.G},{color4.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[4] = $"{color5.R},{color5.G},{color5.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[5] = $"{color6.R},{color6.G},{color6.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[6] = $"{color7.R},{color7.G},{color7.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[7] = $"{color8.R},{color8.G},{color8.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[8] = $"{color9.R},{color9.G},{color9.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[9] = $"{color10.R},{color10.G},{color10.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[10] = $"{color11.R},{color11.G},{color11.B}";
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.AlarmForeRGB[11] = $"{color12.R},{color12.G},{color12.B}";

                    /*(整合過)顏色變更*/
                    SettingButtonControl.StraightSenserForm.Straight_GIAScreenControl.Change_ScreenMedia(SettingButtonControl.StraightSenserForm.ScreenMediaSetting);
                    SettingButtonControl.StraightSenserForm.MarqueeControl.Change_MarqueeColor();
                    /*復原GIA切換畫面旗標*/
                    SettingButtonControl.StraightSenserForm.Straight_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                    /*存取修改後的畫面JSON*/
                    InitialMethod.Save_ScreenMedia(SettingButtonControl.StraightSenserForm.ScreenMediaSetting);
                }
                SettingButtonControl.FlyoutFlag = false;
                SettingButtonControl.flyout.Close();
                /*結束等待畫面*/
                CloseProgressPanel(handle);

            };
            #endregion
        }
        #region 超標數值功能
        private void AlarmtoggleSwitch_Toggled(object sender, EventArgs e)
        {
            AlarmtextEdit1.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit2.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit3.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit4.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit5.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit6.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit7.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit8.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit9.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit10.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit11.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmtextEdit12.Enabled = AlarmtoggleSwitch.IsOn;

            AlarmcolorPickEdit1.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit2.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit3.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit4.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit5.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit6.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit7.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit8.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit9.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit10.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit11.Enabled = AlarmtoggleSwitch.IsOn;
            AlarmcolorPickEdit12.Enabled = AlarmtoggleSwitch.IsOn;
        }
        #endregion
    }
}
