using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class StockInManager
    {
        StockInGateway stockInGateway=new StockInGateway();
        public StockIn GetAvailableAndStockInQuantity(int id)
        {
            return stockInGateway.GetAvailableAndStockInQuantity(id);
        }

        public string Save(StockIn stockIn)
        {
            int rowAffected = stockInGateway.Save(stockIn);
            if (rowAffected > 0)
                return "Stock in saved successfully";
            return "Stock in saved failed";
        }

        public bool IsItemIdExist(int itemId)
        {
            return stockInGateway.IsItemIdExist(itemId);
        }

        public string Update(StockIn stockIn)
        {
            int rowAffected = stockInGateway.Update(stockIn);
            if (rowAffected > 0)
                return "Stock in Updated successfully";
            return "Stock in Updated failed";
        }

        public int GetAvailableQuantity(int id)
        {
            return stockInGateway.GetAvailableQuantity(id);
        }

        public int GetStockInQuantity(int id)
        {
            return stockInGateway.GetStockInQuantity(id);
        }

        public void UpdateAvailableQuantity(StockIn stockIn)
        {
            stockInGateway.UpdateAvailableQuantity(stockIn);
        }
    }
}