﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WorkFlowManagement.Models
{
    class DBHelper : IDisposable
    {
        String constr = System.Configuration.ConfigurationManager.ConnectionStrings["WorkflowDBConnStr"].ConnectionString;
        SqlConnection con = null;
        public DBHelper()
        {
            con = new SqlConnection(constr);
            con.Open();
        }
        public int ExecuteQuery(String query)
        {
            SqlCommand com = new SqlCommand(query, con);
            var a = com.ExecuteNonQuery();
            return a;
        }
        public object ExecuteScalar(String query)
        {
            SqlCommand com = new SqlCommand(query, con);
            return com.ExecuteScalar();
        }
        public SqlDataReader ExecuteReader(String query)
        {
            SqlCommand com = new SqlCommand(query, con);
            return com.ExecuteReader();
        }

        public void Dispose()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}