using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Drawing;
namespace ProjectDraft
{
    class Employee
    {
       private int Employee_ID ;
        private string Employee_Name;
        private int Branch_Num;
        private string Employee_Username;
        private string passwordd;
        private string Employee_Photo;
        private string Employee_Permissions;
        public Employee(int x, string str, int y, string str2, string str3, string str4, string str5)
        {
            Employee_ID = x;
            Employee_Name = str;
            Branch_Num = y;
            Employee_Username = str2;
            passwordd = str3;
            Employee_Photo = str4;
            Employee_Permissions = str5;
        }
        public int GetSetEmployee_ID
        {
            set { this.Employee_ID = value; }
            get { return this.Employee_ID; }
        }
        public string SetGetEmployee_Name
        {
            set { this.Employee_Name = value; }
            get { return this.Employee_Name; }
        }
        public string SetGetEmployee_Username
        {
            set { this.Employee_Username = value; }
            get { return this.Employee_Username; }
        }
        public int SetGetBranch_Num
        {
            set { this.Branch_Num = value; }
            get { return Branch_Num; }
            
        }
        public string SetGetPasswordd
        {
            set { this.passwordd = value; }
            get { return this.passwordd; }
        }
        public Image SetGetEmployee_photo
        {
            set { this.Employee_Photo = value.ToString(); }
            get { return Image.FromFile(Employee_Photo); }
        }
            public string SetGetEmployee_Permissions
        { 
            set { this.Employee_Permissions = value; }
            get { return this.Employee_Permissions; }
        }
        
        //Methods ..(Add/Update/Delete)
        public string GetEmployeePhoto()
        {
            return Employee_Photo;
        }
  public static bool AddEmployee(int EmployeeID, string EmployeeName, int BranchNum, string Username, string Passwordd,string EmployeePhoto, string Permissions)
 {
            bool flag = false;
            Connector cn = new Connector("Bank.accdb");
            string sql = "insert into Employees(Employee_ID,Employee_Name,Branch_Num,Employee_Username,Passwordd,Employee_Photo,Employee_Permissions)";
            sql += " values(";
            sql += "" + EmployeeID + ",";
            sql += "'" + EmployeeName + "',";
            sql += "'" + BranchNum + "',";
            sql += "'" + Username + "',";
            sql += "'" + Passwordd + "',";
            sql += "'" + EmployeePhoto + "',";
            sql += "'" + Permissions + "'";
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

        public static bool RemoveEmployee(Employee b1)
        {
            Connector con = new Connector("Bank.accdb");
            string sql = "delete from Employees where Employee_ID= " + b1.Employee_ID;
            int x = con.RunUpdateInsertDelete(sql);
            return x > 0;

        }
        public static bool UpdateEmployee(Employee b)
        {
            Connector con = new Connector("Bank.accdb");
            string sql = "update Employees set";
            sql += " Employee_Name='" + b.Employee_Name + "'";
            sql += " ,Branch_Num=" + b.Branch_Num + "";
            sql += " ,Employee_Username='" + b .Employee_Username + "'";
            sql += " ,Passwordd='" + b.passwordd + "'";
            sql += " ,Employee_Photo='" + b.Employee_Photo + "'";
            sql += " ,Employee_Permissions='" + b.Employee_Permissions + "'";
            sql += " where  Employee_ID=" + b.Employee_ID;

            int x = con.RunUpdateInsertDelete(sql);
            return x > 0;
        }
        public static List<Employee> GetAll()
        {
            List<Employee> AllEmployees = new List<Employee>();
            Connector con = new Connector("Bank.accdb");

            OleDbDataReader result = con.RunSelect("select * from Employees");
            Employee b;
            while (result.Read())
            {
                b = new Employee(int.Parse(result["Employee_ID"].ToString()), result["Employee_Name"].ToString(),
                    int.Parse(result["Branch_Num"].ToString()), result["Employee_Username"].ToString(),
                    result["Passwordd"].ToString(),result["Employee_photo"].ToString(),result["Employee_Permissions"].ToString());
                AllEmployees.Add(b);
            }
            con.CloseConnection();
            return AllEmployees;
        }
        public static List<Employee> regardingTOBranchNum(int x )
        {
            List<Employee> l1 = new List<Employee>();
            Connector con = new Connector("Bank.accdb");
            Employee b1;
            OleDbDataReader result = con.RunSelect("select * from Employees where Branch_Num=" + x);
            while (result.Read())
            {
                b1 = new Employee(int.Parse(result["Employee_ID"].ToString()), result["Employee_Name"].ToString(),
                    int.Parse(result["Branch_Num"].ToString()), result["Employee_Username"].ToString(),
                    result["Passwordd"].ToString(), result["Employee_photo"].ToString(), result["Employee_Permissions"].ToString());
                l1.Add(b1);
            }
            con.CloseConnection();
            return l1;
        }
        public static Employee check_if_exist(string UserName, string passworde)
        {
            Employee b = null;
            Connector con = new Connector("Bank.accdb");
            OleDbDataReader result = con.RunSelect("select * from Employees where Employee_Username='" + UserName + "' and Passwordd='" + passworde + "'");
            while (result.Read())
            {
                b = new Employee(int.Parse(result["Employee_ID"].ToString()), result["Employee_Name"].ToString(),
                    int.Parse(result["Branch_Num"].ToString()), result["Employee_Username"].ToString(),
                    result["Passwordd"].ToString(),result["Employee_photo"].ToString(), result["Employee_Permissions"].ToString());
            }
            con.CloseConnection();
            return b;
        }
        public static Employee regardingtoUserName(string x)
        {
            Employee b = null;
            Connector con = new Connector("Bank.accdb");
            OleDbDataReader result = con.RunSelect("select * from Employees where Employee_Username='" + x +"'");
                
            while (result.Read())
            {
                b = new Employee(int.Parse(result["Employee_ID"].ToString()), result["Employee_Name"].ToString(),
                    int.Parse(result["Branch_Num"].ToString()), result["Employee_Username"].ToString(),
                    result["Passwordd"].ToString(), result["Employee_photo"].ToString(), result["Employee_Permissions"].ToString());
            }
            con.CloseConnection();
            return b;
        }

    }
}
