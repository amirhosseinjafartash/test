using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apptest.Models;

namespace apptest.Controllers
{
    public class UserController : ApiController
    {
        public void insertuser(string name,int shomare)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insertuser";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@shomare", shomare);
            cmd.ExecuteNonQuery();
            //con.Close();
        }
        public static List<User> show()
        {
            List<User> usershow = new List<User>();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ShowUser";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User User = new User();
                User.name = dt.Rows[i]["U_Name"].ToString();
                User.id = Convert.ToInt16(dt.Rows[i]["ID_"]);
                usershow.Add(User);
            }
            return usershow;
        }
    }
}
