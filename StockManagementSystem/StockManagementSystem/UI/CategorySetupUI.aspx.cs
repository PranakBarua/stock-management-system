using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.UI
{
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        CategoryManager categoryManager=new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            List<Category> categories = categoryManager.GetAllCategories();
            categoryGridView.DataSource = categories;
            categoryGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Category category=new Category();
            category.Name = nameTextBox.Text;
            if (saveButton.Text == "Save")
            {
                messageLabel.Text = categoryManager.Save(category);
            }
            else
            {
                category.Id = Convert.ToInt32(idHiddenField.Value);
                messageLabel.Text = categoryManager.Update(category);
            }
           
            
            PopulateGridView();

        }
        protected void categoryGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(categoryGridView,
                    "Select$" + e.Row.RowIndex);
            }
        }
        protected void categoryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = categoryGridView.SelectedRow;
            if (row != null)
            {
                Label nameL = (Label) row.FindControl("nameLabel");
                string name = nameL.Text;
                nameTextBox.Text = name;
                HiddenField idL = (HiddenField) row.FindControl("idLabel");
                string id = idL.Value;
                idHiddenField.Value = id;
                saveButton.Text = "Update";
            }
        }


    }
}