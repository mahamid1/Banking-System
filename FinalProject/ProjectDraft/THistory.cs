using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjectDraft
{
    class THistory
    {
       
        int AccNumber;
        string TDate;
        string typename;
        int amountplus;
        int amountminus;
        int current;
        public THistory(int y , string str , string q, int d ,int l , int x)
        {
           
            AccNumber = y;
            TDate = str;
            typename = q;
            amountplus = d;
            amountminus = l;
            current = x;
        }
       
        public int setgetaccnum
        {
            set { AccNumber = value; }
            get { return AccNumber; }
        }
        public string setgetDate
        {
            set { TDate = value; }
            get { return TDate; }
        }
        public string setgettypename
        {
            set { typename = value; }
            get { return typename; }
        }
        public int setgetamount
        {
            set { amountplus = value; }
            get { return amountplus; }
        }
        public int setgetminus
        {
            set { amountminus = value; }
            get { return amountminus; }
        }
        public int setgetcurrent
        {
            set { current = value; }
            get { return current; }
        }
        public static bool AddToHistory(int AccNum, string TDate, int amountplus, int amountminus, string typename, int current)
        {
            bool flag = false;
            Connector cn = new Connector("Bank.accdb");
            string sql = "insert into History(AccNum,TransictionDate,TypeName,amountminus,amountPlus,CurrentAmount)";
            sql += " values(";
            sql += "" + AccNum + ",";
            sql += "'" + TDate + "',";
            sql += "'" + typename + "',";
            sql += "" + amountminus + ",";
            sql += "" + amountplus + ",";
            sql += "" + current + ")";
            int x = cn.RunUpdateInsertDelete(sql);
            if (x > 0)
                flag = true;
            else
            {
                Console.WriteLine(cn.GetError());
            }
            return flag;
        }
        public static List<THistory> GetAllbyacc(int x)
        {
            List<THistory> AllHistory = new List<THistory>();
            Connector con = new Connector("Bank.accdb");

            OleDbDataReader result = con.RunSelect("select * from History where AccNum="+x);
           THistory b;
            while (result.Read())
            {
                b = new THistory( int.Parse(result["AccNum"].ToString()), result["TransictionDate"].ToString(), result["TypeName"].ToString(), int.Parse(result["amountPlus"].ToString()), int.Parse(result["amountminus"].ToString()), int.Parse(result["CurrentAmount"].ToString()));
                AllHistory.Add(b);
            }
            con.CloseConnection();
            return AllHistory;
        }
    }
}
