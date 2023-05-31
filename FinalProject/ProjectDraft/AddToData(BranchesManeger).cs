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
    public partial class AddToData_BranchesManeger_ : Form
    {
        List<Branches> l1 = Branches.GetAll();
        GoogleMap m1 = new GoogleMap();

        public AddToData_BranchesManeger_()
        {
            InitializeComponent();
        }
        private bool NumExist (List<Branches> l)
        {
            bool flag = true;
            int x = l.Count;
            try
            {
                for (int i = 0; i < x; i++)
                {
                    if (l[i].B_Number == int.Parse(textBox1.Text))
                    {
                        flag = false;
                    }

                }
            }
            catch
            {
               
            }
            return flag;
        }
        private bool LocationExist(List<Branches> l)
        {
            bool flag = true;
            int x = l.Count;
            for (int i = 0; i < x; i++)
            {
                if(l[i].B_Location==label1.Text)
                {
                    flag = false;
                }
            }
            return flag;
        }
        private bool UserNameExist(List<Branches> l)
        {
            bool flag = true;
            int x = l.Count;
            for (int i = 0; i < x; i++)
            {
                if (l[i].B_Maneger==textBox4.Text)
                {
                    flag = false;
                }

            }
            return flag;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Done_Click(object sender, EventArgs e)
        {
           
        }

        private void AddToData_BranchesManeger__Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                m1.FormClosed += M1_FormClosed;
                m1.ShowDialog();
            }
            catch { }
        }

        private void M1_FormClosed(object sender, FormClosedEventArgs e)
        {
           label1.Text = m1.SaveLoc();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && label1.Text != "Choose Location" && textBox4.Text != "" && textBox5.Text != "" && NumExist(l1) && LocationExist(l1) && UserNameExist(l1))
            {

                Branches b = null;
                try
                {
                    if (label1.Text == "Choose Location")
                    {
                        b = new Branches(int.Parse(textBox1.Text), textBox2.Text, label1.Text, textBox4.Text, textBox5.Text);
                        Branches.AddBranch(int.Parse(textBox1.Text), textBox2.Text, label1.Text, textBox4.Text, textBox5.Text);
                    }
                    else
                    {
                        string str = "(31.771959,35.217018)";
                        b = new Branches(int.Parse(textBox1.Text), textBox2.Text, str, textBox4.Text, textBox5.Text);
                        Branches.AddBranch(int.Parse(textBox1.Text), textBox2.Text, str, textBox4.Text, textBox5.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Error! please try again");
                }
                if (b != null) { l1.Add(b); Close(); }


            }
            else
            {
                MessageBox.Show("you didn`t fill all the fields, Try again");

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BranchMan_Username_Click(object sender, EventArgs e)
        {

        }
    }
}
