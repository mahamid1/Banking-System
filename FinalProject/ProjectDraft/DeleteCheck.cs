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
    public partial class DeleteCheck : Form
    {
        List<check> l1;
        int accnum;
        int p;
        public DeleteCheck(int y )
        {
            InitializeComponent();
            accnum = y;
        }

        private void DeleteCheck_Load(object sender, EventArgs e)
        {
            l1 = check.GetAllbyaccnum(accnum);
            dataGridView1.DataSource = l1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    if (dataGridView1[j, i].Selected)
                    {
                        p = i;
                        dataGridView1.Rows[i].Selected = true;
                    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check.RemoveCheck(l1[p]);
            l1 = check.GetAllbyaccnum(accnum);
            dataGridView1.DataSource = l1;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            check.RemoveCheck(l1[p]);
            l1 = check.GetAllbyaccnum(accnum);
            dataGridView1.DataSource = l1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
