using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjectDraft
{
    class check
    {
        int CheckNum;
        int accNum;
        string CheckDate;
        int amount;
        int BranchNum;
        int ToAccountNum;
        public check(int x , int y , int z , string str , int w,int q)
        {
            CheckNum = x;
            accNum = y;
            amount = z;
            CheckDate = str;
            BranchNum = w;
            ToAccountNum = q;
        }
        public int setgetCheckNum
        {
            set { CheckNum = value; }
            get { return CheckNum; }
        }
        public int setgetacc
        {
            set { accNum = value; }
            get { return accNum; }
        }
        public string getsetdate
        {
            set { CheckDate = value; }
            get { return CheckDate; }
        }
        public int setgetamount
        {
            set { amount = value; }
            get { return amount; }
        }
        public int setgetBranch
        {
            set { BranchNum = value; }
            get { return BranchNum; }

        }
        public int setgetTO
        {
            set { ToAccountNum = value; }
            get { return ToAccountNum;  }
        }
        public static bool AddCheck(int CheckNum, int AccNum, string CheckDate, int amount, int BranchNum, int ToAccountNum)
        {
            bool flag = false;
            Connector cn = new Connector("Bank.accdb");
            string sql = "insert into checks(checkNum,AccountNum,amount,checkDate,BranchNum,ToAccountNum)";
            sql += " values(";
            sql += "" + CheckNum + ",";
            sql += "" + AccNum + ",";
            sql += "" + amount + ",";
            sql += "'" +CheckDate + "',";
            sql += "" + BranchNum + ",";
            sql += "" + ToAccountNum + ")";    
            int x = cn.RunUpdateInsertDelete(sql);
            if (x > 0)
                flag = true;
            else
            {
                Console.WriteLine(cn.GetError());
            }
            return flag;
        }
        public static bool RemoveCheck(check b1)
        {
            Connector con = new Connector("Bank.accdb");
            string sql = "delete from checks where checkNum= " + b1.CheckNum;
            int x = con.RunUpdateInsertDelete(sql);
            return x > 0;

        }


        public static List<check> GetAll()
        {
            List<check> AllChecks = new List<check>();
            Connector con = new Connector("Bank.accdb");

            OleDbDataReader result = con.RunSelect("select * from checks");
            check b;
            while (result.Read())
            {
                b = new check(int.Parse(result["checkNum"].ToString()), int.Parse(result["AccountNum"].ToString()), int.Parse(result["amount"].ToString()), result["checkDate"].ToString(), int.Parse(result["BranchNum"].ToString()),int.Parse(result["ToAccountNum"].ToString()));
                AllChecks.Add(b);
             }
            con.CloseConnection();
            return AllChecks;
        }
        public static List<check> GetAllbyaccnum(int x)
        {
            List<check> AllChecks = new List<check>();
            Connector con = new Connector("Bank.accdb");

            OleDbDataReader result = con.RunSelect("select * from checks where AccountNum="+x);
            check b;
            while (result.Read())
            {
                b = new check(int.Parse(result["checkNum"].ToString()), int.Parse(result["AccountNum"].ToString()), int.Parse(result["amount"].ToString()), result["checkDate"].ToString(), int.Parse(result["BranchNum"].ToString()), int.Parse(result["ToAccountNum"].ToString()));
                AllChecks.Add(b);
            }
            con.CloseConnection();
            return AllChecks;
        }

    }
}
