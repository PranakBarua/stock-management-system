using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class SearchAndViewManager
    {
        SearchAndViewGateway searchAndViewGateway=new SearchAndViewGateway();
        public List<SearchAndView> Search(Item item)
        {
            return searchAndViewGateway.Search(item);
        }
    }
}