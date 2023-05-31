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
    public partial class TypePasswordd : Form
    {
        private string Pass;
        private string userName;
        private int TradeX;
        List<Branches> l1;
        public TypePasswordd(int x,string str,string str2)
        {
            InitializeComponent();
            this.Pass = str;
            userName = str2;
            TradeX = x;

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.CompareTo(Pass) == 0)
            {
                l1 = Branches.GetAll();
                MessageBox.Show("Welcome " + userName, "", MessageBoxButtons.OK);
                Close();
                Updatee p1 = new Updatee(TradeX);
                p1.ShowDialog();


            }
            else
            {
                MessageBox.Show("Wrong Password , Try Again");
            }
        }
    }
}
