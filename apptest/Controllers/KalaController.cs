using apptest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace apptest.Controllers
{
    public class KalaController : ApiController
    {
        public void insertkal(string name, int price)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insertkala";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", name);
            cmd.ExecuteNonQuery();
        }
    }
}
