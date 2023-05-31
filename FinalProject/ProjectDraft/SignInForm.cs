using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProjectDraft
{
    public partial class SignInForm: Form
    {
        List<check> l2;
        public SignInForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SignBTN_Click(object sender, EventArgs e)
        {
        }

        private void A1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            SignInForm_Load(sender, e);
        }

        private void M1_FormClosed1(object sender, FormClosedEventArgs e)
        {
            Show();
            SignInForm_Load(sender, e);
        }

        private void M1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            SignInForm_Load(sender, e);
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            l2 = check.GetAll();
            string str = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            for (int i = 0; i < l2.Count; i++)
            {
                if (l2[i].getsetdate==str)
                {
                    Clients c1 = Clients.getclientbyAcc(l2[i].setgetacc);
                    Clients c2 = Clients.getclientbyAcc(l2[i].setgetTO);
                    if (c1.SetGetCurrent - l2[i].setgetamount > c1.SetGetMaxDebt)
                    {
                        c1.SetGetCurrent -= l2[i].setgetamount;
                        c2.SetGetCurrent += l2[i].setgetamount;
                        Clients.UpdateClient(c1);
                        Clients.UpdateClient(c2);
                        THistory.AddToHistory(c1.SetGetAcc_Num, str, 0, l2[i].setgetamount, "הפקדת שיקים", c1.SetGetCurrent);
                        THistory.AddToHistory(c1.SetGetAcc_Num, str, 0, int.Parse(Types.GetbyID2(2).Get_TypeCost), "עמלת הפקדת שיקים", c1.SetGetCurrent);

                        THistory.AddToHistory(c1.SetGetAcc_Num, str, l2[i].setgetamount, 0, "הפקדת שיקים", c2.SetGetCurrent);
                    }
                    else
                    {
                        THistory.AddToHistory(l2[i].setgetacc, str, 0, l2[i].setgetamount, "הפקדת שיקים", c1.SetGetCurrent);
                        THistory.AddToHistory(l2[i].setgetacc, str, l2[i].setgetamount,0 , "שיק חוזר", c1.SetGetCurrent);

                    }

                    check.RemoveCheck(l2[i]);

                }
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.CompareTo("Ahmad") == 0 && textBox2.Text.CompareTo("Ahmad") == 0)
            {
                label3.Visible = false;
                BranchesManeger m1 = new BranchesManeger();
                Hide();
                //Form1 mm = new Form1(); mm.ShowDialog();
                m1.FormClosed += M1_FormClosed;
                m1.ShowDialog();
            }
            else { label3.Visible = true; }
            if (Branches.check_if_exist(textBox1.Text, textBox2.Text) != null)
            {
                label3.Visible = false;
                Connector con = new Connector("Bank.accdb");
                int b_num = -1;
                OleDbDataReader result = con.RunSelect("select * from Branches where BrachManeger_UserName='" + textBox1.Text + "'");
                while (result.Read())
                    b_num = int.Parse(result["Branch_Num"].ToString());
                EmployeesManeger m1 = new EmployeesManeger(b_num);
                Hide();
                m1.FormClosed += M1_FormClosed1;
                m1.ShowDialog();
            }
            if (Employee.check_if_exist(textBox1.Text, textBox2.Text) != null)
            {
                label3.Visible = false;
                Connector con = new Connector("Bank.accdb");
                string b_name = "";
                string b_perm = "";
                int x = -1;
                OleDbDataReader result = con.RunSelect("select * from Employees where Employee_Username='" + textBox1.Text + "'");
                while (result.Read())
                {
                    b_name = result["Employee_Name"].ToString();
                    b_perm = result["Employee_Permissions"].ToString();
                    x = int.Parse(result["Branch_Num"].ToString());
                }
                ClientsTreat m1 = new ClientsTreat(textBox1.Text);
              //  ClientManegercs m1 = new ClientManegercs(b_name, b_perm, x);
                Hide();
                m1.FormClosed += M1_FormClosed1;
                m1.ShowDialog();
            }
            try
            {
                if (Clients.check_if_exist(int.Parse(textBox1.Text), textBox2.Text) != null)
                {
                    label3.Visible = false;
                    Accounts a1 = new Accounts(int.Parse(textBox1.Text));
                    Hide();
                    a1.FormClosed += A1_FormClosed;
                    a1.ShowDialog();
                }
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
