using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class ItemGateway:CommonGateway
    {
        public int Save(Item item)
        {
            Query = "INSERT INTO Item VALUES(@categoryId,@companyId,@name,@reorderlevel)";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("categoryId", SqlDbType.Int);
            Command.Parameters["categoryId"].Value = item.CategoryId;
            Command.Parameters.Add("companyId", SqlDbType.Int);
            Command.Parameters["companyId"].Value = item.CompanyId;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = item.Name;
            Command.Parameters.Add("reorderlevel", SqlDbType.Int);
            Command.Parameters["reorderlevel"].Value = item.ReorderLevel;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsItemExists(Item item)
        {
            Query = "SELECT * FROM Item WHERE Name='" + item.Name + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = false;
            if (Reader.HasRows)
            {
                hasRows = true;
            }
            Connection.Close();
            return hasRows;
        }
        public List<Item> GetAllItemsByCompanyId(int id)
        {
            Query = "SELECT * FROM Item WHERE CompanyId="+id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Item> items = new List<Item>();
            while (Reader.Read())
            {
                Item item = new Item();
                item.Id = (int)Reader["Id"];
                item.CategoryId = (int) Reader["CategoryId"];
                item.CompanyId = (int) Reader["CompanyId"];
                item.Name = Reader["Name"].ToString();
                item.ReorderLevel = (int) Reader["ReorderLevel"];    
                items.Add(item);
            }
            Reader.Close();
            Connection.Close();
            return items;
        }

        public int GetReorderLevel(int id)
        {
            Query = "SELECT * FROM Item WHERE Id=" + id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int reorderLevel=0;
            while (Reader.Read())
            {
                reorderLevel = (int)Reader["ReorderLevel"];
            }
            //if (Reader.HasRows)
            //{
            //    reorderLevel = (int)Reader["ReorderLevel"];
            //}
            //while (Reader.Read())
            //{
            //    Item item = new Item();
            //    item.Id = (int)Reader["Id"];
            //    item.CategoryId = (int)Reader["CategoryId"];
            //    item.CompanyId = (int)Reader["CompanyId"];
            //    item.Name = Reader["Name"].ToString();
            //    item.ReorderLevel = (int)Reader["ReorderLevel"];
            //}
            Reader.Close();
            Connection.Close();
            return reorderLevel;
        }

        public int GetItemIdByItemName(string item)
        {
            Query = "SELECT * FROM Item WHERE Name='"+item+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int id = 0;
            while (Reader.Read())
            {
                id = (int) Reader["Id"];
            }
            Reader.Close();
            Connection.Close();
            return id;
        }
    }
}