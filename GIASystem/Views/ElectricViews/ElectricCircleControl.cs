using DevExpress.XtraGauges.Core.Model;
using System;
using System.Drawing;

namespace GIASystem.Views.ElectricViews
{
    public partial class ElectricCircleControl : Field4UserControl
    {
        private Horizontal_ElectricScreenControl Horizontal_ElectricScreenControl { get; set; }
        private Horizontal_GIAElectricScreenControl Horizontal_GIAElectricScreenControl { get; set; }
        private Color NewColor { get; set; }
        public decimal TotalValue { get; set; } = 100;
        public decimal Value { get; set; }
        public int CircelIndex { get; set; }
        public ElectricCircleControl(Horizontal_ElectricScreenControl horizontal_ElectricScreenControl, Color newColor, string name, int circelIndex, Horizontal_GIAElectricScreenControl horizontal_GIAElectricScreenControl = null)
        {
            InitializeComponent();
            arcScaleComponent1.EnableAnimation = true;
            arcScaleComponent1.EasingMode = EasingMode.EaseIn;
            arcScaleComponent1.EasingFunction = new CubicEase();
            Horizontal_ElectricScreenControl = horizontal_ElectricScreenControl;
            Horizontal_GIAElectricScreenControl = horizontal_GIAElectricScreenControl;
            CircelIndex = circelIndex;
            NewColor = newColor;
            gaugeControl1.ColorScheme.Color = NewColor;
            TitallabelControl.Text = name;
            TitallabelControl.Appearance.ForeColor = NewColor;
            TitallabelControl.Click += (s, e) =>
            {
                if (Horizontal_ElectricScreenControl != null)
                {
                    Horizontal_ElectricScreenControl.CircelIndex = CircelIndex;
                }
                else if (Horizontal_GIAElectricScreenControl != null)
                {
                    Horizontal_GIAElectricScreenControl.CircelIndex = CircelIndex;
                }
            };
        }
        public override void TextChange()
        {
            var data = Value / TotalValue;
            labelComponent1.Text = $"{Convert.ToInt32(data * 100)}";
            arcScaleRangeBarComponent1.Value = Convert.ToInt32(data * 100);
        }
    }
}
