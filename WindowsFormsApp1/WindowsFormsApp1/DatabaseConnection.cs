﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccountingSoft
{
    class DatabaseConnection
    {
        SqlConnection con;
        SqlCommand comd;
        public DatabaseConnection()
        {
            string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDB.mdf;
                Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        public void ExecNonSQL(string storeProcQuery)
        {
            try
            {
                con.Open();
                comd = new SqlCommand(storeProcQuery, con);
                comd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine(ex);
            }
        }

        public DataTable ExecSQL(string storeProcQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                comd = new SqlCommand(storeProcQuery, con);
                dt.Load(comd.ExecuteReader());
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
