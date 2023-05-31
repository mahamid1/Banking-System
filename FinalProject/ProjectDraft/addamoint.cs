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
    public partial class addamoint : Form
    {
        Clients c1;
        int y;
        public addamoint()
        {
            InitializeComponent();
        }
        public addamoint(int x)
        {
            InitializeComponent();
            c1 = Clients.getclientbyAcc(x);
            y = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
