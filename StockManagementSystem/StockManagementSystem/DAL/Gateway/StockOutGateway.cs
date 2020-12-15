using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class StockOutGateway:CommonGateway
    {
        public int AddStockOut(StockOut stockOut)
        {
            Query = "INSERT INTO StockOut Values('" + stockOut.Company + "','" + stockOut.Item + "','" +
                    stockOut.StockOutQuantity + "',GETUTCDATE(),'" + stockOut.ActionType + "')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}