using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ProjectDraft
{
    class Connector
    {
        private OleDbConnection aConnection;
        private OleDbCommand aCommand;
        private string connect_string;
        private string the_exception;
       


        public Connector(string Db_Name)
        {
            this.connect_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Db_Name;
            aConnection = new OleDbConnection(connect_string);
           
        }

        public string GetError()
        {
            return the_exception;
        }

        public OleDbDataReader RunSelect(string sql)
        {
            OleDbDataReader aReader=null;
            aCommand = new OleDbCommand(sql, aConnection);
            try
            {
                aConnection.Open();
                aReader = aCommand.ExecuteReader();
            //    aConnection.Close();
            }
            catch (Exception err)
            {
                the_exception = err.Message;
            }
            return aReader;

        }

        public int RunUpdateInsertDelete(string sql)
        {
            int r = -1;
            aCommand = new OleDbCommand(sql, aConnection);
            try
            {
                aConnection.Open();
                r = aCommand.ExecuteNonQuery();
                aConnection.Close();
            }
            catch (Exception err)
            {
                the_exception = err.Message;
            }
            return r;

        }

        public int RunScalar(string sql)
        {
            int r = 0;
            aCommand = new OleDbCommand(sql, aConnection);
            try
            {
                aConnection.Open();
                r = Convert.ToInt16(aCommand.ExecuteScalar());
                //r = (int)(aCommand.ExecuteScalar());
                aConnection.Close();
            }
            catch (Exception err)
            {
                the_exception = err.Message;
            }
            return r;

        }

        public void CloseConnection()
        {
            aConnection.Close();
        }

    }
}
