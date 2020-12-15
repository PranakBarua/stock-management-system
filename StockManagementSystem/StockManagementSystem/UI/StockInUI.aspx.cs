using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        StockInManager stockInManager = new StockInManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Company> companies = companyManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("---select Company---", "0"));
                
            }
            reorderLevelTextBox.Enabled = false;
            availableQuantityTextBox.Enabled = false;
           
        }

        protected void companyDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(companyDropDownList.SelectedValue);
            List<Item> items = itemManager.GetAllItemsByCompanyId(id);
            itemDropDownList.DataSource = items;
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataTextField = "Name";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("---select Item---", "0"));
        }

        protected void itemDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(itemDropDownList.SelectedValue);
            reorderLevelTextBox.Text = itemManager.GetReorderLevel(id).ToString();
            availableQuantityTextBox.Text = stockInManager.GetAvailableQuantity(id).ToString();
            //if (stockIn == null)
            //{
            //    int availableQuantity = 0;
            //    availableQuantityTextBox.Text = availableQuantity.ToString();
            //}
            //else
            //{
            //    availableQuantityTextBox.Text = stockIn.AvailableQuantity.ToString();
            //}
            
        }

   

        protected void saveButton_Click(object sender, EventArgs e)
        {
            StockIn stockIn=new StockIn();
            stockIn.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            stockIn.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
            stockIn.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
            stockIn.AvailableQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
            stockIn.StockInQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
            StockIn aStockIn = stockInManager.GetAvailableAndStockInQuantity(stockIn.ItemId);
            if (aStockIn != null)
            {
                int availableQuantity = aStockIn.AvailableQuantity;
                int stockInQuantity = aStockIn.StockInQuantity;
                stockIn.AvailableQuantity = stockIn.AvailableQuantity + availableQuantity;
                stockIn.StockInQuantity = stockIn.StockInQuantity + stockInQuantity;
                messageLabel.Text = stockInManager.Update(stockIn);
                availableQuantityTextBox.Text = stockIn.AvailableQuantity.ToString();
            }
            else
            {
                messageLabel.Text = stockInManager.Save(stockIn);
                availableQuantityTextBox.Text = stockIn.AvailableQuantity.ToString();
            }
            stockInQuantityTextBox.Text = "";

        }

    }
}