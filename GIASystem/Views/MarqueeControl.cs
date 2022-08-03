using GIASystem.Configuration;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace GIASystem.Views
{
    public partial class MarqueeControl : Field4UserControl
    {
        public MarqueeControl(MarqueeSetting marqueeSetting, GIAScreenMediaSetting giascreenMediaSetting, Point point)
        {
            InitializeComponent();
            ScreenMediaSetting = giascreenMediaSetting;
            MarqueeSetting = marqueeSetting;
            MarqueelabelControl.Text = marqueeSetting.MarqueeStr;
            Change_MarqueeColor();
            MarqueelabelControl.Location = point;
            timer1.Interval = 20;
            timer1.Enabled = true;
        }
        /// <summary>
        /// 改變跑馬燈顏色
        /// </summary>
        public void Change_MarqueeColor()
        {
            Rpanel = Convert.ToInt32(ScreenMediaSetting.MarqueePanelRGB.Split(',')[0]);
            Gpanel = Convert.ToInt32(ScreenMediaSetting.MarqueePanelRGB.Split(',')[1]);
            Bpanel = Convert.ToInt32(ScreenMediaSetting.MarqueePanelRGB.Split(',')[2]);
            RFore = Convert.ToInt32(ScreenMediaSetting.MarqueeForeRGB.Split(',')[0]);
            GFore = Convert.ToInt32(ScreenMediaSetting.MarqueeForeRGB.Split(',')[1]);
            BFore = Convert.ToInt32(ScreenMediaSetting.MarqueeForeRGB.Split(',')[2]);
            MarqueepanelControl.Appearance.BackColor = Color.FromArgb(Rpanel, Gpanel, Bpanel);
            MarqueelabelControl.Appearance.ForeColor = Color.FromArgb(RFore, GFore, BFore);
        }
        /// <summary>
        /// 改變跑馬燈字串
        /// </summary>
        public void Change_MarqueeText()
        {
            MarqueelabelControl.Location = new Point(1921, 13);
            MarqueelabelControl.Text = MarqueeSetting.MarqueeStr;
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            await marquee();
        }
        #region 委派
        private delegate void label_Point(Point point);
        private void lbl_Point(Point point)
        {
            if (this.InvokeRequired)
            {
                label_Point label_Point = new label_Point(lbl_Point);
                MarqueelabelControl.Invoke(label_Point, point);
            }
            else
            {
                MarqueelabelControl.Location = point;
            }
        }
        #endregion
        Task marquee()
        {
            return Task.Run(() =>
            {
                Point x101 = MarqueelabelControl.Location;
                Size x102 = MarqueelabelControl.Size;
                Size x103 = MarqueepanelControl.Size;
                if (x102.Width + x101.X > 0)
                {
                    //MarqueelabelControl.Location = new Point(x101.X - 2, x101.Y);
                    lbl_Point(new Point(x101.X - 2, x101.Y));
                }
                else
                {
                    //MarqueelabelControl.Location = new Point(x103.Width, x101.Y);
                    lbl_Point(new Point(x103.Width, x101.Y));
                }
            });
        }
    }
}
