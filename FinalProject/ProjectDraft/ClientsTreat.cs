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
    public partial class ClientsTreat : Form
    {
        string EUserName;
        Employee e1;
        List<Types> l1;
        int BranchNumber;
        public ClientsTreat(string str)
        {
            InitializeComponent();
            EUserName = str;
            e1 = Employee.regardingtoUserName(EUserName);
            
        }

        private void ClientsTreat_Load(object sender, EventArgs e)
        {

            l1 = Types.GetbyID(e1.SetGetEmployee_Permissions);
            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i].Get_TypeNum == 3)
                {
                    bunifuThinButton21.Visible = true;
                    label50.Visible = true;
                }
            }
            this.WindowState = FormWindowState.Maximized;
            XmlDocument reader = new XmlDocument();
            reader.Load("http://www.boi.org.il/currency.xml");
            XmlElement root = reader.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/CURRENCIES/CURRENCY");
            int c = 0;
            foreach(XmlNode node in nodes)
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
                        label11.Text = node["CHANGE"].InnerText + "%";
                        label11.ForeColor = Color.Red;
                    }
                }
                if(c==2)
                {
                    label5.Text = node["RATE"].InnerText;
                    if (double.Parse(node["CHANGE"].InnerText) > 0)
                    {
                        label9.Text = node["CHANGE"].InnerText + "%";
                        pictureBox2.ImageLocation = "Resources/UP.PNG";
                        label9.ForeColor = Color.Green;

                    }
                    else
                    {
                        label9.Text = node["CHANGE"].InnerText + "%";
                        label9.ForeColor = Color.Red;
                    }
                }
               if(c==4)
                {
                    label27.Text = node["RATE"].InnerText;
                    if(double.Parse(node["CHANGE"].InnerText)>0)
                    {
                        label14.Text = node["CHANGE"].InnerText + "%";
                        pictureBox4.ImageLocation = "Resources/UP.PNG";
                        label14.ForeColor = Color.Green;

                    }
                    else
                    {
                        label14.Text = node["CHANGE"].InnerText + "%";
                        label14.ForeColor = Color.Red;
                    }
                }

            }






        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ClientManegercs m2 = new ClientManegercs(e1.SetGetEmployee_Name, e1.SetGetEmployee_Permissions, e1.SetGetBranch_Num, int.Parse(textBox1.Text));
                Hide();
                m2.FormClosed += M2_FormClosed;
                m2.ShowDialog();
            }
            if ( textBox2.Text!="")
            {
                Clients c1 = Clients.getclientbyID(textBox2.Text);
                ClientManegercs m3 = new ClientManegercs(e1.SetGetEmployee_Name, e1.SetGetEmployee_Permissions, e1.SetGetBranch_Num, c1.SetGetAcc_Num);  
                Hide();
                m3.FormClosed += M3_FormClosed;
                m3.ShowDialog();

            }
            if(textBox1.Text =="" && textBox2 .Text=="")
            {
                MessageBox.Show("תכתוב מספר חשבון אן מספר זהות"); 
                    
            }


        }

        private void M3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void M2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDeleteClients c1 = new AddDeleteClients(e1.SetGetBranch_Num);
            c1.FormClosed += C1_FormClosed;
            Hide();
            c1.ShowDialog();
        }

        private void C1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ClientManegercs m2 = new ClientManegercs(e1.SetGetEmployee_Name, e1.SetGetEmployee_Permissions, e1.SetGetBranch_Num, int.Parse(textBox1.Text));
               // Hide();
                m2.FormClosed += M2_FormClosed;
                m2.ShowDialog();
            }
            if (textBox2.Text != "")
            {
                Clients c1 = Clients.getclientbyID(textBox2.Text);
                ClientManegercs m3 = new ClientManegercs(e1.SetGetEmployee_Name, e1.SetGetEmployee_Permissions, e1.SetGetBranch_Num, c1.SetGetAcc_Num);
              //  Hide();
                m3.FormClosed += M3_FormClosed;
                m3.ShowDialog();

            }
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("תכתוב מספר חשבון אן מספר זהות");

            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            AddDeleteClients c1 = new AddDeleteClients(e1.SetGetBranch_Num);
            c1.FormClosed += C1_FormClosed;
            Hide();
            c1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
