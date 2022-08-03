using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GIASystem.Methods;
using System;
using System.IO;
using System.Windows.Forms;

namespace GIASystem.Views.Setting
{
    public partial class ScreenSettingControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 設定按鈕視窗
        /// </summary>
        private SettingButtonControl SettingButtonControl { get; set; }
        /// <summary>
        /// Loading物件繼承
        /// </summary>
        private IOverlaySplashScreenHandle handle = null;
        /// <summary>
        /// 開啟檔案瀏覽
        /// </summary>
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        /// <summary>
        /// 影片路徑物件
        /// </summary>
        private FolderBrowserDialog VedioFileDialog = new FolderBrowserDialog();
        /// <summary>
        /// 影片路徑物件
        /// </summary>
        private FolderBrowserDialog PictureFileDialog = new FolderBrowserDialog();
        /// 關閉Loading視窗
        /// </summary>
        /// <param name="handle"></param>
        private void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }
        public ScreenSettingControl(SettingButtonControl settingButtonControl)
        {
            InitializeComponent();
            var tDll = this.GetType().Assembly.GetName();
            lbl_RelaeseNumber.Text = $"版本 : {tDll.Version.ToString()}";
             SettingButtonControl = settingButtonControl;
            #region 畫面設定
            if (settingButtonControl.Horizontal_SenserForm != null)
            {
                if (settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.LogoPath != null)
                {
                    LogolabelControl.Text = Path.GetFileName(settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.LogoPath);
                }
                if (settingButtonControl.Horizontal_SenserForm.MediaPlaySetting != null)
                {
                    VediolabelControl.Text = $"{settingButtonControl.Horizontal_SenserForm.MediaPlaySetting.VideoPath}";
                    PicturelabelControl.Text = $"{settingButtonControl.Horizontal_SenserForm.MediaPlaySetting.PicturePath}";
                }
                SectextEdit.Text = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ChangePageSec.ToString();
                SenserItem(comboBoxEdit1);
                SenserItem(comboBoxEdit2);
                SenserItem(comboBoxEdit3);
                SenserItem(comboBoxEdit4);
                SenserItem(comboBoxEdit5);
                SenserItem(comboBoxEdit6);
                SenserItem(comboBoxEdit7);
                SenserItem(comboBoxEdit8);
                SenserItem(comboBoxEdit9);
                SenserItem(comboBoxEdit10);
                SenserItem(comboBoxEdit11);
                SenserItem(comboBoxEdit12);
                SenserItem(comboBoxEdit13);
                SenserItem(comboBoxEdit14);
                toggleSwitch1.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag1;
                toggleSwitch2.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag2;
                toggleSwitch3.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag1;
                toggleSwitch4.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag2;
                toggleSwitch5.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag1;
                toggleSwitch6.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag2;
                toggleSwitch7.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag1;
                toggleSwitch8.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag2;
                toggleSwitch9.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag1;
                toggleSwitch10.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag2;
                toggleSwitch11.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag1;
                toggleSwitch12.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag2;
                toggleSwitch13.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag1;
                toggleSwitch14.IsOn = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag2;
                comboBoxEdit1.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum1;
                comboBoxEdit2.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum2;
                comboBoxEdit3.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum1;
                comboBoxEdit4.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum2;
                comboBoxEdit5.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum1;
                comboBoxEdit6.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum2;
                comboBoxEdit7.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum1;
                comboBoxEdit8.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum2;
                comboBoxEdit9.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum1;
                comboBoxEdit10.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum2;
                comboBoxEdit11.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum1;
                comboBoxEdit12.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum2;
                comboBoxEdit13.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum1;
                comboBoxEdit14.SelectedIndex = settingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum2;
            }
            else if (settingButtonControl.ElectricForm != null)
            {
                //groupControl1.Text = "圖片設定";
                //VediosimpleButton.Text = "更改圖片路徑";
                if (settingButtonControl.ElectricForm.ScreenMediaSetting.LogoPath != null)
                {
                    LogolabelControl.Text = Path.GetFileName(settingButtonControl.ElectricForm.ScreenMediaSetting.LogoPath);
                }
                if (settingButtonControl.ElectricForm.MediaPlaySetting != null)
                {
                    VediolabelControl.Text = $"{settingButtonControl.ElectricForm.MediaPlaySetting.VideoPath}";
                    PicturelabelControl.Text = $"{settingButtonControl.ElectricForm.MediaPlaySetting.PicturePath}";
                }
                SectextEdit.Text = settingButtonControl.ElectricForm.ScreenMediaSetting.ChangePageSec.ToString();
                SenserItem(comboBoxEdit1);
                SenserItem(comboBoxEdit2);
                SenserItem(comboBoxEdit3);
                SenserItem(comboBoxEdit4);
                SenserItem(comboBoxEdit5);
                SenserItem(comboBoxEdit6);
                SenserItem(comboBoxEdit7);
                SenserItem(comboBoxEdit8);
                SenserItem(comboBoxEdit9);
                SenserItem(comboBoxEdit10);
                SenserItem(comboBoxEdit11);
                SenserItem(comboBoxEdit12);
                SenserItem(comboBoxEdit13);
                SenserItem(comboBoxEdit14);
                toggleSwitch1.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag1;
                toggleSwitch2.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag2;
                toggleSwitch3.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag1;
                toggleSwitch4.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag2;
                toggleSwitch5.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag1;
                toggleSwitch6.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag2;
                toggleSwitch7.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag1;
                toggleSwitch8.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag2;
                toggleSwitch9.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag1;
                toggleSwitch10.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag2;
                toggleSwitch11.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag1;
                toggleSwitch12.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag2;
                toggleSwitch13.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag1;
                toggleSwitch14.IsOn = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag2;
                comboBoxEdit1.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum1;
                comboBoxEdit2.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum2;
                comboBoxEdit3.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum1;
                comboBoxEdit4.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum2;
                comboBoxEdit5.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum1;
                comboBoxEdit6.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum2;
                comboBoxEdit7.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum1;
                comboBoxEdit8.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum2;
                comboBoxEdit9.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum1;
                comboBoxEdit10.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum2;
                comboBoxEdit11.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum1;
                comboBoxEdit12.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum2;
                comboBoxEdit13.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum1;
                comboBoxEdit14.SelectedIndex = settingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum2;
            }
            else if (settingButtonControl.StraightSenserForm != null)
            {
                LogosimpleButton.Visible = false;
                LogolabelControl.Visible = false;
                if (settingButtonControl.StraightSenserForm.ScreenMediaSetting.LogoPath != null)
                {
                    LogolabelControl.Text = Path.GetFileName(settingButtonControl.StraightSenserForm.ScreenMediaSetting.LogoPath);
                }
                if (settingButtonControl.StraightSenserForm.MediaPlaySetting != null)
                {
                    VediolabelControl.Text = $"{settingButtonControl.StraightSenserForm.MediaPlaySetting.VideoPath}";
                    PicturelabelControl.Text = $"{settingButtonControl.StraightSenserForm.MediaPlaySetting.PicturePath}";
                }
                SectextEdit.Text = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ChangePageSec.ToString();
                SenserItem(comboBoxEdit1);
                SenserItem(comboBoxEdit2);
                SenserItem(comboBoxEdit3);
                SenserItem(comboBoxEdit4);
                SenserItem(comboBoxEdit5);
                SenserItem(comboBoxEdit6);
                SenserItem(comboBoxEdit7);
                SenserItem(comboBoxEdit8);
                SenserItem(comboBoxEdit9);
                SenserItem(comboBoxEdit10);
                SenserItem(comboBoxEdit11);
                SenserItem(comboBoxEdit12);
                SenserItem(comboBoxEdit13);
                SenserItem(comboBoxEdit14);
                toggleSwitch1.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag1;
                toggleSwitch2.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag2;
                toggleSwitch3.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag1;
                toggleSwitch4.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag2;
                toggleSwitch5.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag1;
                toggleSwitch6.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag2;
                toggleSwitch7.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag1;
                toggleSwitch8.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag2;
                toggleSwitch9.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag1;
                toggleSwitch10.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag2;
                toggleSwitch11.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag1;
                toggleSwitch12.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag2;
                toggleSwitch13.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag1;
                toggleSwitch14.IsOn = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag2;
                comboBoxEdit1.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum1;
                comboBoxEdit2.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum2;
                comboBoxEdit3.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum1;
                comboBoxEdit4.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum2;
                comboBoxEdit5.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum1;
                comboBoxEdit6.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum2;
                comboBoxEdit7.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum1;
                comboBoxEdit8.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum2;
                comboBoxEdit9.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum1;
                comboBoxEdit10.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum2;
                comboBoxEdit11.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum1;
                comboBoxEdit12.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum2;
                comboBoxEdit13.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum1;
                comboBoxEdit14.SelectedIndex = settingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum2;
            }
            #endregion
            #region 背景圖片變更
            LogosimpleButton.Click += (s, e) =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        LogolabelControl.Text = Path.GetFileName(openFileDialog.FileName);
                    }
                }
            };
            #endregion
            #region 影片路徑變更
            VediosimpleButton.Click += (s, e) =>
            {
                if (VedioFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (VedioFileDialog.Description != null)
                    {
                        VediolabelControl.Text = Path.GetFullPath(VedioFileDialog.SelectedPath);
                    }
                }
            };
            #endregion
            #region 圖片路徑變更
            PicturesimpleButton.Click += (s, e) =>
            {
                if (PictureFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (PictureFileDialog.Description != null)
                    {
                        PicturelabelControl.Text = Path.GetFullPath(PictureFileDialog.SelectedPath);
                    }
                }
            };
            #endregion
            #region 取消按鈕
            CancelsimpleButton.Click += (s, e) =>
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
            OKsimpleButton.Click += (s, e) =>
            {
                handle = SplashScreenManager.ShowOverlayForm(FindForm());
                if (SettingButtonControl.Horizontal_SenserForm != null)
                {
                    #region 畫面
                    if (openFileDialog.FileName != "")
                    {
                        SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.LogoPath = Path.GetFullPath(openFileDialog.FileName);
                    }
                    if (VedioFileDialog.SelectedPath != "")
                    {
                        SettingButtonControl.Horizontal_SenserForm.MediaPlaySetting.VideoPath = VedioFileDialog.SelectedPath;
                    }
                    if (PictureFileDialog.SelectedPath != "")
                    {
                        SettingButtonControl.Horizontal_SenserForm.MediaPlaySetting.PicturePath = PictureFileDialog.SelectedPath;
                    }
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ChangePageSec = Convert.ToInt32(SectextEdit.Text);
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag1 = toggleSwitch1.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag2 = toggleSwitch2.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag1 = toggleSwitch3.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag2 = toggleSwitch4.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag1 = toggleSwitch5.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag2 = toggleSwitch6.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag1 = toggleSwitch7.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag2 = toggleSwitch8.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag1 = toggleSwitch9.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag2 = toggleSwitch10.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag1 = toggleSwitch11.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag2 = toggleSwitch12.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag1 = toggleSwitch13.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag2 = toggleSwitch14.IsOn;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum1 = comboBoxEdit1.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum2 = comboBoxEdit2.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum1 = comboBoxEdit3.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum2 = comboBoxEdit4.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum1 = comboBoxEdit5.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum2 = comboBoxEdit6.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum1 = comboBoxEdit7.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum2 = comboBoxEdit8.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum1 = comboBoxEdit9.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum2 = comboBoxEdit10.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum1 = comboBoxEdit11.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum2 = comboBoxEdit12.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum1 = comboBoxEdit13.SelectedIndex;
                    SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum2 = comboBoxEdit14.SelectedIndex;
                    #endregion
                    SettingButtonControl.Horizontal_SenserForm.Horizontal_GIAScreenControl.Change_ScreenMedia(SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting);
                    InitialMethod.Save_ScreenMedia(SettingButtonControl.Horizontal_SenserForm.ScreenMediaSetting);
                    InitialMethod.Save_MediaPlay(SettingButtonControl.Horizontal_SenserForm.MediaPlaySetting);
                    SettingButtonControl.Horizontal_SenserForm.Change_BackgroundImage();
                    SettingButtonControl.Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                else if (SettingButtonControl.ElectricForm != null)
                {
                    #region 畫面
                    if (openFileDialog.FileName != "")
                    {
                        SettingButtonControl.ElectricForm.ScreenMediaSetting.LogoPath = Path.GetFullPath(openFileDialog.FileName);
                    }
                    if (VedioFileDialog.SelectedPath != "")
                    {
                        SettingButtonControl.ElectricForm.MediaPlaySetting.VideoPath = VedioFileDialog.SelectedPath;
                    }
                    if (PictureFileDialog.SelectedPath != "")
                    {
                        SettingButtonControl.ElectricForm.MediaPlaySetting.PicturePath = PictureFileDialog.SelectedPath;
                    }
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ChangePageSec = Convert.ToInt32(SectextEdit.Text);
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag1 = toggleSwitch1.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag2 = toggleSwitch2.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag1 = toggleSwitch3.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag2 = toggleSwitch4.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag1 = toggleSwitch5.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag2 = toggleSwitch6.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag1 = toggleSwitch7.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag2 = toggleSwitch8.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag1 = toggleSwitch9.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag2 = toggleSwitch10.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag1 = toggleSwitch11.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag2 = toggleSwitch12.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag1 = toggleSwitch13.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag2 = toggleSwitch14.IsOn;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum1 = comboBoxEdit1.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum2 = comboBoxEdit2.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum1 = comboBoxEdit3.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum2 = comboBoxEdit4.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum1 = comboBoxEdit5.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum2 = comboBoxEdit6.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum1 = comboBoxEdit7.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum2 = comboBoxEdit8.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum1 = comboBoxEdit9.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum2 = comboBoxEdit10.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum1 = comboBoxEdit11.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum2 = comboBoxEdit12.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum1 = comboBoxEdit13.SelectedIndex;
                    SettingButtonControl.ElectricForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum2 = comboBoxEdit14.SelectedIndex;
                    #endregion
                    SettingButtonControl.ElectricForm.Horizontal_GIAScreenControl.Change_ScreenMedia(SettingButtonControl.ElectricForm.ScreenMediaSetting);
                    InitialMethod.Save_ScreenMedia(SettingButtonControl.ElectricForm.ScreenMediaSetting);
                    InitialMethod.Save_MediaPlay(SettingButtonControl.ElectricForm.MediaPlaySetting);
                    SettingButtonControl.ElectricForm.Change_BackgroundImage();
                    SettingButtonControl.ElectricForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                else if (SettingButtonControl.StraightSenserForm != null)
                {
                    #region 畫面
                    if (openFileDialog.FileName != "")
                    {
                        SettingButtonControl.StraightSenserForm.ScreenMediaSetting.LogoPath = Path.GetFullPath(openFileDialog.FileName);
                    }
                    if (VedioFileDialog.SelectedPath != "")
                    {
                        SettingButtonControl.StraightSenserForm.MediaPlaySetting.VideoPath = VedioFileDialog.SelectedPath;

                    }
                    if (PictureFileDialog.SelectedPath != "")
                    {
                        SettingButtonControl.StraightSenserForm.MediaPlaySetting.PicturePath = PictureFileDialog.SelectedPath;
                    }
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ChangePageSec = Convert.ToInt32(SectextEdit.Text);
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag1 = toggleSwitch1.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].VisibleFlag2 = toggleSwitch2.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag1 = toggleSwitch3.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].VisibleFlag2 = toggleSwitch4.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag1 = toggleSwitch5.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].VisibleFlag2 = toggleSwitch6.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag1 = toggleSwitch7.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].VisibleFlag2 = toggleSwitch8.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag1 = toggleSwitch9.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].VisibleFlag2 = toggleSwitch10.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag1 = toggleSwitch11.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].VisibleFlag2 = toggleSwitch12.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag1 = toggleSwitch13.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].VisibleFlag2 = toggleSwitch14.IsOn;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum1 = comboBoxEdit1.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[0].SenserTypeEnum2 = comboBoxEdit2.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum1 = comboBoxEdit3.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[1].SenserTypeEnum2 = comboBoxEdit4.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum1 = comboBoxEdit5.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[3].SenserTypeEnum2 = comboBoxEdit6.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum1 = comboBoxEdit7.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[5].SenserTypeEnum2 = comboBoxEdit8.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum1 = comboBoxEdit9.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[2].SenserTypeEnum2 = comboBoxEdit10.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum1 = comboBoxEdit11.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[4].SenserTypeEnum2 = comboBoxEdit12.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum1 = comboBoxEdit13.SelectedIndex;
                    SettingButtonControl.StraightSenserForm.ScreenMediaSetting.ScreenSwitches[6].SenserTypeEnum2 = comboBoxEdit14.SelectedIndex;
                    #endregion
                    SettingButtonControl.StraightSenserForm.Straight_GIAScreenControl.Change_ScreenMedia(SettingButtonControl.StraightSenserForm.ScreenMediaSetting);
                    InitialMethod.Save_ScreenMedia(SettingButtonControl.StraightSenserForm.ScreenMediaSetting);
                    InitialMethod.Save_MediaPlay(SettingButtonControl.StraightSenserForm.MediaPlaySetting);
                    SettingButtonControl.StraightSenserForm.Straight_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                SettingButtonControl.FlyoutFlag = false;
                SettingButtonControl.flyout.Close();
                /*結束等待畫面*/
                CloseProgressPanel(handle);
            };
            #endregion
        }
        #region 新增項目
        /// <summary>
        /// 感測器項目
        /// </summary>
        /// <param name="comboBox"></param>
        private void SenserItem(ComboBoxEdit comboBox)
        {
            comboBox.Properties.Items.Add("IAQ 室內指數");
            comboBox.Properties.Items.Add("PM2.5 細懸浮微粒");
            comboBox.Properties.Items.Add("PM10 懸浮微粒");
            comboBox.Properties.Items.Add("CO" + "\xb2" + " 二氧化碳");
            comboBox.Properties.Items.Add("TVOC 揮發性有機物");
            comboBox.Properties.Items.Add("HUMI 濕度");
            comboBox.Properties.Items.Add("TEMP 溫度");
            comboBox.Properties.Items.Add("HCHO 甲醛");
            comboBox.Properties.Items.Add("O" + "\xb3" + "臭氧");
            comboBox.Properties.Items.Add("CO 一氧化碳");
            comboBox.Properties.Items.Add("Mold 黴菌");
            comboBox.Properties.Items.Add("PM1 超細懸浮微粒");
            comboBox.Properties.Items.Add("PH 氫離子");
            comboBox.Properties.Items.Add("CL 氯氣");
            comboBox.Properties.Items.Add("TEMP 感測器溫度");
        }
        #endregion
    }
}
