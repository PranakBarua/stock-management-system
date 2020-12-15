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
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        StockInManager stockInManager = new StockInManager();
        StockOutManager stockOutManager=new StockOutManager();
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
            if (ViewState["stockOutItem"] == null)
            {
                availableQuantityTextBox.Text = stockInManager.GetAvailableQuantity(id).ToString();
            }
            else
            {
                List<StockOut> stockOuts = (List<StockOut>)ViewState["stockOutItem"];
                bool hasItem = false;
                foreach (var stock in stockOuts)
                {
                    if (stock.ItemId == id)
                    {
                        hasItem = true;
                        availableQuantityTextBox.Text = stock.AvailableQuantity.ToString();
                        //stock.AvailableQuantity = stock.AvailableQuantity - stockOut.StockOutQuantity;
                    }
                }
                if (hasItem == false)
                {
                    availableQuantityTextBox.Text = stockInManager.GetAvailableQuantity(id).ToString();
                }
            }
        }


        protected void addButton_Click(object sender, EventArgs e)
        {
            messageLevel.Text = "";
            StockOut stockOut = new StockOut();
            stockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            stockOut.Company = companyDropDownList.SelectedItem.Text;
            stockOut.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
            stockOut.Item = itemDropDownList.SelectedItem.Text;
            stockOut.StockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            stockOut.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
            if ((stockOut.AvailableQuantity - stockOut.StockOutQuantity) >= 0)
            {
                StockIn stockIn = new StockIn();
                stockIn.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                stockIn.AvailableQuantity = stockOut.StockOutQuantity - stockOut.AvailableQuantity;
                if (ViewState["stockOutItem"] == null)
                {
                    List<StockOut> stockOuts = new List<StockOut>();
                    stockOuts.Add(stockOut);
                    stockOut.AvailableQuantity = stockOut.AvailableQuantity - stockOut.StockOutQuantity;
                    ViewState["stockOutItem"] = stockOuts;
                    stockOutGridView.DataSource = stockOuts;
                    stockOutGridView.DataBind();          
                }
                else
                {
                    List<StockOut> stockOuts = (List<StockOut>)ViewState["stockOutItem"];
                    bool hasItem = false;
                    foreach (var stock in stockOuts)
                    {
                        if (stock.Item == stockOut.Item)
                        {
                            hasItem = true;
                            stock.StockOutQuantity = stock.StockOutQuantity + stockOut.StockOutQuantity;
                            stock.AvailableQuantity = stock.AvailableQuantity - stockOut.StockOutQuantity;
                            stockOut.AvailableQuantity = stock.AvailableQuantity;
                        }
                    }
                    if (hasItem!=true)
                    {
                        stockOut.AvailableQuantity = stockOut.AvailableQuantity - stockOut.StockOutQuantity;
                        stockOuts.Add(stockOut);
                    }      
                   
                    stockOutGridView.DataSource = stockOuts;
                    stockOutGridView.DataBind();
                        
                }
                     availableQuantityTextBox.Text = stockOut.AvailableQuantity.ToString();
            }
            else
            {
                messageLevel.Text = "Available quantity will not be negative";
            }
            availableQuantityTextBox.Text = stockOut.AvailableQuantity.ToString();
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            //List<GridView> gridViews = (List<GridView>) ViewState["stockOutItem"];
            
            foreach (GridViewRow row in stockOutGridView.Rows)
            {
                StockIn stockIn=new StockIn();
                StockOut stockOut=new StockOut();
                stockOut.Item = ((Label) row.FindControl("ItemNameLabel")).Text;
                stockOut.Company = ((Label) row.FindControl("companyNameLabel")).Text;
                stockOut.StockOutQuantity = Convert.ToInt32(((Label)row.FindControl("stockOutQuantityLabel")).Text);
                stockOut.ActionType = "Sell";
                stockOut.ItemId = itemManager.GetItemIdByItemName(stockOut.Item);
                stockOut.AvailableQuantity = stockInManager.GetAvailableQuantity(stockOut.ItemId) -
                                             stockOut.StockOutQuantity;
                messageLevel.Text=stockOutManager.AddStockOut(stockOut);

                stockIn.ItemId = stockOut.ItemId;
                stockIn.AvailableQuantity = stockOut.AvailableQuantity;
                stockInManager.UpdateAvailableQuantity(stockIn);
                
            }
          SettingNull();
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in stockOutGridView.Rows)
            {
                StockIn stockIn = new StockIn();
                StockOut stockOut = new StockOut();
                stockOut.Item = ((Label)row.FindControl("ItemNameLabel")).Text;
                stockOut.Company = ((Label)row.FindControl("companyNameLabel")).Text;
                stockOut.StockOutQuantity = Convert.ToInt32(((Label)row.FindControl("stockOutQuantityLabel")).Text);
                stockOut.ActionType = "Damage";
                stockOut.ItemId = itemManager.GetItemIdByItemName(stockOut.Item);
                stockOut.AvailableQuantity = stockInManager.GetAvailableQuantity(stockOut.ItemId) -
                                             stockOut.StockOutQuantity;
                messageLevel.Text = stockOutManager.AddStockOut(stockOut);

                stockIn.ItemId = stockOut.ItemId;
                stockIn.AvailableQuantity = stockOut.AvailableQuantity;
                stockInManager.UpdateAvailableQuantity(stockIn);

            }
         SettingNull();
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in stockOutGridView.Rows)
            {
                StockIn stockIn = new StockIn();
                StockOut stockOut = new StockOut();
                stockOut.Item = ((Label) row.FindControl("ItemNameLabel")).Text;
                stockOut.Company = ((Label) row.FindControl("companyNameLabel")).Text;
                stockOut.StockOutQuantity = Convert.ToInt32(((Label) row.FindControl("stockOutQuantityLabel")).Text);
                stockOut.ActionType = "Lost";
                stockOut.ItemId = itemManager.GetItemIdByItemName(stockOut.Item);
                stockOut.AvailableQuantity = stockInManager.GetAvailableQuantity(stockOut.ItemId) -
                                             stockOut.StockOutQuantity;
                messageLevel.Text = stockOutManager.AddStockOut(stockOut);

                stockIn.ItemId = stockOut.ItemId;
                stockIn.AvailableQuantity = stockOut.AvailableQuantity;
                stockInManager.UpdateAvailableQuantity(stockIn);

            }
            SettingNull();
        }

        private void SettingNull()
        {
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            ViewState["stockOutItem"] = null;
        }
    }
}