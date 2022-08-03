
namespace GIASystem.Views.Setting
{
    partial class MarqueeSettingControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mmt_Marquee = new DevExpress.XtraEditors.MemoEdit();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.mmt_Marquee.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微軟正黑體", 28F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(266, 48);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "跑馬燈文字輸入";
            // 
            // mmt_Marquee
            // 
            this.mmt_Marquee.Location = new System.Drawing.Point(0, 44);
            this.mmt_Marquee.Name = "mmt_Marquee";
            this.mmt_Marquee.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.mmt_Marquee.Properties.Appearance.Options.UseFont = true;
            this.mmt_Marquee.Size = new System.Drawing.Size(609, 186);
            this.mmt_Marquee.TabIndex = 3;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AllowFocus = false;
            this.btn_Cancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_Cancel.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.btn_Cancel.Appearance.Options.UseBackColor = true;
            this.btn_Cancel.Appearance.Options.UseFont = true;
            this.btn_Cancel.Location = new System.Drawing.Point(511, 236);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(94, 40);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "取消";
            // 
            // btn_OK
            // 
            this.btn_OK.AllowFocus = false;
            this.btn_OK.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_OK.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.btn_OK.Appearance.Options.UseBackColor = true;
            this.btn_OK.Appearance.Options.UseFont = true;
            this.btn_OK.Location = new System.Drawing.Point(397, 236);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(94, 40);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "確定";
            // 
            // MarqueeSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.mmt_Marquee);
            this.Controls.Add(this.labelControl1);
            this.Name = "MarqueeSettingControl";
            this.Size = new System.Drawing.Size(609, 283);
            ((System.ComponentModel.ISupportInitialize)(this.mmt_Marquee.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit mmt_Marquee;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
    }
}
