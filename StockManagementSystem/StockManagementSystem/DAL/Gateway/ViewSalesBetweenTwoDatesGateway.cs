using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class ViewSalesBetweenTwoDatesGateway:CommonGateway
    {
        public List<StockOut> Search(ViewSalesBetweenTwoDates viewSalesBetweenTwoDates)
        {
            Query = "SELECT ItemName,StockOutQuantity FROM StockOut WHERE Date BETWEEN '"+viewSalesBetweenTwoDates.FromDate+"' AND '"+viewSalesBetweenTwoDates.ToDate+"' AND ActionType='Sell'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StockOut> stockOuts=new List<StockOut>();
            while (Reader.Read())
            {
                StockOut stockOut=new StockOut();
                stockOut.Item = Reader["ItemName"].ToString();
                stockOut.StockOutQuantity = (int) Reader["StockOutQuantity"];
                stockOuts.Add(stockOut);
            }
            Reader.Close();
            Connection.Close();
            return stockOuts;
        }
    }
}