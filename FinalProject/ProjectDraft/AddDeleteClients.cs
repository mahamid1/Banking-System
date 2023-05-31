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
    public partial class AddDeleteClients : Form
    {
        List<Clients> l1;
        int x;
        int p;
        public AddDeleteClients()
        {
            InitializeComponent();
        }
        public AddDeleteClients(int y)
        {
            InitializeComponent();
            x = y;
            label1.Text = "Branch Number :" + y;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            l1 = Clients.GetAllByBranch(x);
            dataGridView1.DataSource = l1;
            
        }

        private void add_Click(object sender, EventArgs e)
        {

        }

      
        private void AddDeleteClients_Load(object sender, EventArgs e)
        {
           
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            AddClient a1 = new AddClient(x);
            a1.FormClosed += A1_FormClosed;
            a1.ShowDialog();
        }

        private void A1_FormClosed(object sender, FormClosedEventArgs e)
        {
            l1 = Clients.GetAllByBranch(x);
            dataGridView1.DataSource = l1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Delete.Visible = true;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    if (dataGridView1[j, i].Selected)
                    {
                        p = i;
                        dataGridView1.Rows[i].Selected = true;
                    }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Clients.RemoveClient(l1[p]);
            l1 = Clients.GetAllByBranch(x);
            dataGridView1.DataSource = l1;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateClient m1 = new updateClient(p,x);
            m1.FormClosed += M1_FormClosed;m1.ShowDialog();
        }

        private void M1_FormClosed(object sender, FormClosedEventArgs e)
        {
            l1 = Clients.GetAllByBranch(x);
            dataGridView1.DataSource = l1;   
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            l1 = Clients.GetAllByBranch(x);
            dataGridView1.DataSource = l1;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Clients.RemoveClient(l1[p]);
            l1 = Clients.GetAllByBranch(x);
            dataGridView1.DataSource = l1;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            AddClient a1 = new AddClient(x);
            a1.FormClosed += A1_FormClosed;
            a1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
