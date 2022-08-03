﻿using GIASystem.Configuration;
using GIASystem.Methods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GIASystem.Views.ElectricViews
{
    public partial class Horizontal_ElectricScreenControl : Field4UserControl
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
        private List<decimal> value { get; set; } = new List<decimal>();
        private List<decimal> pricevalue { get; set; } = new List<decimal>();

        private decimal Money { get; set; }
        private decimal kwh { get; set; }
        public Horizontal_ElectricScreenControl(SqlMethod sqlMethod, GroupSetting groupSetting, GateWaySetting gateWaySetting)
        {
            InitializeComponent();
            panelControl1.BackColor = Color.WhiteSmoke;
            pictureEdit.Image = LogoimageCollection.Images[0];
            GroupSetting = groupSetting;
            GateWaySetting = gateWaySetting;
            SqlMethod = sqlMethod;
            value.Clear();
            pricevalue.Clear();
            foreach (var item in groupSetting.Groups)
            {
                if (value.Count < 4 & value.Count > 0)
                {
                    var data = sqlMethod.Serch_TotalMeter_Circel(GroupSetting, item.GroupIndex, 0);
                    var Pricedata = sqlMethod.Serch_TotalMeter_Circel(GroupSetting, item.GroupIndex, 1);
                    value.Add(data);
                    pricevalue.Add(Pricedata);
                }
            }
            for (int i = 0; i < value.Count; i++)
            {
                kwh = kwh + value[i];
                Money = Money + pricevalue[i];
            }
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
                                ElectricCircleControl control = new ElectricCircleControl(this, Color.FromArgb(33, 174, 141), item.GroupName, ElectricCircleControls.Count + 1) { Location = new Point(0, 2) };
                                ElectricCircleControls.Add(control);
                                ElectricCircelpanelControl.Controls.Add(control);
                            }
                            break;
                        case 1:
                            {
                                ElectricCircleControl control = new ElectricCircleControl(this, Color.FromArgb(103, 187, 223), item.GroupName, ElectricCircleControls.Count + 1) { Location = new Point(120, 2) };
                                ElectricCircleControls.Add(control);
                                ElectricCircelpanelControl.Controls.Add(control);
                            }
                            break;
                        case 2:
                            {
                                ElectricCircleControl control = new ElectricCircleControl(this, Color.FromArgb(240, 93, 125), item.GroupName, ElectricCircleControls.Count + 1) { Location = new Point(240, 2) };
                                ElectricCircleControls.Add(control);
                                ElectricCircelpanelControl.Controls.Add(control);
                            }
                            break;
                        case 3:
                            {
                                ElectricCircleControl control = new ElectricCircleControl(this, Color.FromArgb(254, 151, 10), item.GroupName, ElectricCircleControls.Count + 1) { Location = new Point(360, 2) };
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

        #region 顯示變更
        public override void TextChange()
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(CircelTime);
            if (timeSpan.TotalMinutes > 1)
            {
                int Index = 0;
                kwh = 0;
                Money = 0;
                value.Clear();
                pricevalue.Clear();
                foreach (var item in GroupSetting.Groups)
                {
                    if (value.Count < 4)
                    {
                        var data = SqlMethod.Serch_TotalMeter_Circel(GroupSetting, item.GroupIndex, 0);
                        var Pricedata = SqlMethod.Serch_TotalMeter_Circel(GroupSetting, item.GroupIndex, 1);
                        value.Add(data);
                        pricevalue.Add(Pricedata);
                    }
                }
                for (int i = 0; i < value.Count; i++)
                {
                    kwh = kwh + value[i];
                    Money = Money + pricevalue[i];
                }
                foreach (var item in ElectricCircleControls)
                {
                    if (kwh == 0)
                    {
                        item.TotalValue = 100;
                    }
                    else
                    {
                        item.TotalValue = kwh;
                    }
                    item.Value = value[Index];
                    item.TextChange();
                    Index++;
                }
                if (circelIndex != 0)
                {
                    foreach (var item in ElectricTaskControls)
                    {
                        item.CircelIndex = CircelIndex;
                        if (item.DataIndex == 0)
                        {
                            item.Value = value[circelIndex - 1];
                        }
                        else
                        {
                            item.Value = pricevalue[circelIndex - 1];
                        }
                        item.TextChange();
                    }
                    circelIndex = 0;
                    foreach (var item in ElectricTaskControls)
                    {
                        item.CircelIndex = CircelIndex;
                        if (item.DataIndex == 0)
                        {
                            item.Value = kwh;
                        }
                        else
                        {
                            item.Value = Money;
                        }
                        item.TextChange();
                    }
                }
                else if (circelIndex == 0)
                {
                    foreach (var item in ElectricTaskControls)
                    {
                        item.CircelIndex = CircelIndex;
                        if (item.DataIndex == 0)
                        {
                            item.Value = kwh;
                        }
                        else
                        {
                            item.Value = Money;
                        }
                        item.TextChange();
                    }
                }
            }
        }
        #endregion
    }
}
