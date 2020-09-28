using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System.Configuration;


namespace project
{
    public static class DataAccess
    {
        // private static string _connectionString =
        //   @"Data Source=DESKTOP-1TPJ3P1;Initial Catalog=ProjectLB;Integrated Security=True";
        public static DataTable LoadData(string query)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();

                OracleCommand cmd = new OracleCommand(query, con);
                DataSet ds = new DataSet();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                return dt;
            }
            catch (Exception exception)
            {
                return new DataTable();
            }
        }

        public static int ExecuteQuery(string query)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();

                OracleCommand cmd = new OracleCommand(query, con);
                int row = cmd.ExecuteNonQuery();
                return row;
            }
            catch (Exception exception)
            {

                return -1;
            }
        }
        public static int Check_UserId(String UserId)
        {


            try
            {
                DataTable dt = DataAccess.LoadData("select * from UserInfo where UserName='" + UserId + "' ");

                if (dt.Rows.Count != 1)
                {

                    return 2;
                }


                return 1;

            }
            catch (Exception ex)
            {


                return -1;
            }

        }
    }
}
