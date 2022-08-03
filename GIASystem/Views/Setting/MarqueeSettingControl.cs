using GIASystem.Methods;

namespace GIASystem.Views.Setting
{
    public partial class MarqueeSettingControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 設定按鈕視窗
        /// </summary>
        private SettingButtonControl SettingButtonControl { get; set; }
        public MarqueeSettingControl(SettingButtonControl settingButtonControl)
        {
            InitializeComponent();
            SettingButtonControl = settingButtonControl;
            if (SettingButtonControl.Horizontal_SenserForm != null)
            {
                mmt_Marquee.Text = SettingButtonControl.Horizontal_SenserForm.MarqueeSetting.MarqueeStr;
            }
            else if (SettingButtonControl.ElectricForm != null)
            {
                mmt_Marquee.Text = SettingButtonControl.ElectricForm.MarqueeSetting.MarqueeStr;
            }
            else if (SettingButtonControl.StraightSenserForm != null)
            {
                mmt_Marquee.Text = SettingButtonControl.StraightSenserForm.MarqueeSetting.MarqueeStr;
            }
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                if (SettingButtonControl.Horizontal_SenserForm != null)
                {
                    SettingButtonControl.Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                    SettingButtonControl.FlyoutFlag = false;
                    SettingButtonControl.flyout.Close();
                }
                else if (SettingButtonControl.ElectricForm != null)
                {
                    SettingButtonControl.ElectricForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                    SettingButtonControl.FlyoutFlag = false;
                    SettingButtonControl.flyout.Close();
                }
                else if (SettingButtonControl.StraightSenserForm != null)
                {
                    SettingButtonControl.StraightSenserForm.Straight_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                    SettingButtonControl.FlyoutFlag = false;
                    SettingButtonControl.flyout.Close();
                }
            };
            #endregion
            #region 確定按鈕
            btn_OK.Click += (s, e) =>
            {
                if (SettingButtonControl.Horizontal_SenserForm != null)
                {
                    SettingButtonControl.Horizontal_SenserForm.MarqueeSetting.MarqueeStr = mmt_Marquee.Text;
                    InitialMethod.Save_Marquee(SettingButtonControl.Horizontal_SenserForm.MarqueeSetting);
                    SettingButtonControl.Horizontal_SenserForm.MarqueeControl.Change_MarqueeText();
                    SettingButtonControl.Horizontal_SenserForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                else if (SettingButtonControl.ElectricForm != null)
                {
                    SettingButtonControl.ElectricForm.MarqueeSetting.MarqueeStr = mmt_Marquee.Text;
                    InitialMethod.Save_Marquee(SettingButtonControl.ElectricForm.MarqueeSetting);
                    SettingButtonControl.ElectricForm.MarqueeControl.Change_MarqueeText();
                    SettingButtonControl.ElectricForm.Horizontal_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                else if (SettingButtonControl.StraightSenserForm != null)
                {
                    SettingButtonControl.StraightSenserForm.MarqueeSetting.MarqueeStr = mmt_Marquee.Text;
                    InitialMethod.Save_Marquee(SettingButtonControl.StraightSenserForm.MarqueeSetting);
                    SettingButtonControl.StraightSenserForm.MarqueeControl.Change_MarqueeText();
                    SettingButtonControl.StraightSenserForm.Straight_GIAScreenControl.LockFlag = SettingButtonControl.AfterLockFlag;
                }
                SettingButtonControl.FlyoutFlag = false;
                SettingButtonControl.flyout.Close();
            };
            #endregion
        }
    }
}
