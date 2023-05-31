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
    public partial class updateClient : Form
    {
        int y;
        int number;
        List<Clients> l1;
        string time;
        public updateClient()
        {
            InitializeComponent();
        }
        public updateClient(int x,int z)
        {
            InitializeComponent();
            y = x;
            number = z;
        }

        private void updateClient_Load(object sender, EventArgs e)
        {
           l1= Clients.GetAllByBranch(number);
            textBox1.Text = l1[y].SetGetAcc_Num.ToString();
            textBox2.Text = l1[y].SetGetClientID;
            textBox3.Text = l1[y].SetGetClientName;
            textBox4.Text = l1[y].SetGetCurrent.ToString();
            textBox5.Text = l1[y].SetGetMaxDebt.ToString();
            textBox6.Text = l1[y].SetGetBranch.ToString();
            time = l1[y].SetGetStart;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clients c1 = new Clients(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, time, int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text));
            Clients.UpdateClient(c1);
            Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Clients c1 = new Clients(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, time, int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text));
            Clients.UpdateClient(c1);
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
