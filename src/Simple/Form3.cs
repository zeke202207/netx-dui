using Netx.Dui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
