using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class StockInGateway:CommonGateway
    {
        public StockIn GetAvailableAndStockInQuantity(int id)
        {
            Query = "SELECT * FROM StockIn WHERE ItemId=" + id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            //int availableQuantity = 0;
            //int stockInQuantity = 0;
            StockIn stockIn = null;
            while (Reader.Read())
            {
                stockIn = new StockIn();
                stockIn.AvailableQuantity = (int)Reader["AvailableQuantity"];
                stockIn.StockInQuantity = (int)Reader["StockInQuantity"];
            }
            Reader.Close();
            Connection.Close();
            return stockIn;
        }
        public int GetAvailableQuantity(int id)
        {
            Query = "SELECT * FROM StockIn WHERE ItemId=" + id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int availableQuantity = 0;
            while (Reader.Read())
            {
                availableQuantity = (int)Reader["AvailableQuantity"];
            }
            Reader.Close();
            Connection.Close();
            return availableQuantity;
        }

        public int GetStockInQuantity(int id)
        {
            Query = "SELECT * FROM StockIn WHERE ItemId=" + id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int stockInQuantity = 0;
            while (Reader.Read())
            {
                stockInQuantity = (int)Reader["AvailableQuantity"];
            }
            Reader.Close();
            Connection.Close();
            return stockInQuantity;
        }

        public int Save(StockIn stockIn)
        {
            Query = "INSERT INTO StockIn VALUES(@companyId,@itemId,@reorderlevel,@availableQuantity,@stockInQuantity)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("companyId", SqlDbType.Int);
            Command.Parameters["companyId"].Value = stockIn.CompanyId;
            Command.Parameters.Add("itemId", SqlDbType.Int);
            Command.Parameters["itemId"].Value = stockIn.ItemId;
            Command.Parameters.Add("reorderlevel", SqlDbType.Int);
            Command.Parameters["reorderlevel"].Value = stockIn.ReorderLevel;
            Command.Parameters.Add("availableQuantity", SqlDbType.Int);
            Command.Parameters["availableQuantity"].Value = stockIn.AvailableQuantity;
            Command.Parameters.Add("stockInQuantity", SqlDbType.Int);
            Command.Parameters["stockInQuantity"].Value = stockIn.StockInQuantity;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsItemIdExist(int itemId)
        {
            Query = "SELECT * FROM StockIn WHERE ItemId=" + itemId;
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = false;
            if (Reader.HasRows)
            {
                hasRows = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public int Update(StockIn stockIn)
        {
            Query = "UPDATE StockIn SET AvailableQuantity=" + stockIn.AvailableQuantity + ",StockInQuantity=" +
                    stockIn.StockInQuantity + " WHERE ItemID=" + stockIn.ItemId;
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public void UpdateAvailableQuantity(StockIn stockIn)
        {
            Query = "UPDATE StockIn SET AvailableQuantity=" +stockIn.AvailableQuantity+ " WHERE ItemId=" + stockIn.ItemId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}