using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MobileApp
{
    public class Connection
    {


        public bool ConnectionOpen(SqlConnection Conn, string DBName)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.ConnectionString = GetConnectionString("local", DBName);
                    Conn.Open();
                    return true;
                }
                else return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool Disconnection(SqlConnection Conn)
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                    return true;
                }
                else return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static string GetConnectionString(string location, string database)
        {

            try
            {
                string approotpath = Application.StartupPath;
                string filepath = approotpath + "/EPConnection.Config";
                string ServerName = EPINIFunctions.ReadValue(location, "ServerName", filepath);
                string UserName = EPINIFunctions.ReadValue(location, "UserName", filepath);
                string Password = EPINIFunctions.ReadValue(location, "Password", filepath);
                string condatabase = EPINIFunctions.ReadValue(location, database, filepath);

                string constring = "Data Source=" + ServerName + ";Initial Catalog =" + condatabase + ";Integrated Security=True";

                return constring;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }
        }


        public int GetMaxValue(SqlConnection MaxValConn, string MaxValQuery)
        {

            try
            {
                SqlCommand MaxValCmd = new SqlCommand();
                DataTable dt = new DataTable();

                MaxValCmd.CommandType = System.Data.CommandType.Text;
                MaxValCmd.CommandText = MaxValQuery;
                MaxValCmd.Connection = MaxValConn;
                SqlDataAdapter da = new SqlDataAdapter(MaxValCmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Column1"].ToString() == "")
                    {
                        return 0;
                    }
                    else return Convert.ToInt32((dt.Rows[0]["Column1"].ToString()));
                }
                else return 0;
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int GetCount(SqlConnection CountValConn, string CountValQuery)
        {

            try
            {
                SqlCommand CountValCmd = new SqlCommand();
                DataTable dt = new DataTable();

                CountValCmd.CommandType = System.Data.CommandType.Text;
                CountValCmd.CommandText = CountValQuery;
                CountValCmd.Connection = CountValConn;
                SqlDataAdapter da = new SqlDataAdapter(CountValCmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Column1"].ToString() == "")
                    {
                        return 0;
                    }
                    else return Convert.ToInt32((dt.Rows[0]["Column1"].ToString()));
                }
                else return 0;
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public string GetTableColumnValue(SqlConnection ColumnValConn, string ColumnValQuery)
        {

            try
            {
                SqlCommand ColumValCmd = new SqlCommand();
                DataTable dt = new DataTable();

                ColumValCmd.CommandType = System.Data.CommandType.Text;
                ColumValCmd.CommandText = ColumnValQuery;
                ColumValCmd.Connection = ColumnValConn;
                SqlDataAdapter da = new SqlDataAdapter(ColumValCmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].GetType() == typeof(System.DateTime))
                    {

                        DateTime DateValue = DateTime.Parse(dt.Rows[0][0].ToString());
                        string StringValue = DateValue.ToShortDateString();
                        return StringValue;
                    }
                    else if (dt.Rows[0][0].GetType() == typeof(System.DBNull))
                    {
                        return "";
                    }
                    else
                    {
                        return dt.Rows[0][0].ToString();
                    }

                }
                else return "";
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
                return "";
            }
        }


    }
}
