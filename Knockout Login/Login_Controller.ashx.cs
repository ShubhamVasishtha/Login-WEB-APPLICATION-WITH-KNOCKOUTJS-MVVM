using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Westwind.Web;
using System.Data.SqlClient;

namespace Knockout_Login
{

    public class Loginclass : CallbackHandler
    {

        [CallbackMethod]
        public string login(string username, string password)
        {
            string conn = "Server=(localdb)\\MSSQLLocalDB;Database=LoginForm;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conn);
            object result = "";
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = string.Format("SELECT CASE WHEN EXISTS (SELECT username from login where username='{0}' and password='{1}') THEN 'User Authenticated' Else 'Invalid User or Password' End", username, password);
               result = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return result.ToString();

        }
    }
}