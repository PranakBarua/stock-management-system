using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class StockOutManager
    {
        StockOutGateway stockOutGateway=new StockOutGateway();
        public string AddStockOut(StockOut stockOut)
        {
            int rowAffected = stockOutGateway.AddStockOut(stockOut);
            if (rowAffected > 0)
                return "StockOut successfully";
            return "StockOut failed";
        }
    }
}