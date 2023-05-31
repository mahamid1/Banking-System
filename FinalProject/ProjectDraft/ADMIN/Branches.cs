using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjectDraft
{
    class Branches
    {
        private int Branch_Num;
        private string Branch_Name;
        private string Branch_Location;
        private string BrachManeger_UserName;
        private string Passworde;
        
        public Branches(int x, string y, string z,string a , string b )
        {
            Branch_Num = x;
            Branch_Name = y;
            Branch_Location = z;
            BrachManeger_UserName = a;
            Passworde = b;
        }
        public int B_Number
        {
            set { Branch_Num = value; }
            get { return Branch_Num; }

        }
        public string B_Name
        {
            set { Branch_Name = value; }
            get { return Branch_Name; }

        }
        public string B_Location
        {
            set { Branch_Location = value; }
            get { return Branch_Location; }

        }
        public string B_Maneger
        {
            set { BrachManeger_UserName = value; }
            get { return BrachManeger_UserName; }

        }
        public string B_Password
        {
            set {Passworde = value; }
            get { return Passworde; }

        }

        //Methods ..(Add/Update/Delete)

        public static bool AddBranch(int BranchNum,string BranchName,string BranchLocation,string ManegerUsername,string Passworde)
        {
            bool flag = false;
            Connector cn = new Connector("Bank.accdb");
            string sql = "insert into Branches(Branch_Num,Branch_Name,Branch_Location,BrachManeger_UserName,Passworde)";
            sql += " values(";
            sql += "" + BranchNum + ",";
            sql += "'" + BranchName + "',";
            sql += "'" + BranchLocation + "',";
            sql += "'" + ManegerUsername + "',";
            sql += "'" + Passworde + "'";
            sql += ")";
            int x = cn.RunUpdateInsertDelete(sql);
            if (x > 0)
                flag = true; 
            else
            {
                Console.WriteLine(cn.GetError());
            }
            return flag;
        }

        public static bool RemoveBranch(Branches b1)
        {
            Connector con = new Connector("Bank.accdb");
            string sql = "delete from Branches where Branch_Num= " + b1.Branch_Num;
            int x = con.RunUpdateInsertDelete(sql);
            return x > 0;

        }
        public static bool UpdateBranch(Branches b)
        {
            Connector con = new Connector("Bank.accdb");
            string sql = "update Branches set";
            sql += " Branch_Name='" + b.Branch_Name + "'";
            sql += " ,Branch_Location='" + b.Branch_Location + "'";
            sql += " ,BrachManeger_UserName='" + b.BrachManeger_UserName + "'";
            sql += " ,Passworde='" + b.Passworde + "'";
            sql += " where Branch_Num=" + b.Branch_Num;

            int x = con.RunUpdateInsertDelete(sql);
            return x > 0;
        }
        public static List<Branches> GetAll()
        {
            List<Branches> Branch = new List<Branches>();
            Connector con = new Connector("Bank.accdb");

            OleDbDataReader result = con.RunSelect("select * from Branches");
            Branches b;
            while (result.Read())
            {
                b = new Branches(int.Parse(result["Branch_Num"].ToString()), result["Branch_Name"].ToString(),
                    result["Branch_Location"].ToString(), result["BrachManeger_UserName"].ToString(),
                    result["Passworde"].ToString());
                Branch.Add(b);
            }
            con.CloseConnection();
            return Branch;
        }

    }
}
