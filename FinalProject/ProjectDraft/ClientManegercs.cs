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
    public partial class ClientManegercs : Form
    {
        private string str;
        private string str2;
        List<Types> l1;
        int z;
        int accNumber1;
        public ClientManegercs()
        {
            InitializeComponent();
        }
        public ClientManegercs(string x,string y,int w,int accNumber)
        {
            InitializeComponent();
            str = x;
            str2 = y;
            z = w;
            accNumber1 = accNumber;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClientManegercs_Load(object sender, EventArgs e)
        {
            l1 = Types.GetbyID(str2);
            if(DateTime.Now.Hour>4 && DateTime.Now.Hour<11)
            {
                label1.Text = "בוקר טוב " + str;
              
            }
            if (DateTime.Now.Hour > 11 && DateTime.Now.Hour <= 16)
            {
                label1.Text = "צוהריים טובים  " + str;  

            }
            if (DateTime.Now.Hour > 16 && DateTime.Now.Hour < 24)
            {
                label1.Text = "ערב טוב " + str;

            }
            for(int i = 0; i < l1.Count;i++)
            {
                if (l1[i].Get_TypeNum == 3)
                    l1.RemoveAt(i);
            }
           
                comboBox1.DataSource = l1;

            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            l1 = Types.GetbyID(str2);
            int x = l1[comboBox1.SelectedIndex].Get_TypeNum;
            if (x == 3)
            {
                
                //AddDeleteClients m1 = new AddDeleteClients(z);
                //m1.ShowDialog();

            }
            if (x == 1)
            {
                AddFund_2_ m1 = new AddFund_2_(accNumber1);
                m1.ShowDialog();
            }
            if (x == 0)
            {
                transfers_2_ t1 = new transfers_2_(accNumber1);
                t1.ShowDialog();
            }
            if (x == 2)
            {
                MainCheck m1 = new MainCheck(z,accNumber1);
                m1.ShowDialog();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
