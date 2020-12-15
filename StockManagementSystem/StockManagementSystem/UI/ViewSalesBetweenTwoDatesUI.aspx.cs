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
    public partial class ViewSalesBetweenTwoDatesUI : System.Web.UI.Page
    {
        ViewSalesBetweenTwoDatesManager viewSalesBetweenTwoDatesManager=new ViewSalesBetweenTwoDatesManager();
        StockOutManager stockOutManager=new StockOutManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            ViewSalesBetweenTwoDates viewSalesBetweenTwoDates=new ViewSalesBetweenTwoDates();
            viewSalesBetweenTwoDates.FromDate = DateTime.Parse(fromDateTextBox.Text);
            viewSalesBetweenTwoDates.ToDate = DateTime.Parse(toDateTextBox.Text);
            if (viewSalesBetweenTwoDates.FromDate > viewSalesBetweenTwoDates.ToDate)
            {
                messageLabel.Text = "From date should not be greater";
            }
            else
            {
                List<StockOut> stockOuts = viewSalesBetweenTwoDatesManager.Search(viewSalesBetweenTwoDates);
                viewSalesBetweenTwoDatesGridView.DataSource = stockOuts;
                viewSalesBetweenTwoDatesGridView.DataBind();
            }        
        }
    }
}