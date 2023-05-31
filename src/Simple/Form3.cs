using Netx.Dui;
using Netx.Dui.DxControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple
{
    public partial class Form3 : Form
    {
        int i = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void dxButton1_Click(object sender, EventArgs e)
        {
            if (i++ % 2 == 0)
                DxSkinManager.Instance.Apply(new MyScheme());
            else
                DxSkinManager.Instance.Apply(new DefaultScheme());
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<DxLabel> list = new List<DxLabel>();
            for (int i=0;i< 200;i++)
            {
                list.Add(new DxLabel());
            }
            this.flowLayoutPanel1.Controls.AddRange(list.ToArray());
            sw.Stop();
            MessageBox.Show($"{sw.Elapsed.TotalMilliseconds}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dxLabel2.Invalidate();
        }
    }
}
