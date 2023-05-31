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
    public partial class MainCheck : Form
    {
        int x;
        int accnum;
        public MainCheck(int y,int accnum1)
        {
            InitializeComponent();
            x = y;
            accnum = accnum1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // checks m1 = new checks(x);
          // m1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteCheck m2 = new DeleteCheck(accnum);
            m2.ShowDialog();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            checks m1 = new checks(x,accnum);
            m1.ShowDialog();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            DeleteCheck m2 = new DeleteCheck(accnum);
            m2.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
