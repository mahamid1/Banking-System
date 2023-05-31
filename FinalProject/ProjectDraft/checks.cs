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
    public partial class checks : Form
    {
        int y;
        int accnum;

        public checks(int x,int accnum2)
        {
            InitializeComponent();
            y = x;
            accnum = accnum2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
            check.AddCheck(int.Parse(textBox1.Text), int.Parse(textBox4.Text), str, int.Parse(textBox2.Text), y, int.Parse(textBox5.Text));
            Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            string str = "" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
            check.AddCheck(int.Parse(textBox1.Text), int.Parse(textBox4.Text), str, int.Parse(textBox2.Text), y, int.Parse(textBox5.Text));
            Close();
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checks_Load(object sender, EventArgs e)
        {
            textBox4.Text = "" + accnum;
        }
    }
}
