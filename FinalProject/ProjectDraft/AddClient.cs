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
    public partial class AddClient : Form
    {
        int x;
        string str;
        int randomx;
        public AddClient()
        {
            InitializeComponent();
        }
        public AddClient(int y)
        {
            InitializeComponent();
            x = y;
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            BRANCHNUM.Text = "" + x;
            

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            str = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            Random r = new Random();
            randomx = r.Next(100000, 1000000);
            Clients.AddClient(randomx, ID.Text, NAME.Text, str, int.Parse(CURRENT.Text), int.Parse(DEBT.Text), x);
            Close();

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            str = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            Random r = new Random();
            randomx = r.Next(100000, 1000000);
            int c = 0;
            
            List<Clients> l1 = Clients.GetAllByBranch(x);
            for(int i = 0;i<l1.Count;i++)
            {
                if(l1[i].SetGetClientID==ID.Text || l1[i].SetGetAcc_Num==randomx)
                {
                    c++;
                }
                
            }
            if (c == 0)
            {
                Clients.AddClient(randomx, ID.Text, NAME.Text, str, int.Parse(CURRENT.Text), int.Parse(DEBT.Text), x);
            }
            else { MessageBox.Show("תבדוק מספר זהות או יש פעיה במספר חשבון"); }
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
