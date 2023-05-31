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
        int x;
        List<Types> l1;
        string str2 = "";
        public AddEmployee()
        {
            InitializeComponent();
        }
        public AddEmployee(int y)
        {
            InitializeComponent();
            x = y;
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

            
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            textBox3.Text = "" + x;
            l1 = Types.GetAll();
            checkedListBox1.Items.Add(l1[0].Get_TypeName);
            
           // checkedListBox1.Items.Add(l1[2].Get_TypeName);
            checkedListBox1.Items.Add(l1[2].Get_TypeName);
            checkedListBox1.Items.Add(l1[5].Get_TypeName);
            checkedListBox1.Items.Add(l1[6].Get_TypeName);
          //  checkedListBox1.Items.Add(l1[0].Get_TypeName);


            // types for the employee {0,1,4,5,6}



        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = 0; i < 4; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    c++;
                    if (c >= 2)
                    { str2 += ","; }
                    str2 += i;

                }
            }
            try
            {

                if (str != null)
                {

                    Employee.AddEmployee(int.Parse(textBox1.Text), textBox2.Text, x, textBox4.Text, textBox5.Text, str, str2);
                    Close();
                }
                else { MessageBox.Show("תמונה"); }
                
            }
            catch { MessageBox.Show("Error!!,Try Again."); }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
