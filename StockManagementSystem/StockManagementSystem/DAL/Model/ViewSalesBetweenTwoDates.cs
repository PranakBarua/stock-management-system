using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class ViewSalesBetweenTwoDates
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ActionType { get; set; }
    }
}