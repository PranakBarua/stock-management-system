using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystem.DAL.Gateway
{
    public class CommonGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockManagementSystemDBConnection"].ConnectionString;

        public CommonGateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}