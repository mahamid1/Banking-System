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
    public partial class DeleteCheck_1_ : Form
    {
        public DeleteCheck_1_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteCheck m1 = new DeleteCheck(int.Parse(textBox1.Text));
            m1.FormClosed += M1_FormClosed;
            m1.ShowDialog();
        }

        private void M1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            DeleteCheck m1 = new DeleteCheck(int.Parse(textBox1.Text));
            m1.FormClosed += M1_FormClosed;
            m1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
