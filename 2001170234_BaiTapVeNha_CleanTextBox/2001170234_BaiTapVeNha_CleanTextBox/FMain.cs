using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2001170234_BaiTapVeNha_CleanTextBox
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            cleanTextBox(this);
        }

        private void cleanTextBox(Control ctrfather)
        {
            foreach (Control ctr in ctrfather.Controls)
                if (ctr is GroupBox)
                    cleanTextBox(ctr);
                else
                    if (ctr is TextBox)
                        ctr.Text = string.Empty;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            random(this);
        }

        private Random rd = new Random();

        private void random(Control ctrfather)
        {
            foreach (Control ctr in ctrfather.Controls)
                if (ctr is GroupBox)
                    random(ctr);
                else
                    if (ctr is TextBox)
                        ctr.Text = "Value: " + rd.Next(100, 1000);
        }
    }
}
