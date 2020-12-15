using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class SearchAndViewGateway:CommonGateway
    {
        public List<SearchAndView> Search(Item item)
        {
            Query = "SELECT * FROM GetAllInformation WHERE CompanyId='" + item.CompanyId + "' OR CategoryId='" +
                    item.CategoryId + "'";

            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SearchAndView> searchAndViews = new List<SearchAndView>();
            while (Reader.Read())
            {
                SearchAndView searchAndView=new SearchAndView();
                searchAndView.Item = Reader["Item"].ToString();
                searchAndView.Company = Reader["Company"].ToString();
                searchAndView.Category = Reader["Category"].ToString();
                searchAndView.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                searchAndView.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                searchAndViews.Add(searchAndView);
            }
            Reader.Close();
            Connection.Close();
            return searchAndViews;
        }
    }
}