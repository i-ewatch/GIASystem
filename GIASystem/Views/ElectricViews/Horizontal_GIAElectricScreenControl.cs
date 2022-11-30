using DevExpress.XtraEditors;
using GIASystem.Configuration;
using GIASystem.Protocols;
using GIASystem.Protocols.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIASystem.Views.ElectricViews
{
    public partial class Horizontal_GIAElectricScreenControl : Field4UserControl
    {
        /// <summary>
        /// 顏色改變
        /// </summary>
        private Color NewColor { get; set; } = Color.WhiteSmoke;

        private List<ElectricCircleControl> ElectricCircleControls = new List<ElectricCircleControl>();
        private List<ElectricTaskControl> ElectricTaskControls = new List<ElectricTaskControl>();
        private int circelIndex { get; set; } = 0;
        public DateTime CircelTime { get; set; }
        public int CircelIndex
        {
            get { return circelIndex; }
            set
            {
                if (value != circelIndex)
                {
                    circelIndex = value;
                    CircelTime = DateTime.Now;
                }
            }
        }
        private GIAElectricData GIAElectricData { get; set; }
        public Horizontal_GIAElectricScreenControl(List<AbsProtocol> absProtocols, GroupSetting groupSetting)
        {
            InitializeComponent();
            AbsProtocols = absProtocols;
            panelControl1.BackColor = Color.WhiteSmoke;
            pictureEdit.Image = LogoimageCollection.Images[0];
            GroupSetting = groupSetting;
            ElectricTaskControl electricTask1 = new ElectricTaskControl(0, GroupSetting);
            ElectricTaskControl electricTask2 = new ElectricTaskControl(1, GroupSetting);
            ElectricTaskControls.Add(electricTask1);
            panelControl3.Controls.Add(electricTask1);
            ElectricTaskControls.Add(electricTask2);
            panelControl4.Controls.Add(electricTask2);
            foreach (var item in groupSetting.Groups)
            {
                if (ElectricCircleControls.Count < 4)
                {
                    switch (ElectricCircleControls.Count)
                    {
                        case 0:
                            {
                                ElectricCircleControl control = new ElectricCircleControl(null, Color.FromArgb(33, 174, 141), item.GroupName, ElectricCircleControls.Count + 1, this) { Location = new Point(0, 2) };
                                ElectricCircleControls.Add(control);
                                ElectricCircelpanelControl.Controls.Add(control);
                            }
                            break;
                        case 1:
                            {
                                ElectricCircleControl control = new ElectricCircleControl(null, Color.FromArgb(103, 187, 223), item.GroupName, ElectricCircleControls.Count + 1, this) { Location = new Point(120, 2) };
                                ElectricCircleControls.Add(control);
                                ElectricCircelpanelControl.Controls.Add(control);
                            }
                            break;
                        case 2:
                            {
                                ElectricCircleControl control = new ElectricCircleControl(null, Color.FromArgb(240, 93, 125), item.GroupName, ElectricCircleControls.Count + 1, this) { Location = new Point(240, 2) };
                                ElectricCircleControls.Add(control);
                                ElectricCircelpanelControl.Controls.Add(control);
                            }
                            break;
                        case 3:
                            {
                                ElectricCircleControl control = new ElectricCircleControl(null, Color.FromArgb(254, 151, 10), item.GroupName, ElectricCircleControls.Count + 1, this) { Location = new Point(360, 2) };
                                ElectricCircleControls.Add(control);
                                ElectricCircelpanelControl.Controls.Add(control);
                            }
                            break;
                        default:
                            break;
                    }
                }

            }

        }


        #region 圖片顏色變更
        private void LeftpictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Bitmap bmp = new Bitmap($"{MyWorkPath}\\Images\\Circel_left.png"))
            {
                ColorMap[] colorMaps = new ColorMap[1];
                colorMaps[0] = new ColorMap();
                colorMaps[0].OldColor = Color.FromArgb(255, 255, 255);
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
            using (Bitmap bmp = new Bitmap($"{MyWorkPath}\\Images\\Circel_right.png"))
            {
                ColorMap[] colorMaps = new ColorMap[1];
                colorMaps[0] = new ColorMap();
                colorMaps[0].OldColor = Color.FromArgb(255, 255, 255);
                colorMaps[0].NewColor = NewColor;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetRemapTable(colorMaps);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attributes);
            }
        }
        #endregion
        public override void TextChange()
        {
            int Index = 0;
            GIAElectricData = (GIAElectricData)AbsProtocols.SingleOrDefault(g => g.Tag.ToString() == "GIAElectricAPI");
            if (GIAElectricData.ConnectFlag)
            {
                foreach (var item in ElectricCircleControls)
                {
                    if (GIAElectricData.Month_Total_kWh == 0)
                    {
                        item.TotalValue = 100;
                    }
                    else
                    {
                        item.TotalValue = GIAElectricData.Month_Total_kWh;
                    }
                    item.Value = GIAElectricData.GroupkWhs[Index].Month_Total_kWh;
                    item.TextChange();
                    Index++;
                }
                if (CircelIndex != 0)
                {
                    TimeSpan timeSpan = DateTime.Now.Subtract(CircelTime);
                    if (timeSpan.TotalSeconds < 10)
                    {
                        foreach (var item in ElectricTaskControls)
                        {
                            item.CircelIndex = CircelIndex;
                            if (item.DataIndex == 0)
                            {
                                item.Value = GIAElectricData.GroupkWhs[circelIndex - 1].Month_Total_kWh;
                            }
                            else
                            {
                                item.Value = GIAElectricData.GroupkWhs[circelIndex - 1].Month_Total_kWh * GIAElectricData.PriceRate;
                            }
                            item.TextChange();
                        }
                    }
                    else
                    {
                        circelIndex = 0;
                    }
                }
                else if (circelIndex == 0)
                {
                    foreach (var item in ElectricTaskControls)
                    {
                        item.CircelIndex = CircelIndex;
                        if (item.DataIndex == 0)
                        {
                            item.Value = GIAElectricData.Month_Total_kWh;
                        }
                        else
                        {
                            item.Value = GIAElectricData.Month_Total_kWh * GIAElectricData.PriceRate;
                        }
                        item.TextChange();
                    }
                }
            }
        }
    }
}
