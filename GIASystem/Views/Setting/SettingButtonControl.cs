using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace GIASystem.Views.Setting
{
    public partial class SettingButtonControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 感測器含影片
        /// </summary>
        public Horizontal_SenserForm Horizontal_SenserForm { get; set; }
        /// <summary>
        /// 感測器含電表
        /// </summary>
        public Horizontal_ElectricForm ElectricForm { get; set; }
        /// <summary>
        /// 直式 感測器含影片、圖片
        /// </summary>
        public Straight_SenserForm StraightSenserForm { get; set; }
        /// <summary>
        /// 浮動視窗
        /// </summary>
        public FlyoutDialog flyout { get; set; }
        /// <summary>
        /// 浮動視窗旗標
        /// </summary>
        public bool FlyoutFlag { get; set; }
        /// <summary>
        /// 之前畫面鎖定旗標
        /// </summary>
        public bool AfterLockFlag { get; set; }
        public SettingButtonControl(Horizontal_SenserForm horizontal_SenserForm = null, Horizontal_ElectricForm horizontal_ElectricForm = null, Straight_SenserForm straight_SenserForm = null)
        {
            InitializeComponent();
            LocksimpleButton.ImageOptions.Image = imageCollection1.Images[0];
            Horizontal_SenserForm = horizontal_SenserForm;
            ElectricForm = horizontal_ElectricForm;
            StraightSenserForm = straight_SenserForm;
            if (horizontal_SenserForm != null)
            {
            }
            else if (horizontal_ElectricForm != null)
            {
            }
            else if (straight_SenserForm != null)
            {
                Size = new Size(1080, 62);
            }
            #region 關閉視窗
            CloseFormsimpleButton.Click += (s, e) =>
            {
                if (Horizontal_SenserForm != null)
                {
                    Horizontal_SenserForm.Horizontal_SenserForm_FormClosing(null, null);
                }
                else if (ElectricForm != null)
                {
                    ElectricForm.Horizontal_ElectricForm_FormClosing(null, null);
                }
                else if (StraightSenserForm != null)
                {
                    StraightSenserForm.Straight_SenserForm_FormClosing(null, null);
                }
            };
            #endregion
            #region GIA畫面切換鎖定按鈕
            LocksimpleButton.Click += (s, e) =>
            {
                if (Horizontal_SenserForm != null)
                {
                    if (Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag)
                    {
                        LocksimpleButton.ImageOptions.Image = imageCollection1.Images[1];
                        Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = false;
                        AfterLockFlag = false;
                    }
                    else
                    {
                        LocksimpleButton.ImageOptions.Image = imageCollection1.Images[0];
                        Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = true;
                        AfterLockFlag = true;
                    }
                }
                else if (ElectricForm != null)
                {
                    if (ElectricForm.Horizontal_GIAScreenControl.LockFlag)
                    {
                        LocksimpleButton.ImageOptions.Image = imageCollection1.Images[1];
                        ElectricForm.Horizontal_GIAScreenControl.LockFlag = false;
                        AfterLockFlag = false;
                    }
                    else
                    {
                        LocksimpleButton.ImageOptions.Image = imageCollection1.Images[0];
                        ElectricForm.Horizontal_GIAScreenControl.LockFlag = true;
                        AfterLockFlag = true;
                    }
                }
                else if (StraightSenserForm != null)
                {
                    if (StraightSenserForm.Straight_GIAScreenControl.LockFlag)
                    {
                        LocksimpleButton.ImageOptions.Image = imageCollection1.Images[1];
                        StraightSenserForm.Straight_GIAScreenControl.LockFlag = false;
                        AfterLockFlag = false;
                    }
                    else
                    {
                        LocksimpleButton.ImageOptions.Image = imageCollection1.Images[0];
                        StraightSenserForm.Straight_GIAScreenControl.LockFlag = true;
                        AfterLockFlag = true;
                    }
                }
            };
            #endregion
            #region 跑馬燈設定按鈕
            MarqueeSettingsimpleButton.Click += (s, e) =>
            {
                if (Horizontal_SenserForm != null)
                {
                    AfterLockFlag = Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag;
                    Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(609, 283)
                        };
                        flyout = new FlyoutDialog(Horizontal_SenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        MarqueeSettingControl marqueeSetting = new MarqueeSettingControl(this) { Dock = DockStyle.Fill };
                        marqueeSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
                else if (ElectricForm != null)
                {
                    AfterLockFlag = ElectricForm.Horizontal_GIAScreenControl.LockFlag;
                    ElectricForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(609, 283)
                        };
                        flyout = new FlyoutDialog(ElectricForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        MarqueeSettingControl marqueeSetting = new MarqueeSettingControl(this) { Dock = DockStyle.Fill };
                        marqueeSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
                else if (StraightSenserForm != null)
                {
                    AfterLockFlag = StraightSenserForm.Straight_GIAScreenControl.LockFlag;
                    StraightSenserForm.Straight_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(609, 283)
                        };
                        flyout = new FlyoutDialog(StraightSenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        MarqueeSettingControl marqueeSetting = new MarqueeSettingControl(this) { Dock = DockStyle.Fill };
                        marqueeSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
            };
            #endregion
            #region 外觀設定
            ViewSettingsimpleButton.Click += (s, e) =>
            {
                if (Horizontal_SenserForm != null)
                {
                    AfterLockFlag = Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag;
                    Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(910, 504)
                        };
                        flyout = new FlyoutDialog(Horizontal_SenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ViewSettingControl viewSetting = new ViewSettingControl(this);
                        viewSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
                else if (ElectricForm != null)
                {
                    AfterLockFlag = ElectricForm.Horizontal_GIAScreenControl.LockFlag;
                    ElectricForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(910, 504)
                        };
                        flyout = new FlyoutDialog(ElectricForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ViewSettingControl viewSetting = new ViewSettingControl(this);
                        viewSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
                else if (StraightSenserForm != null)
                {
                    AfterLockFlag = StraightSenserForm.Straight_GIAScreenControl.LockFlag;
                    StraightSenserForm.Straight_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(910, 504)
                        };
                        flyout = new FlyoutDialog(StraightSenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ViewSettingControl viewSetting = new ViewSettingControl(this);
                        viewSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
            };
            #endregion
            #region 系統設定
            SystemSettingsimpleButton.Click += (s, e) =>
            {
                if (Horizontal_SenserForm != null)
                {
                    AfterLockFlag = Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag;
                    Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(1299, 702)
                        };
                        flyout = new FlyoutDialog(Horizontal_SenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ScreenSettingControl screenSetting = new ScreenSettingControl(this) { Dock = DockStyle.Fill };
                        screenSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
                else if (ElectricForm != null)
                {
                    AfterLockFlag = ElectricForm.Horizontal_GIAScreenControl.LockFlag;
                    ElectricForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(1299, 702)
                        };
                        flyout = new FlyoutDialog(ElectricForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ScreenSettingControl screenSetting = new ScreenSettingControl(this) { Dock = DockStyle.Fill };
                        screenSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
                else if (StraightSenserForm != null)
                {
                    AfterLockFlag = StraightSenserForm.Straight_GIAScreenControl.LockFlag;
                    StraightSenserForm.Straight_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(1080, 702)
                        };
                        flyout = new FlyoutDialog(StraightSenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ScreenSettingControl screenSetting = new ScreenSettingControl(this) { Dock = DockStyle.Fill };
                        screenSetting.Parent = panelControl;
                        flyout.Show();
                    }
                    else
                    {
                        FlyoutFlag = false;
                        flyout.Close();
                    }
                }
            };
            #endregion
            #region 通訊測試
            ProtocolsimpleButton.Click += (s, e) =>
            {
                if (Horizontal_SenserForm != null)
                {
                    AfterLockFlag = Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag;
                    Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(650, 261)
                        };
                        flyout = new FlyoutDialog(Horizontal_SenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ProtocolSettingControl viewSetting = new ProtocolSettingControl(this, Horizontal_SenserForm.GateWaySetting, Horizontal_SenserForm.Taiwan_DistricsSetting, Horizontal_SenserForm.GIA_DistricsSetting);
                        viewSetting.Parent = panelControl;
                        flyout.Show();
                    }
                }
                else if (ElectricForm != null)
                {
                    AfterLockFlag = ElectricForm.Horizontal_GIAScreenControl.LockFlag;
                    ElectricForm.Horizontal_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(650, 261)
                        };
                        flyout = new FlyoutDialog(ElectricForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ProtocolSettingControl viewSetting = new ProtocolSettingControl(this, ElectricForm.GateWaySetting, ElectricForm.Taiwan_DistricsSetting, ElectricForm.GIA_DistricsSetting);
                        viewSetting.Parent = panelControl;
                        flyout.Show();
                    }
                }
                else if (StraightSenserForm != null)
                {
                    AfterLockFlag = StraightSenserForm.Straight_GIAScreenControl.LockFlag;
                    StraightSenserForm.Straight_GIAScreenControl.LockFlag = false;
                    if (!FlyoutFlag)
                    {
                        FlyoutFlag = true;
                        PanelControl panelControl = new PanelControl()
                        {
                            Size = new Size(650, 261)
                        };
                        flyout = new FlyoutDialog(StraightSenserForm, panelControl);
                        flyout.Properties.Style = FlyoutStyle.Popup;
                        ProtocolSettingControl viewSetting = new ProtocolSettingControl(this, StraightSenserForm.GateWaySetting, StraightSenserForm.Taiwan_DistricsSetting, StraightSenserForm.GIA_DistricsSetting);
                        viewSetting.Parent = panelControl;
                        flyout.Show();
                    }
                }
            };
            #endregion
        }
        #region 重新啟動
        public void Restart()
        {
            if (Horizontal_SenserForm != null)
            {
                Horizontal_SenserForm.Restart();
            }
            else if (ElectricForm != null)
            {
                ElectricForm.Restart();
            }
            else if (StraightSenserForm != null)
            {
                StraightSenserForm.Restart();
            }
        }
        #endregion
    }
}
