using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class ViewSalesBetweenTwoDatesManager
    {
        ViewSalesBetweenTwoDatesGateway viewSalesBetweenTwoDatesGateway=new ViewSalesBetweenTwoDatesGateway();
        public List<StockOut> Search(ViewSalesBetweenTwoDates viewSalesBetweenTwoDates)
        {
            return viewSalesBetweenTwoDatesGateway.Search(viewSalesBetweenTwoDates);
        }
    }
}