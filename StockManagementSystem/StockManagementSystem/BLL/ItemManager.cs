using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway=new ItemGateway();
        public string Save(Item item)
        {
            if (itemGateway.IsItemExists(item))
            {
                return "Item exist";
            }
            int rowAffected = itemGateway.Save(item);
            if (rowAffected > 0)
                return "Item saved successfully";
            return "Item saved failed";
        }

        public List<Item> GetAllItemsByCompanyId(int id)
        {
            return itemGateway.GetAllItemsByCompanyId(id);
        }

        public int GetReorderLevel(int id)
        {
            return itemGateway.GetReorderLevel(id);
        }

        public int GetItemIdByItemName(string item)
        {
            return itemGateway.GetItemIdByItemName(item);
        }
    }
}