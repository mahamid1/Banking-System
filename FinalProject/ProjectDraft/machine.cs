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
    public partial class machine : Form
    {
        int accnumber;
        Clients c1;
        int sum;
        public machine(int accnumber2)
        {
            InitializeComponent();
            accnumber = accnumber2;
            c1 = Clients.getclientbyAcc(accnumber2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(int.Parse(textBox1.Text)%10==0 && int.Parse(textBox1.Text)/10%10!=1 && int.Parse(textBox1.Text) / 10 % 10 != 3 && int.Parse(textBox1.Text) / 10 % 10 != 6 && int.Parse(textBox1.Text) / 10 % 10 != 7 && int.Parse(textBox1.Text) / 10 % 10 != 8 && int.Parse(textBox1.Text) / 10 % 10 != 9 && c1.SetGetCurrent-int.Parse(textBox1.Text)>c1.SetGetMaxDebt)
            {
                sum = c1.SetGetCurrent - int.Parse(textBox1.Text);
                c1.SetGetCurrent = sum;
                Clients.UpdateClient(c1);
                label1.Text = "" + c1.SetGetCurrent;
                string today = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                THistory.AddToHistory(accnumber, today, 0, int.Parse(textBox1.Text), "משיכה מקספומט", c1.SetGetCurrent);
                Close();

            }
            else { MessageBox.Show("הכנסת סכום שגוי או חשבונך מוגבל"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }

        private void machine_Load(object sender, EventArgs e)
        {
             
            label1.Text = "" + c1.SetGetCurrent;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
