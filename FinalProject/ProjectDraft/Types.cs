using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjectDraft
{
    class Types
    {
        private int Type_Num;
        private string Type_Name;
        private string Type_Cost;
        
        public Types(int x ,string str,string str1)
        {
            Type_Num = x;
            Type_Name = str;
            Type_Cost = str1;
        }
         public int Get_TypeNum
        {
            get { return Type_Num; }
        }
        
        public string Get_TypeName
        {
            get { return Type_Name; }

        }
        public string Get_TypeCost
        {
            get { return Type_Cost; }
        }
        public static List<Types> GetAll()
        {
            List<Types> AllEmployees = new List<Types>();
            Connector con = new Connector("Bank.accdb");

            OleDbDataReader result = con.RunSelect("select * from Types");
            Types b;
            while (result.Read())
            {
                b = new Types(int.Parse(result["Type_Num"].ToString()),result["Type_Name"].ToString(),result["Type_Cost"].ToString());
                AllEmployees.Add(b);
            }
            con.CloseConnection();
            return AllEmployees;
        }
        public static List<Types> GetbyID (string str)
        {
            List<Types> alltypes = new List<Types>();
            string[] arr= str.Split(',');
            Connector con = new Connector("Bank.accdb");
            OleDbDataReader result = null;
           

                result = con.RunSelect("select * from Types where Type_Num in ("+str+")");
            

                Types b;
                while (result.Read())
                {
                    b = new Types(int.Parse(result["Type_Num"].ToString()), result["Type_Name"].ToString(), result["Type_Cost"].ToString());
                    alltypes.Add(b);

                }
            
            con.CloseConnection();

            return alltypes;


        }
        public static Types GetbyID2(int ID)
        {


            Connector con = new Connector("Bank.accdb");
            OleDbDataReader result = null;


            result = con.RunSelect("select * from Types where Type_Num="+ID);


            Types b=null;
            while (result.Read())
            {
                b = new Types(int.Parse(result["Type_Num"].ToString()), result["Type_Name"].ToString(), result["Type_Cost"].ToString());
            }

            con.CloseConnection();

            return b;
        }


        public override string ToString()
        {
            return Type_Name;
        }

    }
}
