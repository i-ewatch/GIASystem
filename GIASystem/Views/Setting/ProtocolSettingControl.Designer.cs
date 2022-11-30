
namespace GIASystem.Views.Setting
{
    partial class ProtocolSettingControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState5 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState6 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState7 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState8 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            this.ProtocolTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.RS485TabPage = new DevExpress.XtraTab.XtraTabPage();
            this.RS485_IDtextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RS485_COMcomboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TCPTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.TCP_IDtextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TCP_IPtextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.APITabPage = new DevExpress.XtraTab.XtraTabPage();
            this.URLtextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Protocol_TypecomboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ProtocollabelControl = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.stateIndicatorComponent1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.ProtocolsimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.DistrictscomboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.WeathercomboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.SettingpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.ElectricURLtextEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolTabControl)).BeginInit();
            this.ProtocolTabControl.SuspendLayout();
            this.RS485TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RS485_IDtextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RS485_COMcomboBoxEdit.Properties)).BeginInit();
            this.TCPTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TCP_IDtextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCP_IPtextEdit.Properties)).BeginInit();
            this.APITabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.URLtextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Protocol_TypecomboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistrictscomboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeathercomboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingpanelControl)).BeginInit();
            this.SettingpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElectricURLtextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ProtocolTabControl
            // 
            this.ProtocolTabControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ProtocolTabControl.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ProtocolTabControl.Location = new System.Drawing.Point(11, 65);
            this.ProtocolTabControl.Name = "ProtocolTabControl";
            this.ProtocolTabControl.SelectedTabPage = this.RS485TabPage;
            this.ProtocolTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.ProtocolTabControl.Size = new System.Drawing.Size(621, 77);
            this.ProtocolTabControl.TabIndex = 5;
            this.ProtocolTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.RS485TabPage,
            this.TCPTabPage,
            this.APITabPage});
            // 
            // RS485TabPage
            // 
            this.RS485TabPage.Controls.Add(this.RS485_IDtextEdit);
            this.RS485TabPage.Controls.Add(this.RS485_COMcomboBoxEdit);
            this.RS485TabPage.Controls.Add(this.labelControl3);
            this.RS485TabPage.Controls.Add(this.labelControl2);
            this.RS485TabPage.Name = "RS485TabPage";
            this.RS485TabPage.Size = new System.Drawing.Size(619, 23);
            this.RS485TabPage.Text = "RS485TabPage";
            // 
            // RS485_IDtextEdit
            // 
            this.RS485_IDtextEdit.Location = new System.Drawing.Point(416, 12);
            this.RS485_IDtextEdit.Name = "RS485_IDtextEdit";
            this.RS485_IDtextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.RS485_IDtextEdit.Properties.Appearance.Options.UseFont = true;
            this.RS485_IDtextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.RS485_IDtextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RS485_IDtextEdit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.RS485_IDtextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.RS485_IDtextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.RS485_IDtextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RS485_IDtextEdit.Size = new System.Drawing.Size(155, 26);
            this.RS485_IDtextEdit.TabIndex = 5;
            // 
            // RS485_COMcomboBoxEdit
            // 
            this.RS485_COMcomboBoxEdit.Location = new System.Drawing.Point(102, 13);
            this.RS485_COMcomboBoxEdit.Name = "RS485_COMcomboBoxEdit";
            this.RS485_COMcomboBoxEdit.Properties.AllowFocused = false;
            this.RS485_COMcomboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.RS485_COMcomboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.RS485_COMcomboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.RS485_COMcomboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RS485_COMcomboBoxEdit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.RS485_COMcomboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.RS485_COMcomboBoxEdit.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.RS485_COMcomboBoxEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RS485_COMcomboBoxEdit.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("Tahoma", 12F);
            this.RS485_COMcomboBoxEdit.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.RS485_COMcomboBoxEdit.Properties.AppearanceItemSelected.Options.UseTextOptions = true;
            this.RS485_COMcomboBoxEdit.Properties.AppearanceItemSelected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RS485_COMcomboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RS485_COMcomboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.RS485_COMcomboBoxEdit.Size = new System.Drawing.Size(155, 26);
            this.RS485_COMcomboBoxEdit.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(43, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 19);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "COM :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(327, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "ID :";
            // 
            // TCPTabPage
            // 
            this.TCPTabPage.Controls.Add(this.TCP_IDtextEdit);
            this.TCPTabPage.Controls.Add(this.TCP_IPtextEdit);
            this.TCPTabPage.Controls.Add(this.labelControl4);
            this.TCPTabPage.Controls.Add(this.labelControl5);
            this.TCPTabPage.Name = "TCPTabPage";
            this.TCPTabPage.Size = new System.Drawing.Size(619, 49);
            this.TCPTabPage.Text = "TCPTabPage";
            // 
            // TCP_IDtextEdit
            // 
            this.TCP_IDtextEdit.Location = new System.Drawing.Point(416, 12);
            this.TCP_IDtextEdit.Name = "TCP_IDtextEdit";
            this.TCP_IDtextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TCP_IDtextEdit.Properties.Appearance.Options.UseFont = true;
            this.TCP_IDtextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.TCP_IDtextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TCP_IDtextEdit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TCP_IDtextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.TCP_IDtextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.TCP_IDtextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TCP_IDtextEdit.Size = new System.Drawing.Size(155, 26);
            this.TCP_IDtextEdit.TabIndex = 7;
            // 
            // TCP_IPtextEdit
            // 
            this.TCP_IPtextEdit.Location = new System.Drawing.Point(102, 13);
            this.TCP_IPtextEdit.Name = "TCP_IPtextEdit";
            this.TCP_IPtextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TCP_IPtextEdit.Properties.Appearance.Options.UseFont = true;
            this.TCP_IPtextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.TCP_IPtextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TCP_IPtextEdit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TCP_IPtextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.TCP_IPtextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.TCP_IPtextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TCP_IPtextEdit.Size = new System.Drawing.Size(155, 26);
            this.TCP_IPtextEdit.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(62, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 19);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "IP :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(327, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 19);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "ID :";
            // 
            // APITabPage
            // 
            this.APITabPage.Controls.Add(this.ElectricURLtextEdit);
            this.APITabPage.Controls.Add(this.labelControl9);
            this.APITabPage.Controls.Add(this.URLtextEdit);
            this.APITabPage.Controls.Add(this.labelControl6);
            this.APITabPage.Name = "APITabPage";
            this.APITabPage.Size = new System.Drawing.Size(619, 75);
            this.APITabPage.Text = "APITabPage";
            // 
            // URLtextEdit
            // 
            this.URLtextEdit.Location = new System.Drawing.Point(105, 9);
            this.URLtextEdit.Name = "URLtextEdit";
            this.URLtextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.URLtextEdit.Properties.Appearance.Options.UseFont = true;
            this.URLtextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.URLtextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.URLtextEdit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.URLtextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.URLtextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.URLtextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.URLtextEdit.Size = new System.Drawing.Size(504, 26);
            this.URLtextEdit.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(29, 13);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(73, 19);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "GIA URL :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 19);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "通訊類型選擇";
            // 
            // Protocol_TypecomboBoxEdit
            // 
            this.Protocol_TypecomboBoxEdit.Location = new System.Drawing.Point(139, 29);
            this.Protocol_TypecomboBoxEdit.Name = "Protocol_TypecomboBoxEdit";
            this.Protocol_TypecomboBoxEdit.Properties.AllowFocused = false;
            this.Protocol_TypecomboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Protocol_TypecomboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.Protocol_TypecomboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.Protocol_TypecomboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceItemSelected.Options.UseTextOptions = true;
            this.Protocol_TypecomboBoxEdit.Properties.AppearanceItemSelected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Protocol_TypecomboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Protocol_TypecomboBoxEdit.Properties.Items.AddRange(new object[] {
            "RS485",
            "TCP",
            "API"});
            this.Protocol_TypecomboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Protocol_TypecomboBoxEdit.Size = new System.Drawing.Size(155, 26);
            this.Protocol_TypecomboBoxEdit.TabIndex = 3;
            // 
            // ProtocollabelControl
            // 
            this.ProtocollabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ProtocollabelControl.Appearance.Options.UseFont = true;
            this.ProtocollabelControl.Location = new System.Drawing.Point(535, 33);
            this.ProtocollabelControl.Name = "ProtocollabelControl";
            this.ProtocollabelControl.Size = new System.Drawing.Size(6, 19);
            this.ProtocollabelControl.TabIndex = 15;
            this.ProtocollabelControl.Text = "-";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.gaugeControl1);
            this.groupControl1.Controls.Add(this.ProtocollabelControl);
            this.groupControl1.Controls.Add(this.ProtocolsimpleButton);
            this.groupControl1.Controls.Add(this.ProtocolTabControl);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.Protocol_TypecomboBoxEdit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(646, 148);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "通訊設定";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(489, 22);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(40, 40);
            this.gaugeControl1.TabIndex = 16;
            // 
            // stateIndicatorGauge1
            // 
            this.stateIndicatorGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 28, 28);
            this.stateIndicatorGauge1.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.stateIndicatorComponent1});
            this.stateIndicatorGauge1.Name = "stateIndicatorGauge1";
            // 
            // stateIndicatorComponent1
            // 
            this.stateIndicatorComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.stateIndicatorComponent1.Name = "stateIndicatorComponent1";
            this.stateIndicatorComponent1.Size = new System.Drawing.SizeF(200F, 200F);
            this.stateIndicatorComponent1.StateIndex = 0;
            indicatorState5.Name = "State1";
            indicatorState5.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState6.Name = "State2";
            indicatorState6.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState7.Name = "State3";
            indicatorState7.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight3;
            indicatorState8.Name = "State4";
            indicatorState8.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.stateIndicatorComponent1.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState5,
            indicatorState6,
            indicatorState7,
            indicatorState8});
            // 
            // ProtocolsimpleButton
            // 
            this.ProtocolsimpleButton.AllowFocus = false;
            this.ProtocolsimpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ProtocolsimpleButton.Appearance.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.ProtocolsimpleButton.Appearance.Options.UseBackColor = true;
            this.ProtocolsimpleButton.Appearance.Options.UseFont = true;
            this.ProtocolsimpleButton.Location = new System.Drawing.Point(339, 27);
            this.ProtocolsimpleButton.Name = "ProtocolsimpleButton";
            this.ProtocolsimpleButton.Size = new System.Drawing.Size(132, 30);
            this.ProtocolsimpleButton.TabIndex = 13;
            this.ProtocolsimpleButton.Text = "通訊測試";
            // 
            // DistrictscomboBoxEdit
            // 
            this.DistrictscomboBoxEdit.Location = new System.Drawing.Point(448, 34);
            this.DistrictscomboBoxEdit.Name = "DistrictscomboBoxEdit";
            this.DistrictscomboBoxEdit.Properties.AllowFocused = false;
            this.DistrictscomboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.DistrictscomboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.DistrictscomboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DistrictscomboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DistrictscomboBoxEdit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.DistrictscomboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.DistrictscomboBoxEdit.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.DistrictscomboBoxEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DistrictscomboBoxEdit.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("Tahoma", 12F);
            this.DistrictscomboBoxEdit.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.DistrictscomboBoxEdit.Properties.AppearanceItemSelected.Options.UseTextOptions = true;
            this.DistrictscomboBoxEdit.Properties.AppearanceItemSelected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DistrictscomboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DistrictscomboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.DistrictscomboBoxEdit.Size = new System.Drawing.Size(155, 26);
            this.DistrictscomboBoxEdit.TabIndex = 10;
            // 
            // WeathercomboBoxEdit
            // 
            this.WeathercomboBoxEdit.Location = new System.Drawing.Point(139, 35);
            this.WeathercomboBoxEdit.Name = "WeathercomboBoxEdit";
            this.WeathercomboBoxEdit.Properties.AllowFocused = false;
            this.WeathercomboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.WeathercomboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.WeathercomboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.WeathercomboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WeathercomboBoxEdit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.WeathercomboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.WeathercomboBoxEdit.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.WeathercomboBoxEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WeathercomboBoxEdit.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("Tahoma", 12F);
            this.WeathercomboBoxEdit.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.WeathercomboBoxEdit.Properties.AppearanceItemSelected.Options.UseTextOptions = true;
            this.WeathercomboBoxEdit.Properties.AppearanceItemSelected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WeathercomboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.WeathercomboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.WeathercomboBoxEdit.Size = new System.Drawing.Size(155, 26);
            this.WeathercomboBoxEdit.TabIndex = 9;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(328, 38);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(107, 19);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "顯示地區選擇 :";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(19, 38);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(107, 19);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "天氣地區選擇 :";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AllowFocus = false;
            this.btn_Cancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_Cancel.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.btn_Cancel.Appearance.Options.UseBackColor = true;
            this.btn_Cancel.Appearance.Options.UseFont = true;
            this.btn_Cancel.Location = new System.Drawing.Point(553, 225);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(94, 35);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "取消";
            // 
            // btn_OK
            // 
            this.btn_OK.AllowFocus = false;
            this.btn_OK.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_OK.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.btn_OK.Appearance.Options.UseBackColor = true;
            this.btn_OK.Appearance.Options.UseFont = true;
            this.btn_OK.Location = new System.Drawing.Point(439, 225);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(94, 35);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "確定";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.DistrictscomboBoxEdit);
            this.groupControl2.Controls.Add(this.WeathercomboBoxEdit);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(2, 150);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(646, 69);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "天氣設定";
            // 
            // SettingpanelControl
            // 
            this.SettingpanelControl.Controls.Add(this.btn_Cancel);
            this.SettingpanelControl.Controls.Add(this.btn_OK);
            this.SettingpanelControl.Controls.Add(this.groupControl2);
            this.SettingpanelControl.Controls.Add(this.groupControl1);
            this.SettingpanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingpanelControl.Location = new System.Drawing.Point(0, 0);
            this.SettingpanelControl.Name = "SettingpanelControl";
            this.SettingpanelControl.Size = new System.Drawing.Size(650, 261);
            this.SettingpanelControl.TabIndex = 1;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(7, 47);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(95, 19);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "Electric URL :";
            // 
            // ElectricURLtextEdit
            // 
            this.ElectricURLtextEdit.Location = new System.Drawing.Point(105, 44);
            this.ElectricURLtextEdit.Name = "ElectricURLtextEdit";
            this.ElectricURLtextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ElectricURLtextEdit.Properties.Appearance.Options.UseFont = true;
            this.ElectricURLtextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ElectricURLtextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ElectricURLtextEdit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ElectricURLtextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.ElectricURLtextEdit.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.ElectricURLtextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ElectricURLtextEdit.Size = new System.Drawing.Size(504, 26);
            this.ElectricURLtextEdit.TabIndex = 9;
            // 
            // ProtocolSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingpanelControl);
            this.Name = "ProtocolSettingControl";
            this.Size = new System.Drawing.Size(650, 261);
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolTabControl)).EndInit();
            this.ProtocolTabControl.ResumeLayout(false);
            this.RS485TabPage.ResumeLayout(false);
            this.RS485TabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RS485_IDtextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RS485_COMcomboBoxEdit.Properties)).EndInit();
            this.TCPTabPage.ResumeLayout(false);
            this.TCPTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TCP_IDtextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCP_IPtextEdit.Properties)).EndInit();
            this.APITabPage.ResumeLayout(false);
            this.APITabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.URLtextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Protocol_TypecomboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistrictscomboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeathercomboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingpanelControl)).EndInit();
            this.SettingpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElectricURLtextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl ProtocolTabControl;
        private DevExpress.XtraTab.XtraTabPage RS485TabPage;
        private DevExpress.XtraEditors.TextEdit RS485_IDtextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit RS485_COMcomboBoxEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTab.XtraTabPage TCPTabPage;
        private DevExpress.XtraEditors.TextEdit TCP_IDtextEdit;
        private DevExpress.XtraEditors.TextEdit TCP_IPtextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraTab.XtraTabPage APITabPage;
        private DevExpress.XtraEditors.TextEdit URLtextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit Protocol_TypecomboBoxEdit;
        private DevExpress.XtraEditors.LabelControl ProtocollabelControl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton ProtocolsimpleButton;
        private DevExpress.XtraEditors.ComboBoxEdit DistrictscomboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit WeathercomboBoxEdit;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl SettingpanelControl;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent stateIndicatorComponent1;
        private DevExpress.XtraEditors.TextEdit ElectricURLtextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}
