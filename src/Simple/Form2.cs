using Netx.Dui;
using Netx.Dui.DxControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dxButton1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 800; i++)
            {
                Console.WriteLine(i.ToString());
                var btn = new DxButton() { Text = $"按钮-{i.ToString()}", Radius = 0 };
                flowLayoutPanel1.Controls.Add(new DxButton() { Text = $"按钮-{i.ToString()}" });
                //flowLayoutPanel1.Controls.Add(new Button() { Text = $"按钮-{i.ToString()}" });
            }
            sw.Stop();
            MessageBox.Show($"{sw.Elapsed.TotalMilliseconds} ms");
        }

        private void dxButton3_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();
        }

        /// <summary>
        /// 测试换肤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxButton2_Click(object sender, EventArgs e)
        {
            using (var form3 = new Form3())
            {
                form3.ShowDialog();
            }

            //var form3 = new Form3();
            //form3.Show();
        }
    }
}
