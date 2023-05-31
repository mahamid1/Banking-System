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
    public partial class history : Form
    {
        List<THistory> l1;
        int x;
        public history(int y )
        {
            InitializeComponent();
            x = y;
        }

        private void history_Load(object sender, EventArgs e)
        {
            l1 = THistory.GetAllbyacc(x);
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
