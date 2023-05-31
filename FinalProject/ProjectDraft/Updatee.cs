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
    public partial class Updatee : Form
    {
        private int x;
        private List<Branches> l2;
        private int y;
        GoogleMap m2 = new GoogleMap();
       
        

        public Updatee(int x)
        {
            InitializeComponent();
            this.x = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) == y && textBox1.Text != "" && textBox2.Text != "" && label1.Text != "Show/UpdateLocation" && textBox4.Text != "" && textBox5.Text != "")
                {
                    Branches.UpdateBranch(new Branches(int.Parse(textBox1.Text.ToString()), textBox2.Text.ToString(), label1.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString()));

                    Close();
                }
                else { MessageBox.Show("you changed the Branch Number or you didn`t fill all the blanks , Try again"); }
            }
            catch
            {
                MessageBox.Show("Error ! Type branch Number as a number ");
            }

        }

        private void Updatee_Load(object sender, EventArgs e)
        {
            l2 = Branches.GetAll();
            m2 = new GoogleMap(l2[x].B_Location);
            textBox1.Text = "" + l2[x].B_Number;
            textBox2.Text = l2[x].B_Name;
            if (l2[x].B_Location != "")
            {
                label1.Text = l2[x].B_Location;
            }
            else { label1.Text = "(31.771959,35.217018)"; }
            textBox4.Text = l2[x].B_Maneger;
            textBox5.Text = l2[x].B_Password;
             y = int.Parse(textBox1.Text);



        }

        private void label1_Click(object sender, EventArgs e)
        {
            m2.FormClosed += M2_FormClosed;
            m2.ShowDialog();
        }

        private void M2_FormClosed(object sender, FormClosedEventArgs e)
        {
            label1.Text = m2.SaveLoc();

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) == y && textBox1.Text != "" && textBox2.Text != "" && label1.Text != "Show/UpdateLocation" && textBox4.Text != "" && textBox5.Text != "")
                {
                    Branches.UpdateBranch(new Branches(int.Parse(textBox1.Text.ToString()), textBox2.Text.ToString(), label1.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString()));

                    Close();
                }
                else { MessageBox.Show("you changed the Branch Number or you didn`t fill all the blanks , Try again"); }
            }
            catch
            {
                MessageBox.Show("Error ! Type branch Number as a number ");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
