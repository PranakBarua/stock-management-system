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
    public partial class SearchAndViewItemsUI : System.Web.UI.Page
    {
        CategoryManager categoryManager=new CategoryManager();
        CompanyManager companyManager=new CompanyManager();
        ItemManager itemManager=new ItemManager();
        SearchAndViewManager searchAndViewManager=new SearchAndViewManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Company> companies = companyManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("---Select Company---", "0"));

                List<Category> categories = categoryManager.GetAllCategories();
                categoryDropDownList.DataSource = categories;
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataTextField = "Name";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Insert(0, new ListItem("---Select Category---", "0"));
            }
          
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Item item=new Item();
            item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            item.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            if (item.CompanyId == 0 && item.CategoryId == 0)
            {
                messageLabel.Text = "Select Dropdownlist";
            }
            else
            {
                //if (item.CompanyId != 0 && item.CategoryId != 0)
                //{
                //    searchAndViewManager.Search(item);
                //}
                List<SearchAndView> searchAndViews = searchAndViewManager.Search(item);
                searchAndViewGridView.DataSource = searchAndViews;
                searchAndViewGridView.DataBind();
            }
        }
    }
}