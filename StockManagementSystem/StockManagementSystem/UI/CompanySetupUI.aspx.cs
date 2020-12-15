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
    public partial class CompanySetup : System.Web.UI.Page
    {
        CompanyManager companyManager=new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            List<Company>companies=companyManager.GetAllCompanies();
            companyGridView.DataSource = companies;
            companyGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company company=new Company();
            company.Name = nameTextBox.Text;
            messageLabel.Text = companyManager.Save(company);
            PopulateGridView();
        }
    }
}