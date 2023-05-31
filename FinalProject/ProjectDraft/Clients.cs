    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjectDraft
{
    class Clients
    {
        private int Acc_Num;
        private string Client_ID;
        private string Client_Name;
        private string Starting_Date;
        private int Current_Ammount;
        private int Max_Debt;
        private int Branch_Num;
        public Clients(int x, string str, string str2, string time, int y, int z, int w)
        {
            Acc_Num = x;
            Client_ID = str;
            Client_Name = str2;
            Starting_Date = time;
            Current_Ammount = y;
            Max_Debt = z;
            Branch_Num = w;

        }

        public int SetGetAcc_Num
        {
            set { Acc_Num = value; }
            get { return Acc_Num; }
        }

        public string SetGetClientID
        {
            set { Client_ID = value; }
            get { return Client_ID; }
        }

        public string SetGetClientName
        {
            set { Client_Name = value; }
            get { return Client_Name; }
        }
        
        public string SetGetStart
        {
            set { Starting_Date = value; }
            get { return Starting_Date; }
        }

        public int SetGetCurrent
        {
            set { Current_Ammount = value; }
            get { return Current_Ammount; }
        }
        public int SetGetMaxDebt
        {
            set { Max_Debt = value; }
            get { return Max_Debt; }
        }

        public int SetGetBranch
        {
            set { Branch_Num = value; }
            get { return Branch_Num; }
        }
        public static bool AddClient(int AccNum, string ClientID, string ClientName, string Starting, int CurrentAmmount, int maxDebt, int BranchNum)
        {
            bool flag = false;
            Connector cn = new Connector("Bank.accdb");
            string sql = "insert into Client(Account_Num,Client_ID,Client_Name,Starting_Date,Current_Amount,MaxDebt,Branch_Num)";
            sql += " values(";
            sql += "" + AccNum + ",";
            sql += "'" + ClientID + "',";
            sql += "'" + ClientName + "',";
            sql += "'" + Starting + "',";
            sql += "" + CurrentAmmount + ",";
            sql += "" + maxDebt + ",";
            sql += "" + BranchNum + ")";
           // sql += ")";
            int x = cn.RunUpdateInsertDelete(sql);
            if (x > 0)
                flag = true;
            else
            {
                Console.WriteLine(cn.GetError());
            }
            return flag;
        }
        public static bool RemoveClient(Clients b1)
        {
            Connector con = new Connector("Bank.accdb");
            string sql = "delete from Client where Account_Num= " + b1.Acc_Num;
            int x = con.RunUpdateInsertDelete(sql);
            return x > 0;

        }
        public static List<Clients> GetAllByBranch(int x)
        {
            List<Clients> c1 = new List<Clients>();
            Connector con = new Connector("Bank.accdb");
            Clients b;
            OleDbDataReader result = con.RunSelect("select * from Client where Branch_Num = " +x);
           
            while (result.Read())
            {
                b = new Clients(int.Parse(result["Account_Num"].ToString()), result["Client_ID"].ToString(), result["Client_Name"].ToString(), result["Starting_Date"].ToString(), int.Parse(result["Current_Amount"].ToString()), int.Parse(result["MaxDebt"].ToString()), int.Parse(result["Branch_Num"].ToString()));
                c1.Add(b);
            }
            con.CloseConnection();
            return c1;
        }

        public static bool UpdateClient(Clients c1)

        {
            Connector con = new Connector("Bank.accdb");
            string sql = "update Client set ";
            sql += "Client_ID='" + c1.Client_ID + "',";
            sql += "Client_Name='" + c1.Client_Name + "',";
            sql += "Starting_Date='" + c1.Starting_Date + "',";
            sql += "Current_Amount=" + c1.Current_Ammount + ",";
            sql += "MaxDebt=" + c1.Max_Debt + ",";
            sql += "Branch_Num=" + c1.Branch_Num;
            sql += " where Account_Num= " + c1.Acc_Num;
            int x = con.RunUpdateInsertDelete(sql);
            return x > 0;
        }

        public static Clients getclientbyAcc(int num)
        {
            Connector con = new Connector("Bank.accdb");
            Clients b = null;
            OleDbDataReader result = con.RunSelect("select * from Client where Account_Num = " + num);

            while (result.Read())
            {
                b = new Clients(int.Parse(result["Account_Num"].ToString()), result["Client_ID"].ToString(), result["Client_Name"].ToString(), result["Starting_Date"].ToString(), int.Parse(result["Current_Amount"].ToString()), int.Parse(result["MaxDebt"].ToString()), int.Parse(result["Branch_Num"].ToString()));
               
            }
            con.CloseConnection();
            return b;

        }
        public static Clients check_if_exist(int UserName, string passworde)
        {
            Clients b = null;
            Connector con = new Connector("Bank.accdb");
            OleDbDataReader result = con.RunSelect("select * from Client where Account_Num=" + UserName + " and Client_ID='" + passworde + "'");
            while (result.Read())
            {
                b = new Clients(int.Parse(result["Account_Num"].ToString()), result["Client_ID"].ToString(), result["Client_Name"].ToString(), result["Starting_Date"].ToString(), int.Parse(result["Current_Amount"].ToString()), int.Parse(result["MaxDebt"].ToString()), int.Parse(result["Branch_Num"].ToString()));
            }
            con.CloseConnection();
            return b;
        }
        public static Clients getclientbyID(string num)
        {
            Connector con = new Connector("Bank.accdb");
            Clients b = null;
            OleDbDataReader result = con.RunSelect("select * from Client where Client_ID ='" + num+"'");

            while (result.Read())
            {
                b = new Clients(int.Parse(result["Account_Num"].ToString()), result["Client_ID"].ToString(), result["Client_Name"].ToString(), result["Starting_Date"].ToString(), int.Parse(result["Current_Amount"].ToString()), int.Parse(result["MaxDebt"].ToString()), int.Parse(result["Branch_Num"].ToString()));

            }
            con.CloseConnection();
            return b;

        }

    }
}
