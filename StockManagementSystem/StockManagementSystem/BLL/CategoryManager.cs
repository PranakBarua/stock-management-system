using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway=new CategoryGateway();
        public string Save(Category category)
        {
            if (categoryGateway.IsNameExists(category))
                return "Category name exist";
            int rowAffected = categoryGateway.Save(category);
            if (rowAffected > 0)
                return "Category saved successfully";
            return "Category saved failed";
        }

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }

        public string Update(Category category)
        {
            if (categoryGateway.IsNameExists(category))
                return "Category name exist";
            int rowAffected = categoryGateway.Update(category);
            if (rowAffected > 0)
                return "Category updated successfully";
            return "Category updated failed";
        }
    }
}