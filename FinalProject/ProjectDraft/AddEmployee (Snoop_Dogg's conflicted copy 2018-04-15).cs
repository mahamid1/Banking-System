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
    public partial class AddEmployee : Form
    {
        string str;
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                str = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (str != "")
                {
                    Employee.AddEmployee(int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text), textBox4.Text, textBox5.Text, str);
                }
                Close();
            }
            catch { MessageBox.Show("Error!!,Try Again."); }
            
        }
    }
}
