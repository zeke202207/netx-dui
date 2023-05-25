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
            this.dxButton1 = new Netx.Dui.DxControls.DxButton();
            this.SuspendLayout();
            // 
            // dxButton1
            // 
            this.dxButton1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.dxButton1.BackGroundDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.dxButton1.BackGroundHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.dxButton1.BackGroundPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(126)))), ((int)(((byte)(204)))));
            this.dxButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dxButton1.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dxButton1.Image = null;
            this.dxButton1.Location = new System.Drawing.Point(146, 67);
            this.dxButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.dxButton1.Name = "dxButton1";
            this.dxButton1.RoundedRadius = 5F;
            this.dxButton1.Size = new System.Drawing.Size(110, 45);
            this.dxButton1.TabIndex = 0;
            this.dxButton1.Text = "测试按钮";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.dxButton1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private Netx.Dui.DxControls.DxButton dxButton1;
    }
}