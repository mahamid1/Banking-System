using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;

namespace ProjectDraft
{
    public partial class Accounts : Form
    {
        int accNum;
        public Accounts()
        {
            InitializeComponent();
        }
        public Accounts(int x )
        {
            InitializeComponent();
            accNum = x;
        }


        private void Accounts_Load(object sender, EventArgs e)
        {


            XmlDocument reader = new XmlDocument();
            reader.Load("http://www.boi.org.il/currency.xml");
            XmlElement root = reader.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/CURRENCIES/CURRENCY");
            int c = 0;
            foreach (XmlNode node in nodes)
            {
                c++;
                if (c == 1)
                {
                    label4.Text = node["RATE"].InnerText;
                    if (double.Parse(node["CHANGE"].InnerText) > 0)
                    {
                        label8.Text = node["CHANGE"].InnerText + "%";
                        pictureBox3.ImageLocation = "Resources/UP.PNG";
                        label8.ForeColor = Color.Green;
                    }
                    else
                    {
                        label8.Text = node["CHANGE"].InnerText + "%";
                        label8.ForeColor = Color.Red; }
                }
                if (c == 2)
                {
                    label5.Text = node["RATE"].InnerText;
                    if (double.Parse(node["CHANGE"].InnerText) > 0)
                    {
                        label9.Text = node["CHANGE"].InnerText + "%";
                        pictureBox2.ImageLocation = "Resources/UP.PNG";
                        label9.ForeColor = Color.Green;
                        
                    }
                    else {
                        label9.Text = node["CHANGE"].InnerText + "%";
                        label9.ForeColor = Color.Red; }
                }
                if (c == 4)
                {
                    label6.Text = node["RATE"].InnerText;
                    if (double.Parse(node["CHANGE"].InnerText) > 0)
                    {
                        label10.Text = node["CHANGE"].InnerText + "%";
                        pictureBox4.ImageLocation = "Resources/UP.PNG";
                        label10.ForeColor = Color.Green;

                    }
                    else
                    {
                        label10.Text = node["CHANGE"].InnerText + "%";
                       
                        label10.ForeColor = Color.Red; }
                }
                if(c>4)
                {
                    break;
                }
                
                
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            history h1 = new history(accNum);
            h1.ShowDialog();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            history h1 = new history(accNum);
            h1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            transfers_2_ t1 = new transfers_2_(accNum);
            t1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            machine m1 = new machine(accNum);
            m1.ShowDialog();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
