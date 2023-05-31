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
    public partial class AddFund_2_ : Form
    {
        int y;
        Clients c1;
        public AddFund_2_()
        {
            InitializeComponent();
        }
        public AddFund_2_(int x)
        {
            InitializeComponent();
            y = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = c1.SetGetCurrent;
            int sum2 = sum + int.Parse(textBox1.Text);
            string str = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            if (sum2 > c1.SetGetMaxDebt)
            {

                c1.SetGetCurrent += int.Parse(textBox1.Text);
                Clients.UpdateClient(c1);
                label2.Text = "" + c1.SetGetCurrent;
                if (int.Parse(textBox1.Text) > 0)
                { THistory.AddToHistory(y, str, int.Parse(textBox1.Text), 0, "הפקדת מזומן", c1.SetGetCurrent); }
                if (int.Parse(textBox1.Text) < 0)
                {
                    THistory.AddToHistory(y, str, 0, int.Parse(textBox1.Text) * -1, "משיכת מזומן", c1.SetGetCurrent);
                }
            }
            else
            {
                MessageBox.Show("Error!!");
            }
            textBox1.Text = "";


        }

        private void AddFund_2__Load(object sender, EventArgs e)
        {
            c1 = Clients.getclientbyAcc(y);
            label2.Text = "" + c1.SetGetCurrent;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            int sum = c1.SetGetCurrent;
            int sum2 = sum + int.Parse(textBox1.Text)- int.Parse(Types.GetbyID2(1).Get_TypeCost);
            string str = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            if (sum2 > c1.SetGetMaxDebt)
            {

                c1.SetGetCurrent += int.Parse(textBox1.Text);
                Clients.UpdateClient(c1);
                label2.Text = "" + c1.SetGetCurrent;
                if (int.Parse(textBox1.Text) > 0)
                { THistory.AddToHistory(y, str, int.Parse(textBox1.Text), 0, "הפקדת מזומן", c1.SetGetCurrent);
                    THistory.AddToHistory(y, str, 0, int.Parse(Types.GetbyID2(1).Get_TypeCost), "עמלת הפקדת מזומן", c1.SetGetCurrent);

                }
                if (int.Parse(textBox1.Text) < 0)
                {
                    THistory.AddToHistory(y, str, 0, int.Parse(textBox1.Text) * -1, "משיכת מזומן", c1.SetGetCurrent);
                    THistory.AddToHistory(y, str, 0, int.Parse(Types.GetbyID2(1).Get_TypeCost), "עמלת משיכת מזומן", c1.SetGetCurrent);
                }
            }
            else { MessageBox.Show("אין כסף מספיק בחשבון"); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
