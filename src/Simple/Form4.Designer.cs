namespace Simple
{
    partial class Form4
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dxLabel2 = new Netx.Dui.DxControls.Controls.DxLabel();
            this.dxButton2 = new Netx.Dui.DxControls.DxButton();
            this.dxLable1 = new Netx.Dui.DxControls.Controls.DxLabel();
            this.dxButton1 = new Netx.Dui.DxControls.DxButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(213, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 596);
            this.panel1.TabIndex = 3;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // dxLabel2
            // 
            this.dxLabel2.Location = new System.Drawing.Point(12, 140);
            this.dxLabel2.Name = "dxLabel2";
            this.dxLabel2.Size = new System.Drawing.Size(195, 88);
            this.dxLabel2.TabIndex = 4;
            this.dxLabel2.Text = "dxLabel1";
            // 
            // dxButton2
            // 
            this.dxButton2.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.dxButton2.BackGroundDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.dxButton2.BackGroundHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.dxButton2.BackGroundPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(126)))), ((int)(((byte)(204)))));
            this.dxButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dxButton2.DFont = new System.Drawing.Font("宋体", 13F);
            this.dxButton2.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dxButton2.Image = null;
            this.dxButton2.Location = new System.Drawing.Point(13, 84);
            this.dxButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.dxButton2.Name = "dxButton2";
            this.dxButton2.Size = new System.Drawing.Size(85, 35);
            this.dxButton2.TabIndex = 2;
            this.dxButton2.Text = "测试";
            this.dxButton2.Click += new System.EventHandler(this.dxButton2_Click);
            // 
            // dxLable1
            // 
            this.dxLable1.BackColor = System.Drawing.Color.Transparent;
            this.dxLable1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dxLable1.Location = new System.Drawing.Point(125, 19);
            this.dxLable1.Name = "dxLable1";
            this.dxLable1.Size = new System.Drawing.Size(118, 25);
            this.dxLable1.TabIndex = 1;
            this.dxLable1.Text = "测试";
            this.dxLable1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dxButton1
            // 
            this.dxButton1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.dxButton1.BackGroundDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.dxButton1.BackGroundHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.dxButton1.BackGroundPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(126)))), ((int)(((byte)(204)))));
            this.dxButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dxButton1.DFont = new System.Drawing.Font("宋体", 13F);
            this.dxButton1.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dxButton1.Image = null;
            this.dxButton1.Location = new System.Drawing.Point(12, 12);
            this.dxButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.dxButton1.Name = "dxButton1";
            this.dxButton1.Radius = 5F;
            this.dxButton1.Size = new System.Drawing.Size(97, 37);
            this.dxButton1.TabIndex = 0;
            this.dxButton1.Text = "样式切换";
            this.dxButton1.Click += new System.EventHandler(this.dxButton1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.dxLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dxButton2);
            this.Controls.Add(this.dxLable1);
            this.Controls.Add(this.dxButton1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private Netx.Dui.DxControls.DxButton dxButton1;
        private Netx.Dui.DxControls.Controls.DxLabel dxLable1;
        private Netx.Dui.DxControls.DxButton dxButton2;
        private System.Windows.Forms.Panel panel1;
        private Netx.Dui.DxControls.Controls.DxLabel dxLabel2;
    }
}