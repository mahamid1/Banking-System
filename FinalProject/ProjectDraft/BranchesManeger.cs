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
    public partial class BranchesManeger : Form
    {
        List<Branches> l;
        int p;


        public BranchesManeger()
        {
            InitializeComponent();
        }

        private void ShowData_Click(object sender, EventArgs e)
        {
             l = Branches.GetAll();
            dataGridView1.DataSource = l;
        }

        private void AddToData_Click(object sender, EventArgs e)
        {
            AddToData_BranchesManeger_ b1 = new AddToData_BranchesManeger_();
            b1.ShowDialog();
            ShowData_Click(sender, e);
         //b1.FormClosed += B1_FormClosed;
         
        }

        private void B1_FormClosed(object sender, FormClosedEventArgs e)
        {
            l = Branches.GetAll();
            dataGridView1.DataSource = l;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            l = Branches.GetAll();
            //TypePasswordd P1 = new TypePasswordd(p, l[p].B_Password, l[p].B_Maneger);
            //P1.ShowDialog();
            Updatee p1 = new Updatee(p);
            p1.FormClosed += P1_FormClosed;
            p1.ShowDialog();
            

          
            
        }

       

        private void P1_FormClosed(object sender, FormClosedEventArgs e)
        {
            l = Branches.GetAll();
            dataGridView1.DataSource = l;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //Remove.Visible = true;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    if (dataGridView1[j, i].Selected)
                    {
                        p = i;
                        dataGridView1.Rows[i].Selected = true;
                    }

            
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Branches.RemoveBranch(l[p]);
            l = Branches.GetAll();
            dataGridView1.DataSource = l;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            l = Branches.GetAll();
            dataGridView1.DataSource = l;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            AddToData_BranchesManeger_ b1 = new AddToData_BranchesManeger_();
            b1.ShowDialog();
            ShowData_Click(sender, e);
            //b1.FormClosed += B1_FormClosed;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Branches.RemoveBranch(l[p]);
            l = Branches.GetAll();
            dataGridView1.DataSource = l;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
