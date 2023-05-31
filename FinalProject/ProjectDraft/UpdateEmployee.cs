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
    public partial class eli : Form
    {
        private int x;
        private List<Employee> l2;
        List<Types> l1;
        private int y;
        private string str;
        string str2;
        int k;

        public eli(int x,int u)
        {
            InitializeComponent();
            this.x = x;
            k = u;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

            l2 = Employee.regardingTOBranchNum(k);
            textBox1.Text = "" + l2[x].GetSetEmployee_ID;
            textBox2.Text = l2[x].SetGetEmployee_Name;
            textBox3.Text = "" + k;
            textBox4.Text = l2[x].SetGetEmployee_Username;
            textBox5.Text = l2[x].SetGetPasswordd;
            pictureBox1.Image = l2[x].SetGetEmployee_photo;
            str = l2[x].GetEmployeePhoto();
            y = int.Parse(textBox1.Text);
            l1 = Types.GetAll();
            checkedListBox1.Items.Add(l1[0].Get_TypeName);
            
            // checkedListBox1.Items.Add(l1[2].Get_TypeName);
            checkedListBox1.Items.Add(l1[2].Get_TypeName);
            checkedListBox1.Items.Add(l1[5].Get_TypeName);
            checkedListBox1.Items.Add(l1[6].Get_TypeName);
            // checkedListBox1.Items.Add(l1[0].Get_TypeName);
            try
            {
                string[] srr = l2[x].SetGetEmployee_Permissions.Split(',');
                for (int i = 0; i < srr.Length; i++)
                {
                    checkedListBox1.SetItemChecked(int.Parse(srr[i]), true);
                }
            }
            catch { }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                str = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        c++;
                        if (c >= 2)
                        {
                            str2 += ",";
                        }
                        str2 += i;

                    }
                }
                if (int.Parse(textBox1.Text) == y && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && pictureBox1.ImageLocation != "")
                {
                    Employee.UpdateEmployee(new Employee(int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text), textBox4.Text, textBox5.Text, str, str2));
                    Close();
                }
                else { MessageBox.Show("you changed the Branch Number or you didn`t fill all the blanks , Try again"); }
            }
            catch { MessageBox.Show("Error ! Type branch Number as a number "); }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
