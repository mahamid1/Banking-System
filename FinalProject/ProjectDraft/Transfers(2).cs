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
    public partial class transfers_2_ : Form
    {
        int x;
        Clients c1;
        Clients c2;
        public transfers_2_()
        {
            InitializeComponent();
        }
        public transfers_2_(int y)
        {
            InitializeComponent();
            x = y;
            textBox1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            c1 = Clients.getclientbyAcc(x);
            c2 = Clients.getclientbyAcc(int.Parse(textBox2.Text));
            int sum1 = c1.SetGetCurrent - int.Parse(textBox3.Text);
            int sum2 = c2.SetGetCurrent + int.Parse(textBox3.Text);
            if(sum1>c1.SetGetMaxDebt)
            {
                c1.SetGetCurrent = sum1;
                c2.SetGetCurrent = sum2;
                Clients.UpdateClient(c1);
                Clients.UpdateClient(c2);
                THistory.AddToHistory(x, str, 0, int.Parse(textBox3.Text), "העברה", c1.SetGetCurrent);
                THistory.AddToHistory(int.Parse(textBox2.Text), str, int.Parse(textBox3.Text), 0, "העברה", c2.SetGetCurrent);
                Close();
            }
            else
            {
                MessageBox.Show("אין כסף מספיק בחשבון");
            }

        }

        private void transfers_2__Load(object sender, EventArgs e)
        {
            textBox1.Text += x;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                c1 = Clients.getclientbyAcc(x);
                c2 = Clients.getclientbyAcc(int.Parse(textBox2.Text));
                int sum1 = c1.SetGetCurrent - int.Parse(textBox3.Text) - int.Parse(Types.GetbyID2(0).Get_TypeCost);
                int sum2 = c2.SetGetCurrent + int.Parse(textBox3.Text);
                if (sum1 > c1.SetGetMaxDebt && textBox1.Text != textBox2.Text)
                {
                    int x = int.Parse(Types.GetbyID2(0).Get_TypeCost);
                    c1.SetGetCurrent = sum1;
                    c2.SetGetCurrent = sum2;
                    Clients.UpdateClient(c1);
                    Clients.UpdateClient(c2);
                    THistory.AddToHistory(c1.SetGetAcc_Num, str, 0, int.Parse(textBox3.Text), "העברה", c1.SetGetCurrent);
                    THistory.AddToHistory(c1.SetGetAcc_Num, str, 0, x, "עמלת העברה", c1.SetGetCurrent);
                    THistory.AddToHistory(int.Parse(textBox2.Text), str, int.Parse(textBox3.Text), 0, "העברה", c2.SetGetCurrent);
                    Close();
                }
                else
                {
                    MessageBox.Show("אין כסף מספיק בחשבון");
                }
            }
            catch { MessageBox.Show("תבדוק מספרי חשבון"); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
