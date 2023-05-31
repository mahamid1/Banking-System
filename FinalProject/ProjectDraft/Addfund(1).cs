using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDraft
{
    public partial class Addfund_1_ : Form
    {
        public Addfund_1_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFund_2_ m1 = new AddFund_2_(int.Parse(textBox1.Text));
            m1.FormClosed += M1_FormClosed;
            m1.ShowDialog();
        }

        private void M1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            AddFund_2_ m1 = new AddFund_2_(int.Parse(textBox1.Text));
            m1.FormClosed += M1_FormClosed;
            m1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
