using DevExpress.XtraBars.Navigation;
using GIASystem.Configuration;
using GIASystem.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GIASystem.Views.GIAViews
{
    public partial class Horizontal_GIAScreenControl : Field4UserControl
    {
        /// <summary>
        /// 切換畫面頁數
        /// </summary>
        private int PageIndex { get; set; } = 0;
        /// <summary>
        /// 切換畫面最後時間
        /// </summary>
        private DateTime PageTime { get; set; }
        private GateWaySenserID GateWaySenserID { get; set; }
        private GateWayAPI GateWayAPI { get; set; }
        /// <summary>
        /// (大)總畫面物件
        /// </summary>
        private List<Field4UserControl> BigUserControls { get; set; } = new List<Field4UserControl>();
        /// <summary>
        /// (小)總畫面物件
        /// </summary>
        private List<Field4UserControl> SmallUserControls { get; set; } = new List<Field4UserControl>();
        /// <summary>
        /// 畫面切換鎖定 True = 不鎖定 ,False = 鎖定
        /// </summary>
        public bool LockFlag { get; set; } = true;
        public Horizontal_GIAScreenControl(GateWay gateWay, List<Taiwan_DistricsSetting> taiwan_DistricsSetting, GIAScreenMediaSetting screenMediaSetting, List<AbsProtocol> absProtocols)
        {
            InitializeComponent();
            radioGroup1.Visible = false;
            radioGroup2.Visible = false;
            radioGroup3.Visible = false;
            radioGroup4.Visible = false;
            radioGroup5.Visible = false;
            radioGroup6.Visible = false;
            radioGroup7.Visible = false;

            ScreenMediaSetting = screenMediaSetting;
            GateWay = gateWay;
            AbsProtocols = absProtocols;
            GateWaySenserID = gateWay.GateWaySenserIDs.SingleOrDefault(g => g.SenserEnumType == 2);
            GateWayAPI = gateWay.GateWayAPIs.SingleOrDefault(g => g.APIEnumType == 1);
            Change_ScreenMedia(screenMediaSetting);
        }
        #region 變更感測器顯示
        /// <summary>
        /// 變更感測器顯示
        /// </summary>
        /// <param name="screen"></param>
        public void Change_ScreenMedia(GIAScreenMediaSetting screen)
        {
            if (BigUserControls.Count > 0)
            {
                BigUserControls.Clear();
            }
            if (SmallUserControls.Count > 0)
            {
                SmallUserControls.Clear();
            }
            Change_BigScreenMedia(screen, Bignavigation);
            Change_SmallScreenMedia(screen, Smallnavigation1, 1);
            Change_SmallScreenMedia(screen, Smallnavigation2, 2);
            Change_SmallScreenMedia(screen, Smallnavigation3, 3);
            Change_SmallScreenMedia(screen, Smallnavigation4, 4);
            Change_SmallScreenMedia(screen, Smallnavigation5, 5);
            Change_SmallScreenMedia(screen, Smallnavigation6, 6);
            PageTime = DateTime.Now;
            #region 切換畫面
            PageIndex = 0;
            Bignavigation.SelectedPageIndex = PageIndex;
            Smallnavigation1.SelectedPageIndex = PageIndex;
            Smallnavigation2.SelectedPageIndex = PageIndex;
            Smallnavigation3.SelectedPageIndex = PageIndex;
            Smallnavigation4.SelectedPageIndex = PageIndex;
            Smallnavigation5.SelectedPageIndex = PageIndex;
            Smallnavigation6.SelectedPageIndex = PageIndex;
            #endregion
        }
        /// <summary>
        /// 大畫面感測器
        /// </summary>
        /// <param name="screen">畫面資訊</param>
        /// <param name="navigation">切換畫面物件</param>
        private void Change_BigScreenMedia(GIAScreenMediaSetting screen, NavigationFrame navigation)
        {
            if (navigation.Pages.Count > 0)
            {
                navigation.Pages.Clear();
            }
            if (!screen.ScreenSwitches[0].VisibleFlag1 && !screen.ScreenSwitches[0].VisibleFlag2)
            {
                navigation.Visible = false;
            }
            else
            {
                navigation.Visible = true;
                if (screen.ScreenSwitches[0].VisibleFlag1)
                {
                    Horizontal_GIABigControl bigSenser = new Horizontal_GIABigControl(screen.ScreenSwitches[0].SenserTypeEnum1, GateWay, GateWaySenserID, GateWayAPI, screen, false) { Dock = DockStyle.Fill };
                    BigUserControls.Add(bigSenser);
                    navigation.AddPage(bigSenser);
                }
                if (screen.ScreenSwitches[0].VisibleFlag2)
                {
                    Horizontal_GIABigControl bigSenser = new Horizontal_GIABigControl(screen.ScreenSwitches[0].SenserTypeEnum2, GateWay, GateWaySenserID, GateWayAPI, screen, false) { Dock = DockStyle.Fill };
                    BigUserControls.Add(bigSenser);
                    navigation.AddPage(bigSenser);
                }
                navigation.SelectedPageIndex = 0;
            }
        }
        /// <summary>
        /// 小畫面感測器
        /// </summary>
        /// <param name="screen">畫面資訊</param>
        /// <param name="navigation">切換畫面物件</param>
        /// <param name="Index">小畫面編號</param>
        private void Change_SmallScreenMedia(GIAScreenMediaSetting screen, NavigationFrame navigation, int Index)
        {
            if (navigation.Pages.Count > 0)
            {
                navigation.Pages.Clear();
            }
            if (!screen.ScreenSwitches[Index].VisibleFlag1 && !screen.ScreenSwitches[Index].VisibleFlag2)
            {
                navigation.Visible = false;
            }
            else
            {
                navigation.Visible = true;
                if (screen.ScreenSwitches[Index].VisibleFlag1)
                {
                    Horizontal_GIASmallControl smallSenser = new Horizontal_GIASmallControl(screen.ScreenSwitches[Index].SenserTypeEnum1, GateWay, GateWaySenserID, GateWayAPI, screen, false) { Dock = DockStyle.Fill };
                    SmallUserControls.Add(smallSenser);
                    navigation.AddPage(smallSenser);
                }
                if (screen.ScreenSwitches[Index].VisibleFlag2)
                {
                    Horizontal_GIASmallControl smallSenser = new Horizontal_GIASmallControl(screen.ScreenSwitches[Index].SenserTypeEnum2, GateWay, GateWaySenserID, GateWayAPI, screen, false) { Dock = DockStyle.Fill };
                    SmallUserControls.Add(smallSenser);
                    navigation.AddPage(smallSenser);
                }
                navigation.SelectedPageIndex = 0;
                PageIndex = 0;
            }
        }
        #endregion

        #region 顯示變更
        public override void TextChange()
        {
            #region 切換畫面功能
            TimeSpan timeSpan = DateTime.Now.Subtract(PageTime);
            if (timeSpan.TotalSeconds > ScreenMediaSetting.ChangePageSec)
            {
                if (LockFlag)
                {
                    if (PageIndex == 1)
                    {
                        PageIndex = 0;
                    }
                    else
                    {
                        PageIndex++;
                    }
                    radioGroup1.SelectedIndex = PageIndex;
                    radioGroup2.SelectedIndex = PageIndex;
                    radioGroup3.SelectedIndex = PageIndex;
                    radioGroup4.SelectedIndex = PageIndex;
                    radioGroup5.SelectedIndex = PageIndex;
                    radioGroup6.SelectedIndex = PageIndex;
                    radioGroup7.SelectedIndex = PageIndex;
                }
                PageTime = DateTime.Now;
            }
            #endregion
            TimeSpan Senserspan = DateTime.Now.Subtract(RefreshTime);
            if (Senserspan.TotalSeconds >= 2)
            {
                if (AbsProtocols != null)
                {
                    if (Bignavigation.SelectedPageIndex > -1)
                    {
                        var bigsenser = (Horizontal_GIABigControl)Bignavigation.Pages[Bignavigation.SelectedPageIndex].Controls[0];
                        bigsenser.AbsProtocols = AbsProtocols;
                        bigsenser.TextChange();
                    }
                    if (Smallnavigation1.SelectedPageIndex > -1)
                    {
                        var smallsenser1 = (Horizontal_GIASmallControl)Smallnavigation1.Pages[Smallnavigation1.SelectedPageIndex].Controls[0];
                        smallsenser1.AbsProtocols = AbsProtocols;
                        smallsenser1.TextChange();
                    }
                    if (Smallnavigation2.SelectedPageIndex > -1)
                    {
                        var smallsenser2 = (Horizontal_GIASmallControl)Smallnavigation2.Pages[Smallnavigation2.SelectedPageIndex].Controls[0];
                        smallsenser2.AbsProtocols = AbsProtocols;
                        smallsenser2.TextChange();
                    }
                    if (Smallnavigation3.SelectedPageIndex > -1)
                    {
                        var smallsenser3 = (Horizontal_GIASmallControl)Smallnavigation3.Pages[Smallnavigation3.SelectedPageIndex].Controls[0];
                        smallsenser3.AbsProtocols = AbsProtocols;
                        smallsenser3.TextChange();
                    }
                    if (Smallnavigation4.SelectedPageIndex > -1)
                    {
                        var smallsenser4 = (Horizontal_GIASmallControl)Smallnavigation4.Pages[Smallnavigation4.SelectedPageIndex].Controls[0];
                        smallsenser4.AbsProtocols = AbsProtocols;
                        smallsenser4.TextChange();
                    }
                    if (Smallnavigation5.SelectedPageIndex > -1)
                    {
                        var smallsenser5 = (Horizontal_GIASmallControl)Smallnavigation5.Pages[Smallnavigation5.SelectedPageIndex].Controls[0];
                        smallsenser5.AbsProtocols = AbsProtocols;
                        smallsenser5.TextChange();
                    }
                    if (Smallnavigation6.SelectedPageIndex > -1)
                    {
                        var smallsenser6 = (Horizontal_GIASmallControl)Smallnavigation6.Pages[Smallnavigation6.SelectedPageIndex].Controls[0];
                        smallsenser6.AbsProtocols = AbsProtocols;
                        smallsenser6.TextChange();
                    }
                    RefreshTime = DateTime.Now;
                }
            }
        }
        #endregion
    }
}
