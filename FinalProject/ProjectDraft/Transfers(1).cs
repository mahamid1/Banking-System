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
    public partial class Transfers_1_ : Form
    {
        public Transfers_1_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transfers_2_ t1 = new transfers_2_(int.Parse(textBox1.Text));
            t1.FormClosed += T1_FormClosed;
            t1.ShowDialog();
        }

        private void T1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            transfers_2_ t1 = new transfers_2_(int.Parse(textBox1.Text));
            t1.FormClosed += T1_FormClosed;
            t1.ShowDialog();
        }
    }
}
