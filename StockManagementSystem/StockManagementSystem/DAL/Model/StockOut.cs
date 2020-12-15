using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    [Serializable]
    public class StockOut
    {
        
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; }
        public int AvailableQuantity { get; set; }
        public int StockOutQuantity { get; set; }
        public DateTime Date { get; set; }
        public string ActionType { get; set; }

    }
}