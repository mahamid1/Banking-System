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
    public partial class EmployeesManeger : Form
    {
        List<Employee> l1;
        int p;
        int x;

        public EmployeesManeger()
        {
            InitializeComponent();
        }

        public EmployeesManeger(int x)
        {
            InitializeComponent();
            this.x = x;

        }

        private void ClientsManeger_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = l1;
            label1.Text = "" + x;
        }

        private  void ImageCasting ()
        {
            dataGridView1.Columns[0].HeaderText = "Employee_ID";
            dataGridView1.Columns[1].HeaderText = "Employee_Name";
            dataGridView1.Columns[2].HeaderText = "Branch_Number";
            dataGridView1.Columns[3].HeaderText = "Employee_UserName";
            dataGridView1.Columns[4].HeaderText = "PassWord";
            dataGridView1.Columns[5].HeaderText = "Employee_Photo";
            dataGridView1.Columns[6].HeaderText = "Permissions";
            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            ic = (DataGridViewImageColumn)dataGridView1.Columns[5];
            ic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 120;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            l1 = Employee.regardingTOBranchNum(x);
            
            dataGridView1.DataSource = l1;
            ImageCasting();


        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddEmployee a1 = new AddEmployee(x);
            a1.FormClosed += A1_FormClosed;
            a1.ShowDialog();
        }

        private void A1_FormClosed(object sender, FormClosedEventArgs e)
        {
            l1 = Employee.regardingTOBranchNum(x);
            
            dataGridView1.DataSource = l1;
            ImageCasting();

        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                Employee.RemoveEmployee(l1[p]);
                l1 = Employee.regardingTOBranchNum(x);
                
                dataGridView1.DataSource = l1;
                ImageCasting();
            }
            catch { MessageBox.Show("U Didn`t press any thing OR The List is Clear"); }

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eli m1 = new eli(p,x);
            m1.FormClosed += M1_FormClosed;
            m1.ShowDialog();
        }

        private void M1_FormClosed(object sender, FormClosedEventArgs e)
        {
            l1 = Employee.regardingTOBranchNum(x);

            dataGridView1.DataSource = l1;
            ImageCasting();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                Employee.RemoveEmployee(l1[p]);
                l1 = Employee.regardingTOBranchNum(x);

                dataGridView1.DataSource = l1;
                ImageCasting();
            }
            catch { MessageBox.Show("U Didn`t press any thing OR The List is Clear"); }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            AddEmployee a1 = new AddEmployee(x);
            a1.FormClosed += A1_FormClosed;
            a1.ShowDialog();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            l1 = Employee.regardingTOBranchNum(x);

            dataGridView1.DataSource = l1;
            ImageCasting();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
