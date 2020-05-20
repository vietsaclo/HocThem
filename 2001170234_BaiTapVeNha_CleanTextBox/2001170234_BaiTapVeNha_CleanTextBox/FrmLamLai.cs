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
    public partial class FrmLamLai : Form
    {
        public FrmLamLai()
        {
            InitializeComponent();
        }

        private void btnRanDom_Click(object sender, EventArgs e)
        {
            //Với mọi control trong container. hỏi có phải textBox ko.
            //nếu phải thì làm gì đó.
            ranDomTextBox(this);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            cleanTextBox(this);
        }

        private void FrmLamLai_Load(object sender, EventArgs e)
        {

        }

        private void cleanTextBox(Control ctr)
        {
            foreach (Control tr in ctr.Controls)
            {
                if (tr is TextBox)
                    tr.Text = "";
                else if (tr is GroupBox)
                    cleanTextBox(tr);
            }
        }

        private void ranDomTextBox(Control ctr)
        {
            foreach (Control tr in ctr.Controls)
            {
                if (tr is TextBox)
                    tr.Text = "asdfasd";
                else if (tr is GroupBox)
                    ranDomTextBox(tr);
            }
        }
    }
}
