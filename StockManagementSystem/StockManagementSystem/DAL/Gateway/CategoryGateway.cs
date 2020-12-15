using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class CategoryGateway:CommonGateway
    {
        public bool IsNameExists(Category category)
        {
            Query = "SELECT * FROM Category WHERE Name='"+category.Name+"' AND Id <>'"+category.Id+"'";
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

        public int Save(Category category)
        {
            Query = "INSERT INTO Category VALUES(@name)";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = category.Name;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Category> GetAllCategories()
        {
            Query = "SELECT * FROM Category";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Category>categories=new List<Category>();
            while (Reader.Read())
            {
                Category category=new Category();
                category.Id = (int) Reader["Id"];
                category.Name = Reader["Name"].ToString();
                categories.Add(category);
            }
            Reader.Close();
            Connection.Close();
            return categories;
        }

        public int Update(Category category)
        {
            Query = "UPDATE Category SET Name='"+category.Name+"' WHERE Id="+category.Id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}